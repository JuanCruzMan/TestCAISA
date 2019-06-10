using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppTest.Estructura;

namespace WebAppTest
{
    public partial class SistemaMenu : System.Web.UI.Page
    {
        WSRegistro.RegistrodeUsuarioSoapClient servicio = new WSRegistro.RegistrodeUsuarioSoapClient();
        List<Usuarios> lista = new List<Usuarios>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //se agrega ventana emergente para el cierre de sesion
            Button3.Attributes.Add("OnClick",
         "window.open('CerrarSesion.aspx',null,'height=220,width=480');");
            //Determina que lenguaje usar en las etiquetas
            if (Loguin.lblLogButt4 == null)
            {
                lenguaje lang = new lenguaje();
                lang.ChangeLanguge("Spanish");
            }
            Label1.Text = Loguin.lblMnuTitle;
            Label2.Text = Loguin.lblMnuNom;
            Label3.Text = Loguin.lblMnuEdad;
            Button1.Text = Loguin.lblMnuItm1;
            Button2.Text = Loguin.lblMnuItm2;
            Button3.Text = Loguin.lblMnuItem3;
            Usuarios tmpData;
            //llama funcion de ingreso para validar la existencia del usuario
            var lst = servicio.Ingreso(Loguin.user);

            //Carga la lista estructurada
            foreach (var x in lst)
            {
                tmpData = new Usuarios();
                tmpData.id = x.id;
                tmpData.Usuario = x.Usuario;
                tmpData.pass = x.pass;
                tmpData.nombre = x.nombre;
                tmpData.apellidoPat = x.apellidoPat;
                tmpData.apellidoMat = x.apellidoMat;
                TextBox1.Text = x.nombre + " " + x.apellidoPat + " " + x.apellidoMat;
                tmpData.fechNac = x.fechNac;
                tmpData.edad = x.edad;
                TextBox2.Text = x.edad.ToString();
                tmpData.direccion = x.direccion;
                tmpData.telefono = x.telefono;
                lista.Add(tmpData);
            } 
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditDatos.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarPass.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Loguin.aspx");
        }

       
    }
}