using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Servicio_UC_EX_001.Modelo;

namespace Servicio_UC_EX_001.Transacciones
{
    public class Transacciones
    {
        public static string nValidaConexion, nNombre, CorreoEnvia, PassCorreo, Smtp, Puerto, CorreoDestino, CorreoDestino1, MsjAsunto,
            StoredProcedureReaSeg, MsjBodyExepcion1, MsjBodyExepcion2;
         static SqlConnection conn;
         static SqlCommand comm;
         static SqlDataReader dr = null;
        static string strInfo = "";
        static string SqlInst = "";
        public class ValidaDatos
        {
            public List<Usuarios> ValidaUsuario(string usuario)
            {
                //Sellama el metodo para encriptar y desencriptar
                StringPassword Encript = new StringPassword();
                //string passEncrypt = Encript.Encrypt(pass);
                string usuarioEncrypt = Encript.Encrypt(usuario);

                LeerParametros rea = new LeerParametros();
                rea.Leer();
                string strInfo = nValidaConexion + ";";
                List<Usuarios> lstDatos = new List<Usuarios>();
                
                Usuarios tmpData;
                SqlInst = "create procedure ValidarUsuario(@Usuario varchar(50)) as Begin "
                    + "SELECT id,correoelectronico,Usuario,pass,nombre,apellidoPat,apellidoMat,fechNac,edad,direccion,telefono,pass1, pass2, pass3 "
                    + "FROM Usuario with(nolock) WHERE usuario=@Usuario  End";

                conn = new SqlConnection(strInfo);
                comm = new SqlCommand(SqlInst, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { if (conn.State != ConnectionState.Closed) { conn.Close(); } }

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidarUsuario";

                
                cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 50).Value = usuarioEncrypt;
                //cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = passEncrypt;
                try
                {
                    conn.Open();
                    cmd.Prepare();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        tmpData = new Usuarios();

                        tmpData.id = dr.GetInt32(0);
                        tmpData.correoelectronico = dr.GetString(1);
                        tmpData.Usuario = Encript.Decrypt(dr.GetString(2));
                        tmpData.pass = Encript.Decrypt(dr.GetString(3));
                        tmpData.nombre = Encript.Decrypt(dr.GetString(4));
                        tmpData.apellidoPat = Encript.Decrypt(dr.GetString(5));
                        tmpData.apellidoMat = Encript.Decrypt(dr.GetString(6));
                        tmpData.fechNac = dr.GetString(7);
                        tmpData.edad = dr.GetInt32(8);
                        tmpData.direccion = dr.GetString(9);
                        tmpData.telefono = dr.GetString(10);
                        tmpData.pass1 = dr.GetString(11);
                        tmpData.pass2 = dr.GetString(12);
                        tmpData.pass3 = dr.GetString(13);
                        lstDatos.Add(tmpData);

                    }
                    dr.Close();
                    conn.Close();
                    
              

                }
                catch (Exception ex)
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                        return lstDatos;
                    }
                }
            
