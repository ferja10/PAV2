﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capa_de_datos
{
    public class Acceso_A_Datos
    {
        private SqlConnection cn;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private DataTable dt;
        private SqlTransaction tran;
        /// <summary>
        /// establece una nueva conexion de datos
        /// </summary>
        public Acceso_A_Datos()
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            string cadena_conexion = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
            cn = new SqlConnection(cadena_conexion);
        }

        /// <summary>
        /// abre una nueva conexion a datos
        /// </summary>
        public void abrir_conexion() 
        {
            if (cn != null && cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            cn.Open();
        }

        /// <summary>
        /// devuelve una tabla virtual
        /// </summary>
        /// <param name="sql">string sql</param>
        /// <returns>SqlDataReader</returns>
        public DataTable leo_tabla(string sql) 
        {
            try
            {
                cmd = new SqlCommand(sql, cn);
                dt = new DataTable();
                abrir_conexion();
                dr = cmd.ExecuteReader();
                dt.Load(dr);

                cerrar_conexion();    
                
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        /// <summary>
        /// devuelte una tabla virtual
        /// </summary>
        /// <param name="parametro">nombre de la variable parámetro que será enviado ("@parametro")</param>
        /// <param name="nombre_parametro">nombre del atributo que dará valor al parámetro ("valor")</param>
        /// <param name="sql">instruccion sql ("select ...")</param>
        /// <returns>DataTable</returns>
        public DataTable leo_tabla(string parametro,string nombre_parametro, string sql) 
        {
            try
            {
                dt = new DataTable();
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(new SqlParameter(parametro, "%" + nombre_parametro + "%"));
                abrir_conexion();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                cerrar_conexion();
                return dt;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        /// <summary>
        /// devuelve una tabla virtual para lectura
        /// </summary>
        /// <param name="parametro">nombre de la variable parámetro que será enviado ("@parametro")</param>
        /// <param name="nombre_parametro">nombre del atributo que dará valor al parámetro ("valor")</param>
        /// <param name="sql">instruccion sql ("select ...")</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader leo_tabla_lectura(string parametro, string nombre_parametro, string sql) 
        {
            try
            {
                cmd = new SqlCommand(sql, cn);
                cmd.Parameters.Add(new SqlParameter(parametro, nombre_parametro));
                abrir_conexion();
                dr = cmd.ExecuteReader();
                //cerrar_conexion();
                return dr;
            }
            catch (Exception)
            {
                
                throw;
            }

            
        }

        public SqlDataReader leo_tabla_lectura(string sql, string parametros) 
        {

            try
            {
                if (parametros.Trim() != "")
                {
                    cmd = new SqlCommand(sql, cn);
                    agrgar_parametros(sql, parametros);

                    abrir_conexion();

                }

                return dr = cmd.ExecuteReader();
            }
            catch (Exception)
            {
                
                throw;
            }

            
        }

        /// <summary>
        /// lee una consulta sql en formato cadena y devuelve una tabla para lectura
        /// </summary>
        /// <param name="sql">instruccion sql ("select ...")</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader leo_tabla_lectura(string sql) 
        {
            try
            {
                cmd = new SqlCommand(sql, cn);
                abrir_conexion();
                dr = cmd.ExecuteReader();
                //cerrar_conexion();
                return dr;
            }
            catch (Exception)
            {
                
                throw;
            }

           
        }

        /// <summary>
        /// Inserta varios campos en una base de datos
        /// </summary>
        /// <param name="sql">instruccion sql ("insert ...")</param>
        /// <param name="parametros">parámetro con su valor con el siguiente formato: "@parametro1=valor1,@parametro2=valor2...@parametroN=valorN"</param>
        public void insertar(string sql,string parametros) 
        {

            try
            {
                if (parametros.Trim() != "")
                {
                    cmd = new SqlCommand(sql, cn);

                    agrgar_parametros(sql, parametros);

                    abrir_conexion();

                    cmd.ExecuteNonQuery();

                    cerrar_conexion();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// modfica una tabla de la base de datos en funcion de los parámetros ingresados
        /// </summary>
        /// <param name="sql">instruccion sql (update...)</param>
        /// <param name="parametros">parámetro con su valor con el siguiente formato: "@parametro1=valor1,@parametro2=valor2...@parametroN=valorN"</param>
        public void modificar(string sql, string parametros) 
        {
            try
            {
                if (parametros.Trim() != "")
                {
                    cmd = new SqlCommand(sql, cn);

                    agrgar_parametros(sql, parametros);

                    abrir_conexion();

                    cmd.ExecuteNonQuery();

                    cerrar_conexion();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void agrgar_parametros(string sql, string parametros) 
        {
            string campo, parametro;
            int i_coma = 0, i_igual = 0;

            while (true)
            {
                i_igual = parametros.IndexOf("=", i_coma);
                campo = parametros.Substring(i_coma + 1, i_igual - i_coma - 1);
                i_coma = parametros.IndexOf(",", i_igual);

                if (i_coma > 0)
                {
                    parametro = parametros.Substring(i_igual + 1, i_coma - i_igual - 1);
                }
                else
                {
                    parametro = parametros.Substring(i_igual + 1);
                    break;
                }

                cmd.Parameters.Add(new SqlParameter(campo, parametro.ToString().Replace("#", ",")));

            }

            cmd.Parameters.Add(new SqlParameter(campo, parametro.ToString().Replace("#", ",")));
        }

        public void abrir_transaccion() 
        {
            abrir_conexion();
            tran = cn.BeginTransaction();
        }

        public void ejecutar_transaccion(string sql, string parametros) 
        {
            
           cmd = cn.CreateCommand();
           cmd.Transaction = tran;
           cmd.CommandText = sql;
           agrgar_parametros(sql,parametros);
           cmd.ExecuteNonQuery();
        }

        public void cerrar_transaccion_con_errores() 
        {
            tran.Rollback();
        }

        public void cerrar_transaccion() 
        {
            tran.Commit();
        }

        /// <summary>
        /// cierra conexion a base de datos
        /// </summary>
        public void cerrar_conexion() 
        {
            if (cn != null && cn.State == System.Data.ConnectionState.Open)
            {
                cn.Close(); 
            }
        }
    }
}