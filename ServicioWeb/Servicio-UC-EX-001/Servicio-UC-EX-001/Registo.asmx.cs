using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Servicio_UC_EX_001.Transacciones;
using Servicio_UC_EX_001.Modelo;

namespace Servicio_UC_EX_001
{
    /// <summary>
    /// El servcio sirve para dar de alta usuarios, modificar datos , eliminar datos y recuperacion de contraseña
    /// </summary>
    [WebService(Namespace = "http://CAISA_DEMO.org/", Name = "Registro de Usuario", Description = "Servicio para alta de usuario")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Registo : System.Web.Services.WebService
    {
        Transacciones.Transacciones.ValidaDatos newValDat = new Transacciones.Transacciones.ValidaDatos();
        Transacciones.EnviarMail mail = new EnviarMail();

        [WebMethod]
        public List<Usuarios> Ingreso(string usuario)
        {
            List<Usuarios> lista = new List<Usuarios>();
            lista = newValDat.ValidaUsuario(usuario);
            return lista;
        }

        [WebMethod]
        public string CapturaUsuario(string usuario, string pass, string correo, string nombre, string apePa, string apeMa,
            string domicilio, string fechNac, string edad, string telefono, string pass1,string pass2,string pass3)
        {
            string result = newValDat.InsertarDatos(usuario, pass, correo, nombre, apePa, apeMa, domicilio, fechNac, edad, telefono, pass1, pass2, pass3);
            return result;
        }
        [WebMethod]
        public string ActualizaUsuario(int id, string usuario, string pass, string correo, string nombre, string apePa, string apeMa,
            string domicilio, string fechNac, string edad, string telefono, string pass1, string pass2, string pass3)
        {
            string result = newValDat.ActualizarDatos(id, usuario, pass, correo, nombre, apePa, apeMa, domicilio, fechNac, edad, telefono, pass1, pass2, pass3);
            return result;
        }
        [WebMethod]
        public string BorraUsuario(int id, string usuario, string pass)
        {
            string result = newValDat.EliminarDatos(id, usuario, pass);
            return result;
        }
        [WebMethod]
        public string EnviarCorreo(string user, string correo, string pass)
        {
            LeerParametros ls = new LeerParametros();
            ls.Leer();
            mail.SMTPMail(Transacciones.Transacciones.CorreoDestino, 
                correo, 
                Transacciones.Transacciones.MsjAsunto + " de " + user, 
                Transacciones.Transacciones.MsjBodyExepcion1+pass+" "+Transacciones.Transacciones.MsjBodyExepcion2+user,
                Transacciones.Transacciones.CorreoEnvia, Transacciones.Transacciones.PassCorreo, "");


            return "";
        }

    }

}