                return lstDatos;
            }

            public string InsertarDatos(string user, string pass, string correoelectronico, string nombre, string apePa, string apeMa,
            string domicilio, string fechNac, string edad, string telefono, string pass1, string pass2, string pass3)
            {

                LeerParametros rea = new LeerParametros();
                rea.Leer();

                string strInfo = nValidaConexion + ";";


                string Result = "";
                SqlInst = "create procedure InsertUsuario (@correoelectronico nvarchar(50),@Usuario nvarchar(50),@pass nvarchar(50),"
               + "@nombre nvarchar(50),@apellidoPat nvarchar(50),@apellidoMat nvarchar(50),@fechNac nvarchar(50),@edad int,@direccion nvarchar(50),"
               + "@telefono nvarchar(50),@pass1 nvarchar(50),@pass2 nvarchar(50),@pass3 nvarchar(50)) as Begin "
               + "INSERT INTO Usuario(correoelectronico,Usuario,pass,nombre,apellidoPat,apellidoMat,fechNac,edad,direccion,telefono,pass1,pass2,pass3) " +
                               "VALUES (@correoelectronico,@Usuario,@pass,@nombre,@apellidoPat,@apellidoMat,@fechNac,@edad,@direccion,@telefono,@pass1,@pass2,@pass3) End";
                conn = new SqlConnection(strInfo);
                comm = new SqlCommand(SqlInst, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { if (conn.State != ConnectionState.Closed) { conn.Close(); } }


                StringPassword Encript = new StringPassword();
                try
                {

                    
                    conn = new SqlConnection(strInfo);
                    conn.Open();
                    SqlTransaction sqltrans = conn.BeginTransaction();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.Transaction = sqltrans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertUsuario";
                    cmd.Parameters.Add("@correoelectronico", SqlDbType.NVarChar, 50).Value = correoelectronico;
                    cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(user);
                    cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(pass);
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(nombre);
                    cmd.Parameters.Add("@apellidoPat", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(apePa);
                    cmd.Parameters.Add("@apellidoMat", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(apeMa);
                    cmd.Parameters.Add("@fechNac", SqlDbType.NVarChar, 50).Value = fechNac;
                    cmd.Parameters.Add("@edad", SqlDbType.Int).Value = Int32.Parse(edad);
                    cmd.Parameters.Add("@direccion", SqlDbType.NVarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@telefono", SqlDbType.NVarChar, 50).Value = telefono;
                    cmd.Parameters.Add("@pass1", SqlDbType.NVarChar, 50).Value = pass1;
                    cmd.Parameters.Add("@pass2", SqlDbType.NVarChar, 50).Value = pass2;
                    cmd.Parameters.Add("@pass3", SqlDbType.NVarChar, 50).Value = pass3;

                    cmd.Prepare();
                    int vLRs = cmd.ExecuteNonQuery();
                    sqltrans.Commit();
                    if (vLRs == 1)
                    {
                        Result = "Se guardaron los datos con exito.";
                    }
                    else
                    {
                        sqltrans.Rollback();
                        Result = "Error StoredProcedure No se salvaron los datos.";
                       
                    }
                }
                catch (Exception ex)
                {
                    
                    if (conn.State != ConnectionState.Closed)
                    { conn.Close(); }
                    return Encript.Encrypt(Result = ex.Message + "... No se salvaron los datos.");
                }
                finally
                {
                    conn.Close();
                }
                return Result;

            }

            public string ActualizarDatos(int id, string user, string pass, string correoelectronico, string nombre, string apePa, string apeMa,
            string domicilio, string fechNac, string edad, string telefono, string pass1, string pass2, string pass3)
            {
                
                LeerParametros rea = new LeerParametros();
                rea.Leer();

                string strInfo = nValidaConexion + ";";
                
                
                string Result = "";
                SqlInst = "create procedure UpdateUsuario (@id int, @correoelectronico nvarchar(50),@Usuario nvarchar(50),@pass nvarchar(50),"
               + "@nombre nvarchar(50),@apellidoPat nvarchar(50),@apellidoMat nvarchar(50),@fechNac nvarchar(50),@edad int,@direccion nvarchar(50),"
               + "@telefono nvarchar(50),@pass1 nvarchar(50),@pass2 nvarchar(50),@pass3 nvarchar(50)) as Begin "
               + "Update Usuario set correoelectronico=@correoelectronico,Usuario=@Usuario,pass=@pass,nombre=@nombre,apellidoPat=@apellidoPat,"
               + "apellidoMat=@apellidoMat,fechNac=@fechNac,edad=@edad,direccion=@direccion,telefono=@telefono,pass1=@pass1,pass2=@pass2,pass3=@pass3 where id=@id end";
                               
                conn = new SqlConnection(strInfo);
                comm = new SqlCommand(SqlInst, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { if (conn.State != ConnectionState.Closed) { conn.Close(); } }


                StringPassword Encript = new StringPassword();
                try
                {

                  
                    conn = new SqlConnection(strInfo);
                    conn.Open();
                    SqlTransaction sqltrans = conn.BeginTransaction();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.Transaction = sqltrans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "UpdateUsuario";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@correoelectronico", SqlDbType.NVarChar, 50).Value = correoelectronico;
                    cmd.Parameters.Add("@usuario", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(user);
                    cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(pass);
                    cmd.Parameters.Add("@nombre", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(nombre);
                    cmd.Parameters.Add("@apellidoPat", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(apePa);
                    cmd.Parameters.Add("@apellidoMat", SqlDbType.NVarChar, 50).Value = Encript.Encrypt(apeMa);
                    cmd.Parameters.Add("@fechNac", SqlDbType.NVarChar, 50).Value = fechNac;
                    cmd.Parameters.Add("@edad", SqlDbType.Int).Value =Int32.Parse(edad);
                    cmd.Parameters.Add("@direccion", SqlDbType.NVarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@telefono", SqlDbType.NVarChar, 50).Value = telefono;
                    cmd.Parameters.Add("@pass1", SqlDbType.NVarChar, 50).Value = pass1;
                    cmd.Parameters.Add("@pass2", SqlDbType.NVarChar, 50).Value = pass2;
                    cmd.Parameters.Add("@pass3", SqlDbType.NVarChar, 50).Value = pass3;
              

                    cmd.Prepare();
                    int vLRs = cmd.ExecuteNonQuery();
                    sqltrans.Commit();
                    if (vLRs == 1)
                    {
                        Result = "Se Actualizaron los datos con exito.";
                    }
                    else
                    {
                        sqltrans.Rollback();
                        Result = "Error StoredProcedure No se salvaron los datos.";
                        
                    }
                }
                catch (Exception ex)
                {
                    
                    if (conn.State != ConnectionState.Closed)
                    { conn.Close(); }
                    return Encript.Encrypt(Result = ex.Message + "... No se salvaron los datos.");
                }
                finally
                {
                    conn.Close();
                }
                return Result;

            }

            public string EliminarDatos(int id, string user, string pass)
            {

                LeerParametros rea = new LeerParametros();
                rea.Leer();

                string strInfo = nValidaConexion + ";";


                string Result = "";
                SqlInst = "create procedure DeleteUsuario (@id int) as Begin "
               + "Delete Usuario where id=@id end";

                conn = new SqlConnection(strInfo);
                comm = new SqlCommand(SqlInst, conn);
                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex) { if (conn.State != ConnectionState.Closed) { conn.Close(); } }


                StringPassword Encript = new StringPassword();
                try
                {

                    
                    conn = new SqlConnection(strInfo);
                    conn.Open();
                    SqlTransaction sqltrans = conn.BeginTransaction();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.Transaction = sqltrans;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeleteUsuario";
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    

                    cmd.Prepare();
                    int vLRs = cmd.ExecuteNonQuery();
                    sqltrans.Commit();
                    if (vLRs == 1)
                    {
                        Result = "Se Eliminaron los datos con exito.";
                    }
                    else
                    {
                        sqltrans.Rollback();
                        Result = "Error StoredProcedure No se salvaron los datos.";
                        
                    }
                }
                catch (Exception ex)
                {
                   
                    if (conn.State != ConnectionState.Closed)
                    { conn.Close(); }
                    return Encript.Encrypt(Result = ex.Message + "... No se salvaron los datos.");
                }
                finally
                {
                    conn.Close();
                }
                return Result;

            }
        }
    }
}