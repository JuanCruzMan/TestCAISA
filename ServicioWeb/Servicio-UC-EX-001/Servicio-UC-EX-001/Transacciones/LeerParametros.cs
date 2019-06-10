using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Servicio_UC_EX_001.Transacciones
{
    public class LeerParametros
    {
        #region Variables rutas y conexión con base de datos
        static public string pathInfo = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        static public string ruta = pathInfo.Substring(6, LeerParametros.pathInfo.Length - 6);

        #endregion
        public void Leer()
        {
            XmlDocument xDoc = new XmlDocument();
            //La ruta del documento XML permite rutas relativas
            //respecto del ejecutable!
            xDoc.Load(ruta + "/Parametros.xml");
            XmlNodeList conexion = xDoc.GetElementsByTagName("conexion");
            XmlNodeList lista = ((XmlElement)conexion[0]).GetElementsByTagName("ValidaConexion");
            foreach (XmlElement nodo in lista)
            {
                int i = 0; XmlNodeList nNombre = nodo.GetElementsByTagName("nombre");
               
                XmlNodeList nValidaDat = nodo.GetElementsByTagName("ValidaDat");
                XmlNodeList nCorreoEnvia = nodo.GetElementsByTagName("CorreoEnvia");
                XmlNodeList nPassCorreo = nodo.GetElementsByTagName("PassCorreo");
                XmlNodeList nSmtp = nodo.GetElementsByTagName("Smtp");
                XmlNodeList nPuerto = nodo.GetElementsByTagName("Puerto");
                XmlNodeList nCorreoDestino = nodo.GetElementsByTagName("CorreoDestino");
                XmlNodeList nCorreoDestino1 = nodo.GetElementsByTagName("CorreoDestino1");
                XmlNodeList nMsjAsunto = nodo.GetElementsByTagName("MsjAsunto");
                XmlNodeList nMsjBodyExepcion1 = nodo.GetElementsByTagName("MsjBodyExepcion1");
                XmlNodeList nMsjBodyExepcion2 = nodo.GetElementsByTagName("MsjBodyExepcion2");
                Transacciones.nNombre = nNombre[i].InnerText;
                Transacciones.nValidaConexion = nValidaDat[i].InnerText;
                Transacciones.CorreoEnvia = nCorreoEnvia[i].InnerText;
                Transacciones.PassCorreo = nPassCorreo[i].InnerText;
                Transacciones.Smtp = nSmtp[i].InnerText;
                Transacciones.Puerto = nPuerto[i].InnerText;
                Transacciones.CorreoDestino = nCorreoDestino[i].InnerText;
                Transacciones.CorreoDestino1 = nCorreoDestino1[i].InnerText;
                Transacciones.MsjAsunto = nMsjAsunto[i].InnerText;
                Transacciones.MsjBodyExepcion1 = nMsjBodyExepcion1[i].InnerText;
                Transacciones.MsjBodyExepcion2 = nMsjBodyExepcion2[i].InnerText;
                

            }

        }
    }
}