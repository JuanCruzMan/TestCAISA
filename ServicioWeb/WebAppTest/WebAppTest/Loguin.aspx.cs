using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppTest.Estructura;

namespace WebAppTest
{
    public partial class Loguin : System.Web.UI.Page
    {//carga las variable publicas estaticas para toda la aplicacion
        public static string user, pass, pass1, lblAceptar, lblFin, passH1, passH2, passH3;
        public static int idUser = 0;
        public static string lblLogButt1, lblLogButt2, lblLogButt3, lblLogButt4, lblLogUser, lblLogPas, lblLogTitle, lblLogConFail, lblLogInvPas, lblLogRecPas;
        public static string lblRecButt1, lblRecButt2, lblRecUser, lblRecTitle, lblRecUsInv, lblRecSentMal;
        public static string lblAltButt1, lblAltButt2, lblAltButt3, lblAltTitle, lblAltMail, lblAltUer, lblAlPass, lblAltPass1, lblAltNom, lblAltApP, lblAltApM, lblAltFecN, lblAltEda,
                                lblAltDirec, lblAltTel, lblAltMsg, lblAltMsgYaUser, lblAltMsgYaMail, lblEditTitle, lblEditButt1, lblEditButt2;
        public static string lblMnuTitle, lblMnuNom, lblMnuEdad, lblMnuItm1, lblMnuItm2, lblMnuItem3;
        public static string lblchnPasTitle, lblchnPasActl, lblchnPasNew, lblchnPasConf, lblchnPasMsg, lblchnPasButt1, lblchnPassRep;
        public static bool res,cierre = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Inicialmente se cargan etiquetas en español
            Button1.Text = "Ingreso";
            Button2.Text = "Recuperar Contrseña";
            Button3.Text = "Registrarse";
            Label1.Text = "Usuario: ";
            Label2.Text = "Contraseña: ";
            Label3.Text = "Ingreso al sistema";
            if (lblLogButt4 == null)
                Button4.Text = "Ingles";
            else
                Button4.Text = lblLogButt4;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
             user = TextBox1.Text;
             pass = TextBox2.Text;
            
            try
            {//valida la existencia del usuario
                var lst = servicio.Ingreso(user);
                if (lst.Count() == 0)
                {
                    Labelresultado.Text = lblLogRecPas;
                }
                else 
                {
                    foreach (var x in lst)
                    {//valida la contraseña
                        if(pass==x.pass)
                        Response.Redirect("SistemaMenu.aspx");
                        else
                            Labelresultado.Text = lblLogInvPas;

                    }
                }
            }
            catch(Exception)
            {
                Labelresultado.Text = lblLogConFail;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaUsuario.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecuperarPass.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {  //Cambia el lenguaje
            Labelresultado.Text = "";
            lenguaje lang = new lenguaje();
            lang.ChangeLanguge(Button4.Text);
            Button1.Text= lblLogButt1;
            Button2.Text=lblLogButt2;
            Button3.Text=lblLogButt3;
            Button4.Text=lblLogButt4;
            Label1.Text= lblLogUser;
            Label2.Text= lblLogPas;
            Label3.Text = lblLogTitle;
        }
    }
}