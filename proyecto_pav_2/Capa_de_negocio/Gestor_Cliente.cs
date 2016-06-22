using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Capa_de_negocio
{
    public class Gestor_Cliente
    {
        private static Capa_de_datos.Acceso_A_Datos ad;
        private static string sql;

        public static DataTable buscar_clientes()
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            //sql = "select c.id_cliente,c.nombre,c.apellido,t.nombre AS 'Tipo Documento',c.numero_documento,c.telefono," +
            //       "c.celular,c.calle,c.numero,l.nombre as 'Localidad' ,c.mail,c.estado " +
            //       "from Cliente c , Localidad l , Tipo_Documento t " +
            //       "where c.id_tipo_documento=t.id_tipo_documento " +
            //       "and c.id_localidad=l.id_localidad and c.estado=1"; 
            sql = "select c.id_cliente AS 'id_cliente',c.nombre,c.apellido,t.nombre as 'Tipo Documento',"+
                   "c.numero_documento,c.telefono,c.celular,c.calle,"+
                   "c.numero,l.nombre as 'Localidad',c.mail,c.fecha_nacimiento,c.sexo,"+
                   "u.nombre_usuario as 'Usuario' "+
                   "from cliente c, Tipo_Documento t ,Localidad l , Usuario u "+
                   "where c.id_tipo_documento=t.id_tipo_documento and "+
                     "l.id_localidad=c.id_localidad and "+
                   "u.id_cliente=c.id_cliente and "+
                   "c.estado=1 and u.estado=1";
           
            DataTable dt = new DataTable();
            dt = ad.leo_tabla(sql);

            return dt;
        }
        public static DataTable buscar_por_nombre(string filtro_a_buscar, string orden)
        {
            ad = new Capa_de_datos.Acceso_A_Datos();
            DataTable dt = new DataTable();


            //sql = "select c.id_cliente,c.nombre,c.apellido,t.nombre AS 'Tipo Documento',c.numero_documento,c.telefono," +
            //       "c.celular,c.calle,c.numero,l.nombre as Localidad ,c.mail " +
            //       "from Cliente c , Localidad l , Tipo_Documento t " +
            //       "where c.id_tipo_documento=t.id_tipo_documento " +
            //       "and c.id_localidad=l.id_localidad " +
            //       "and c.nombre like @nombre " +
            //       "and c.estado=1" +
            //       "order by " + orden;
            sql = "select c.id_cliente AS 'id_cliente',c.nombre,c.apellido,t.nombre as 'Tipo Documento'," +
                   "c.numero_documento,c.telefono,c.celular,c.calle," +
                   "c.numero,l.nombre as 'Localidad',c.mail,c.fecha_nacimiento,c.sexo," +
                   "u.nombre_usuario as 'Usuario' " +
                   "from cliente c, Tipo_Documento t ,Localidad l , Usuario u " +
                   "where c.id_tipo_documento=t.id_tipo_documento and " +
                     "l.id_localidad=c.id_localidad and " +
                   "u.id_cliente=c.id_cliente and " +
                   "c.estado=1 and u.estado=1 and "+
                   "c.nombre like @nombre order by "+orden;

            dt = ad.leo_tabla("@nombre", filtro_a_buscar, sql);

            return dt;
        }
        public static Capa_de_entidad.Usuario buscar_por_id(int id_cliente)
        {
            string id = "" + id_cliente;

            //sql = "select c.id_cliente,c.nombre,c.apellido,t.id_tipo_documento,c.numero_documento,c.telefono," +
            //       "c.celular,c.calle,c.numero,l.id_localidad,c.mail" +
            //       " from Cliente c , Localidad l , Tipo_Documento t" +
            //       " where c.id_tipo_documento=t.id_tipo_documento" +
            //      " and c.id_localidad=l.id_localidad" +
            //      " and c.estado=1"+
            //       " and c.id_cliente= @id_cliente";
            sql = "select c.id_cliente AS 'id_cliente',c.nombre,c.apellido,t.id_tipo_documento," +
                   "c.numero_documento,c.telefono,c.celular,c.calle," +
                   "c.numero,l.id_localidad,c.mail,c.fecha_nacimiento,c.sexo,u.contraseña," +
                   "u.nombre_usuario  " +
                   "from cliente c, Tipo_Documento t ,Localidad l , Usuario u " +
                   "where c.id_tipo_documento=t.id_tipo_documento and " +
                     "l.id_localidad=c.id_localidad and " +
                   "u.id_cliente=c.id_cliente and " +
                   "c.estado=1 and u.estado=1 and c.id_cliente=@id_cliente";

            Capa_de_entidad.Cliente c = new Capa_de_entidad.Cliente();

       Capa_de_datos.Acceso_A_Datos ad = new Capa_de_datos.Acceso_A_Datos();
       Capa_de_entidad.Usuario u = new Capa_de_entidad.Usuario();
         SqlDataReader dr = ad.leo_tabla_lectura("@id_cliente", id, sql);

            while (dr.Read())
            {

                if (dr["id_cliente"] != DBNull.Value)
                {
                 c.id_cliente = (int)dr["id_cliente"];
                }
                c.nombre = dr["nombre"].ToString();
                c.apellido = dr["apellido"].ToString();

           
                if (dr["id_tipo_documento"] != DBNull.Value)
                {
                    Capa_de_entidad.Tipo_Documento td = new Capa_de_entidad.Tipo_Documento();
                    td.id_tipo_documento = (int)dr["id_tipo_documento"];
                    c.tipo_documento= td;
                }

                if (dr["numero_documento"] != DBNull.Value)
                {
                    c.numero_documento = (int)dr["numero_documento"];
                }
                if (dr["telefono"]!=DBNull.Value)
                { 
                  c.telefono=(int)dr["telefono"];  
                }
                if (dr["celular"] != DBNull.Value)
                {
                    c.celular = (int)dr["celular"];
                }
                c.calle = dr["calle"].ToString();
                
                if (dr["numero"]!=DBNull.Value)
                {
                    c.numero = (int)dr["numero"];   
                }
                if (dr["id_localidad"] != DBNull.Value)
                {
                    Capa_de_entidad.Localidad l = new Capa_de_entidad.Localidad();
                    l.id_localidad = (int)dr["id_localidad"];
                    c.localidad =l ;
                }
                c.mail = dr["mail"].ToString();
                //if (dr["fecha_comienzo_funcionamiento"] != DBNull.Value)
                //{
                //    pt.fecha_comienzo_funcionamiento = (DateTime)dr["fecha_comienzo_funcionamiento"];
                //}
                if (dr["fecha_nacimiento"]!=DBNull.Value)
                {
                    c.fecha_nacimiento=(DateTime)dr["fecha_nacimiento"];
                }
                c.sexo = dr["sexo"].ToString();
                
                u.nombre_usuario = dr["nombre_usuario"].ToString();
                u.contraseña = dr["contraseña"].ToString();
                u.cliente = c;
           }
            //sql = "select * from usuario where id_cliente=@id_cliente";
            //Usuario u = new Usuario();

            //SqlDataReader dr1 = ad.leo_tabla_lectura("@id_cliente", id, sql);

            //while (dr1.Read())
            //{
            //    u.nombre_usuario = dr1["nombre_usuario"].ToString();
            //}
            //dr1.Close();
            dr.Close();
           ad.cerrar_conexion();

           return u;
        }
        public static void agregar_cliente(Capa_de_entidad.Usuario u)
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            int id_cliente = 0; 

            sql = "insert into Cliente (nombre,apellido,id_tipo_documento,numero_documento,telefono,celular,calle,numero,id_localidad,mail,estado,fecha_nacimiento,sexo) values (@nombre,@apellido,@id_tipo_documento,@numero_documento,@telefono,@celular,@calle,@numero,@id_localidad,@mail,1,@fecha_nacimiento,@sexo)";
            string parametros ="@nombre="+ u.cliente.nombre + ",@apellido="+ u.cliente.apellido + ",@id_tipo_documento="+ u.cliente.tipo_documento.id_tipo_documento +",@numero_documento="+ u.cliente.numero_documento+",@telefono="+u.cliente.telefono+",@celular="+u.cliente.celular+",@calle="+u.cliente.calle+",@numero="+u.cliente.numero+",@id_localidad="+u.cliente.localidad.id_localidad+",@mail="+u.cliente.mail+",@fecha_nacimiento="+u.cliente.fecha_nacimiento.ToShortDateString()+",@sexo="+u.cliente.sexo;
            ad.insertar(sql, parametros);

            sql = "select MAX(id_cliente) as 'id_cliente' from Cliente ";

            SqlDataReader dr = ad.leo_tabla_lectura(sql);
            while (dr.Read())
            {
                id_cliente = (int)dr["id_cliente"];
            }

            u.cliente.id_cliente = id_cliente;
            sql = "insert into usuario (nombre_usuario,contraseña,id_cliente,estado,rol) values (@nombre_usuario,@contraseña,@id_cliente,1,'cliente')";
            string parametro = "@nombre_usuario="+ u.nombre_usuario +",@contraseña="+ u.contraseña +",@id_cliente="+id_cliente;
            ad.insertar(sql, parametro);
            dr.Close();
            ad.cerrar_conexion();
        }



        public static void modificar_cliente(Capa_de_entidad.Usuario u, int id)
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "UPDATE Cliente SET " +
                "nombre = '" + u.cliente.nombre + "', apellido = '" + u.cliente.apellido +
                "', id_tipo_documento = " + u.cliente.tipo_documento.id_tipo_documento + ", telefono = " + u.cliente.telefono +
              ", celular = " + u.cliente.celular + ", calle = '" + u.cliente.calle +
            "', numero = " + u.cliente.numero + ", id_localidad= "+u.cliente.localidad.id_localidad+", mail= '"+u.cliente.mail+
            "',fecha_nacimiento= '" + u.cliente.fecha_nacimiento.ToString("dd/MM/yyyy") + "',sexo= '" + u.cliente.sexo +
            "' WHERE id_cliente = @id_cliente";

            //string parametro = "@id_cliente=" + c.id_cliente;
            string parametro = "@id_cliente=" + id;

            ad.modificar(sql, parametro);

            sql = "UPDATE usuario SET " +
               "nombre_usuario= '" + u.nombre_usuario + "',contraseña= '" + u.contraseña + 
               "' where id_cliente=@id_cliente";
            parametro = "@id_cliente=" + id+",@id_usuario="+u.id_usuario;
            ad.modificar(sql, parametro);
           }

        public static void eliminar_cliente(Capa_de_entidad.Usuario u, int id)
        {
            ad = new Capa_de_datos.Acceso_A_Datos();

            sql = "UPDATE Cliente SET " +
                "estado = 0 " +
                "WHERE id_cliente = @id_cliente";

            //string parametro = "@id_cliente=" + c.id_cliente;
            string parametro = "@id_cliente=" + id;
            ad.modificar(sql, parametro);

            sql = "update usuario set estado=0 where idcliente=@id_cliente";
            parametro = "@id_cliente=" + id+" @id_usuario="+u.id_usuario;
        }
    }
}