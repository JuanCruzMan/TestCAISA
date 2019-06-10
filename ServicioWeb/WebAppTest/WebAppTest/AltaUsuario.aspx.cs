using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppTest.Estructura;

namespace WebAppTest
{
    public partial class AltaUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Loguin.lblLogButt4 == null)
            {
                lenguaje lang = new lenguaje();
                lang.ChangeLanguge("Spanish");
            }

            Button2.Text = Loguin.lblAltButt2;
            Button1.Text = Loguin.lblAltButt1;
            //Button3.Text = Loguin.lblAltButt3;
            Label1.Text = Loguin.lblAltTitle;
            Label2.Text = Loguin.lblAltMail;
            Label3.Text = Loguin.lblAltUer;
            Label4.Text = Loguin.lblAlPass;
            Label5.Text = Loguin.lblAltPass1;
            Label6.Text = Loguin.lblAltNom;
            Label7.Text = Loguin.lblAltApP;
            Label8.Text = Loguin.lblAltApM;
            Label9.Text = Loguin.lblAltFecN;
            Label10.Text = Loguin.lblAltEda;
            Label11.Text = Loguin.lblAltDirec;
            Label12.Text = Loguin.lblAltTel;
            if (Loguin.pass != null)
            {
                TextBox3.Text=Loguin.pass;
                TextBox4.Text=Loguin.pass1;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == TextBox4.Text)
            {
                if (!ValidExist())
                {
                    WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();

                    servicio.CapturaUsuario(TextBox2.Text, TextBox3.Text, TextBox1.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox10.Text, TextBox8.Text,
                        TextBox9.Text, TextBox11.Text,TextBox3.Text,"","");
                    Response.Redirect("Loguin.aspx");
                }
                else 
                {
                    Response.Redirect("RecuperarPass.aspx");
                }
            }
            else 
            {
                Label13.Text = Loguin.lblAltMsg;
            }
        }
        public bool ValidExist()
        {
           
            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                var lst = servicio.Ingreso(TextBox2.Text);
                if (lst.Count() != 0)
                {
                    Loguin.res = true;
                    Label13.Text = Loguin.lblAltMsgYaUser;
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
                        if (TextBox1.Text == x.correoelectronico)
                        {
                            lista.Add(tmpData);
                            Label13.Text = Label13.Text + ", " + Loguin.lblAltMsgYaMail;
                        }
                    }

                }
                else { Loguin.res = false; }
            }

            catch (Exception)
            {
                Label13.Text = Loguin.lblLogConFail;
            }
            return Loguin.res;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loguin.aspx");
        }

       

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (TextBox3.Text != "")
                {
                    Loguin.pass = TextBox3.Text;
                    Loguin.pass1 = TextBox4.Text;
                }

                string dem = TextBox8.Text;  //10-04-1968
            int anioCumple = Int32.Parse(dem.Substring(6, 4)); //Anio de Cumple
           
                
                    string diaCumple = dem.Substring(0, 2);//Dia del Cumpleanios
                    int mesCumple = Int32.Parse(dem.Substring(3, 2));//Mes de Cumple 4=Abril

                    DateTime fechaNacimiento = new DateTime(anioCumple, mesCumple, Int32.Parse(diaCumple));

                    //Se calcula la Edad Actual A partir de la fecha actual Sustrayendo la fecha de nacimiento
                    //esto devuelve un TimeSpan por tanto tomaremos los Dias y lo dividimos en 365 días
                    int edad = (DateTime.Now.Subtract(fechaNacimiento).Days / 365);
                    
                    TextBox9.Text = edad.ToString();
                    if (Loguin.pass != null)
                    {
                        TextBox3.Text = Loguin.pass;
                        TextBox4.Text = Loguin.pass1;
                    }
                    
                
            }
            
                catch (Exception es)
                { }
        }

       

      

       
    }
}