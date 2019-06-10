using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppTest.Estructura;

namespace WebAppTest
{
    public partial class CambiarPass : System.Web.UI.Page
    {
        List<Usuarios> lista = new List<Usuarios>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Attributes.Add("OnClick",
         "window.open('MsjAlert.aspx',null,'height=220,width=480');");
            if (Loguin.lblLogButt4 == null)
            {
                lenguaje lang = new lenguaje();
                lang.ChangeLanguge("Spanish");
            }

            
            Button1.Text = Loguin.lblchnPasButt1;
            Label1.Text = Loguin.lblchnPasTitle;
            Label2.Text = Loguin.lblchnPasActl;
            Label3.Text = Loguin.lblchnPasNew;
            Label4.Text = Loguin.lblchnPasConf;
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
            if (ValidExist())
            {
                if (TextBox2.Text == TextBox3.Text)
                {
                    foreach (Usuarios c in lista)
                    {
                        if (Loguin.user == c.Usuario && TextBox1.Text == c.pass)
                        {
                            if (HistoryPass(TextBox2.Text, c.pass1, c.pass2, c.pass3))
                            {
                                servicio.ActualizaUsuario(c.id, c.Usuario, TextBox2.Text, c.correoelectronico,
                                    c.nombre, c.apellidoPat, c.apellidoMat, c.direccion, c.fechNac, c.edad.ToString(),
                                    c.telefono, Loguin.passH1, Loguin.passH2, Loguin.passH3);
                                Label5.Text = Loguin.lblchnPasMsg;
                                Loguin.cierre = true;
                            }
                            else
                            {
                                Label5.Text = Loguin.lblchnPassRep;
                                Loguin.cierre = false;
                            }
                        }
                        else
                        {
                            Label5.Text = Loguin.lblLogConFail;
                            Loguin.cierre = false;
                        }
                    }
                }
            }
            else
            {
                Label5.Text = Loguin.lblLogInvPas;
                Loguin.cierre = false;
            }
            //System.Threading.Thread.Sleep(3000);
            
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts","<script>alert('Se cambio Exitosamente la contraseña');</script>");
            if (Loguin.cierre)
            {
                Response.Redirect("Loguin.aspx");
            }
        }
        public bool HistoryPass(string pnw, string p1, string p2, string p3)
        {
            bool result;
            if (pnw != p1 && pnw != p2 && pnw != p3)
            {
                Loguin.passH1 = pnw;
                Loguin.passH2 = p1;
                Loguin.passH3 = p2;
                result = true;
            }
            else
            {
                result = false;
            }
            return result; ;
        }
        public bool ValidExist()
        {

            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
            
            try
            {
                var lst = servicio.Ingreso(Loguin.user);
                if (lst.Count() != 0)
                {
                    
                    
                    Usuarios tmpData;

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
                        tmpData.fechNac = x.fechNac;
                        tmpData.edad = x.edad;
                        tmpData.direccion = x.direccion;
                        tmpData.telefono = x.telefono;
                        tmpData.pass1 = x.pass1;
                        tmpData.pass2 = x.pass2;
                        tmpData.pass3 = x.pass3;
                        if (TextBox1.Text == x.pass)
                        {
                            lista.Add(tmpData);
                            Loguin.idUser = x.id;
                            TextBox1.Text = x.pass;
                            Loguin.res = true;
                        }
                        else
                        {
                            Label5.Text = Loguin.lblLogInvPas;
                            Loguin.res = false;
                        }
                        

                    }

                }
            }
            catch (Exception)
            {
                Label5.Text = Loguin.lblLogConFail;
            }
            return Loguin.res;
        }
    }
}