using Infraestructura.Conexiones;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class PersonaDatos
    {
        private ConexionDB conexion;

        public PersonaDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO public.persona(idPersona, nombre, apellido, tipoDocumento, nroDocumento," +
                                                    "direccion, celular, email, estado, idCiudad)" +
                                                "VALUES(@idPersona, @nombre, @apellido, @tipoDocumento,@nroDocumento" +
                                                "@direccion, @celular, @email, @estado, @idCiudad )", conn);
            comando.Parameters.AddWithValue("idPersona", persona.idpersona);
            comando.Parameters.AddWithValue("nombre", persona.nombre);
            comando.Parameters.AddWithValue("apellido", persona.apellido);
            comando.Parameters.AddWithValue("tipoDocumento", persona.tipoDocumento);
            comando.Parameters.AddWithValue("nroDocumento", persona.nroDocumento);
            comando.Parameters.AddWithValue("direccion", persona.direccion);
            comando.Parameters.AddWithValue("celular", persona.celular);
            comando.Parameters.AddWithValue("email", persona.email);
            comando.Parameters.AddWithValue("estado", persona.estado);
            comando.Parameters.AddWithValue("idciudad", persona.ciudadd.idCiudad);

            comando.ExecuteNonQuery();
        }

        public PersonaModel obtenerPersonaPorId(int id)
        {
            var conn = conexion.GetConexion();
            //var comando = new Npgsql.NpgsqlCommand($"Select * from persona where idPersona = {id}", conn);
            var comando = new Npgsql.NpgsqlCommand($"SELECT ciudad.*, persona.* " +
                                                   $"FROM ciudad  " +
                                                   $"INNER JOIN persona ON persona.idCiudad = ciudad.idCiudad " +
                                                   $"where persona.idPersona = '{id}'", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new PersonaModel
                {
                    idpersona = reader.GetInt32("idPersona"),
                    nombre = reader.GetString("nombre"),
                    apellido = reader.GetString("apellido"),
                    tipoDocumento = reader.GetString("tipoDocumento"),
                    nroDocumento= reader.GetString("nroDocumento"),
                    direccion = reader.GetString("direccion"),
                    celular = reader.GetString("celular"),
                    email = reader.GetString("email"),
                    estado = reader.GetString("estado"),
                    ciudadd = new CiudaddModel()
                    {
                        idCiudad = reader.GetInt32("idCiudad"),
                        ciudad = reader.GetString("ciudad"),
                        departamento = reader.GetString("Departamento"),
                        codigoPostal = reader.GetString("Codigo Postal"),
                        
                    }

                };
            }
            return null;
        }

        public PersonaModel EliminarPersonaPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM persona WHERE idPersona= {id}", conn);
            using var reader = comando.ExecuteReader();
            return null;
        }

        public void modificarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE persona SET nombre = '{persona.nombre}', " +
                                                          $"apellido = '{persona.apellido}', " +
                                                          $"tipoDocumento = '{persona.tipoDocumento}', " +
                                                          $"nroDocumento = '{persona.nroDocumento}', " +
                                                          $"direccion = '{persona.direccion}', " +
                                                          $"celular = '{persona.celular}', " +
                                                          $"email = '{persona.email}' ," +
                                                          $"estado = '{persona.estado}' " +
                                                $" WHERE idPersona = {persona.idpersona}", conn);

            comando.ExecuteNonQuery();
        }
    }
}
