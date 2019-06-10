using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppTest.Estructura;

namespace WebAppTest
{
    public partial class EditDatos : System.Web.UI.Page
    {
        List<Usuarios> lista = new List<Usuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Loguin.lblLogButt4 == null)
            {
                lenguaje lang = new lenguaje();
                lang.ChangeLanguge("Spanish");
            }

            Button2.Text = Loguin.lblEditButt2;
            Button1.Text = Loguin.lblEditButt1;
            Label1.Text = Loguin.lblEditTitle;
            Label2.Text = Loguin.lblAltMail;
            Label6.Text = Loguin.lblAltNom;
            Label7.Text = Loguin.lblAltApP;
            Label8.Text = Loguin.lblAltApM;
            Label9.Text = Loguin.lblAltFecN;
            Label10.Text = Loguin.lblAltEda;
            Label11.Text = Loguin.lblAltDirec;
            Label12.Text = Loguin.lblAltTel;
            if (!Loguin.res)
            {
                ValidExist();
            }
        }
        public bool ValidExist()
        {

            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
           
            try
            {
                var lst = servicio.Ingreso(Loguin.user);
                if (lst.Count() != 0)
                {
                    Loguin.res = true;
                    //Label13.Text = Loguin.lblAltMsgYaUser;
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
                        
                            lista.Add(tmpData);
                            Loguin.idUser = x.id;
                            Loguin.passH1 = x.pass1;
                            Loguin.passH2 = x.pass2;
                            Loguin.passH3 = x.pass3;
                           TextBox1.Text = x.correoelectronico;
                           TextBox5.Text = x.nombre;
                           TextBox6.Text = x.apellidoPat;
                           TextBox7.Text = x.apellidoMat;
                           TextBox8.Text = x.fechNac;
                           TextBox9.Text = x.edad.ToString();
                           TextBox10.Text = x.direccion;
                           TextBox11.Text = x.telefono;
                        
                    }

                }
            }
            catch (Exception)
            {
                Label13.Text = Loguin.lblLogConFail;
            }
            return Loguin.res;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
            try
            {
                servicio.ActualizaUsuario(Loguin.idUser, Loguin.user, Loguin.pass, TextBox1.Text, TextBox5.Text,
                    TextBox6.Text, TextBox7.Text, TextBox10.Text, TextBox8.Text, TextBox9.Text, TextBox11.Text,Loguin.passH1,Loguin.passH2,Loguin.passH3);
                Response.Redirect("Loguin.aspx");
            }
            catch (Exception ex)
            {
                Label13.Text = Loguin.lblLogConFail;
            }
        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                string dem = TextBox8.Text;  //10-04-1968
                int anioCumple = Int32.Parse(dem.Substring(6, 4)); //Anio de Cumple


                string diaCumple = dem.Substring(0, 2);//Dia del Cumpleanios
                int mesCumple = Int32.Parse(dem.Substring(3, 2));//Mes de Cumple 4=Abril

                DateTime fechaNacimiento = new DateTime(anioCumple, mesCumple, Int32.Parse(diaCumple));

                //Se calcula la Edad Actual A partir de la fecha actual Sustrayendo la fecha de nacimiento
                //esto devuelve un TimeSpan por tanto tomaremos los Dias y lo dividimos en 365 días
                int edad = (DateTime.Now.Subtract(fechaNacimiento).Days / 365);

                TextBox9.Text = edad.ToString();

            }

            catch (Exception es)
            { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
            servicio.BorraUsuario(Loguin.idUser, Loguin.user, Loguin.pass);
        }
    }
}