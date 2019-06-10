using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppTest.Estructura;

namespace WebAppTest
{
    public partial class RecuperarPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button2.Visible = false;
            //valida el lenguaje que se utiliza para las etiquetas
            if (Loguin.lblLogButt4 == null)
            {
                lenguaje lang = new lenguaje();
                lang.ChangeLanguge("Spanish");
            }

            Button2.Text = Loguin.lblRecButt2;
            Button1.Text = Loguin.lblRecButt1;
            Label1.Text = Loguin.lblRecUser;
            Label2.Text = Loguin.lblRecTitle;
            if (Loguin.res)
            {
                Labelresultado.Text = Loguin.lblAltMsgYaUser; // +", " + Loguin.lblAltMsgYaMail;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Labelresultado.Text = "";
            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
            List<Usuarios> lista = new List<Usuarios>();
            Loguin.user = TextBox1.Text;
            

            try
            {  //Valida el usuario
                var lst = servicio.Ingreso(Loguin.user);
                if (lst.Count() == 0)
                {
                    Labelresultado.Text = Loguin.lblRecUsInv;
                }
                else
                {               
                    Usuarios tmpData;
                    // carga los datos en una lista estructurada
                    foreach (var x in lst)
                    {
                        tmpData = new Usuarios();
                        tmpData.id = x.id;
                        tmpData.correoelectronico = x.correoelectronico;
                        tmpData.Usuario = x.Usuario;
                        tmpData.pass = x.pass;
                        tmpData.nombre = x.nombre;
                        tmpData.apellidoPat = x.apellidoPat;
                        tmpData.apellidoMat = x.apellidoMat;
                        servicio.EnviarCorreo(x.nombre + " " + x.apellidoPat + " " + x.apellidoMat, x.correoelectronico, x.pass);
                        tmpData.fechNac = x.fechNac;
                        tmpData.edad = x.edad;
                        tmpData.direccion = x.direccion;
                        tmpData.telefono = x.telefono;
                        lista.Add(tmpData);
                    } 
                           
                        
                            Labelresultado.Text = Loguin.lblRecSentMal;
                            Button2.Visible = true;
                }
            }
            catch (Exception)
            {
                Labelresultado.Text = Loguin.lblLogConFail;
            }
         
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loguin.aspx");
        }
    }
}