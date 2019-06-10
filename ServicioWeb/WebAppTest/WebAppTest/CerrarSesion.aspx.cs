using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppTest
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Attributes.Add("OnClick",
         "window.close();");
            Label1.Text = Loguin.lblFin;
            Button1.Text = Loguin.lblAceptar;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}