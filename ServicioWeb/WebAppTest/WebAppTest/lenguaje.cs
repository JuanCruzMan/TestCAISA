using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppTest
{
    public class lenguaje
    {

        public void ChangeLanguge(string val)
        {
            if (val == "Spanish")
            { 
                Loguin.lblLogButt1 ="Ingreso";
                Loguin.lblLogButt2 ="Recuperar Contraseña";
                Loguin.lblLogButt3 ="Registrarse";
                Loguin.lblLogButt4 ="Ingles";
                Loguin.lblLogUser ="Usuario: ";
                Loguin.lblLogPas ="Contraseña: ";
                Loguin.lblLogTitle = "Ingreso al sistema";
                Loguin.lblRecButt1 = "Enviar";
                Loguin.lblRecUser = "Usuario:";
                Loguin.lblRecTitle = "Recuperacion de Contraseña";
                Loguin.lblLogConFail = "Problema con la conexion.";
                Loguin.lblLogInvPas = "Contraseña invalida.";
                Loguin.lblLogRecPas = "Fallo el ingreso, desea recuperar la contraseña?";
                Loguin.lblRecUsInv = "El usuario no esta dado de alta.";
                Loguin.lblRecSentMal = "Se envio la recuperacion de su contraseña a su correo electronico.";
                Loguin.lblRecButt2 = "Regresar a Ingreso.";
                Loguin.lblAltButt1 = "Registrar";
                Loguin.lblAltButt2 = "Cancelar";
                Loguin.lblAltButt3 = "Calendario";
                Loguin.lblAltTitle = "Registro de Usuario.";
                Loguin.lblAltMail = "Correo Electronico: ";
                Loguin.lblAltUer = "Usuario: ";
                Loguin.lblAlPass = "Contraseña: ";
                Loguin.lblAltPass1 = "Confirmar Contraseña: ";
                Loguin.lblAltNom = "Nombre: ";
                Loguin.lblAltApP = "Apellido Paterno: ";
                Loguin.lblAltApM  = "Apellido Materno: ";
                Loguin.lblAltFecN = "Fecha de Nacimiento: ";
                Loguin.lblAltEda = "Edad: ";
                Loguin.lblAltDirec = "Direccion: ";
                Loguin.lblAltTel = "Telefono: ";
                Loguin.lblAltMsg = "La contraseña no coincide";
                Loguin.lblAltMsgYaUser = "El nombre de usuario/correo electronico ya esta registrado";
                Loguin.lblAltMsgYaMail = "El correo elctronico ya esta registrado";
                Loguin.lblMnuTitle = "Sistema de Registro.";
                Loguin.lblMnuNom = "Nombre Completo: ";
                Loguin.lblMnuEdad = "Edad: ";
                Loguin.lblMnuItm1 = "Editar Datos Personales.";
                Loguin.lblMnuItm2 = "Cambiar Contraseña.";
                Loguin.lblMnuItem3 = "Cerrar Sesion.";
                Loguin.lblEditTitle = "Editar Datos Personales.";
                Loguin.lblEditButt1 = "Guardar";
                Loguin.lblEditButt2 = "Borrar";
                Loguin.lblchnPasTitle = "Cambiar Contraseña";
                Loguin.lblchnPasActl = "Contraseña Actual: ";
                Loguin.lblchnPasNew = "Nueva Contraseña: ";
                Loguin.lblchnPasConf = "Confirmar Contraseña: ";
                Loguin.lblchnPasButt1 = "Guardar";
                Loguin.lblchnPasMsg = "Se esta cambiando la contraseña, al finalizar se debe confirmar el ingreso.";
                Loguin.lblAceptar = "Aceptar";
                Loguin.lblFin = "Sesion Finalizada";
                Loguin.lblchnPassRep = "Ingrese otra contraseña que No haya utilizado.";
            } 
            else
            {
                Loguin.lblLogButt1 = "Login";
                Loguin.lblLogButt2 = "Recover password";
                Loguin.lblLogButt3 = "Enroll";
                Loguin.lblLogButt4 = "Spanish";
                Loguin.lblLogUser = "User Name:";
                Loguin.lblLogPas = "Paasword: ";
                Loguin.lblLogTitle = "System Login";
                Loguin.lblRecButt1 = "Send";
                Loguin.lblRecUser = "User Name:";
                Loguin.lblRecTitle = "Recovery Password";
                Loguin.lblLogConFail = "Coneccion problem.";
                Loguin.lblLogInvPas = "Invalid Password.";
                Loguin.lblLogRecPas = "Login fail, Would you like recover the password?";
                Loguin.lblRecUsInv = "The user is not registered.";
                Loguin.lblRecSentMal = "Has been sent the recovery password to your e-mail.";
                Loguin.lblRecButt2 = "Back login.";
                Loguin.lblAltButt1 = "Enroll";
                Loguin.lblAltButt2 = "Cancel";
                Loguin.lblAltButt3 = "Calendar";
                Loguin.lblAltTitle = "User register.";
                Loguin.lblAltMail = "E-mail: ";
                Loguin.lblAltUer = "User: ";
                Loguin.lblAlPass = "Password: ";
                Loguin.lblAltPass1 = "Confirm Password: ";
                Loguin.lblAltNom = "Name: ";
                Loguin.lblAltApP = "Last name: ";
                Loguin.lblAltApM = "Mother's last name: ";
                Loguin.lblAltFecN = "Birthdate: ";
                Loguin.lblAltEda = "Age: ";
                Loguin.lblAltDirec = "Address: ";
                Loguin.lblAltTel = "Telephone: ";
                Loguin.lblAltMsg = "Password does not match";
                Loguin.lblAltMsgYaUser = "The username/e-mail is already registered";
                Loguin.lblAltMsgYaMail = "The email is already registered";
                Loguin.lblMnuTitle = "Registration System";
                Loguin.lblMnuNom = "Full name: ";
                Loguin.lblMnuEdad = "Age: ";
                Loguin.lblMnuItm1 = "Edit Personal Data.";
                Loguin.lblMnuItm2 = "Change Password.";
                Loguin.lblMnuItem3 = "Sign off.";
                Loguin.lblEditTitle = "Edit Personal Data.";
                Loguin.lblEditButt1 = "Save";
                Loguin.lblEditButt2 = "Delete";
                Loguin.lblchnPasTitle = "Change Password";
                Loguin.lblchnPasActl = "Current password: ";
                Loguin.lblchnPasNew = "New Password: ";
                Loguin.lblchnPasConf = "Confirm Password: ";
                Loguin.lblchnPasButt1 = "Save";
                Loguin.lblchnPasMsg = "The password is being changed, upon completion the entry must be confirmed.";
                Loguin.lblAceptar = "Accept";
                Loguin.lblFin = "Finished Session";
                Loguin.lblchnPassRep = "Enter another password that you have not used.";
            }
        }
    }
}