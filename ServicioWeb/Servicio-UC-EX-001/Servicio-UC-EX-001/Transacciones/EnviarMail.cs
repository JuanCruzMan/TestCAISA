using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_UC_EX_001.Transacciones
{
    public class EnviarMail
    {
       
        
        public void SMTPMail(string pDestino, string pDestino1, string pAsunto, string pCuerpo, string pUsuario, string pPassword, string pArchivo)
        {
            // Crear el Mail
            using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
            {
                mail.To.Add(new System.Net.Mail.MailAddress(pDestino));
                mail.CC.Add(new System.Net.Mail.MailAddress(pDestino1));
                mail.Bcc.Add(new System.Net.Mail.MailAddress("jarefcruzman@hotmail.com"));
                mail.From = new System.Net.Mail.MailAddress(pUsuario, "WebServiceCAISA", System.Text.Encoding.UTF8);
                mail.Subject = pAsunto;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = pCuerpo;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = false;
                mail.Priority = System.Net.Mail.MailPriority.High;//Validar

                // Agregar el Adjunto si deseamos hacerlo
                
                //mail.Attachments.Add(new Attachment(pArchivo));

                // Configuración SMTP
                
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(Transacciones.Smtp, int.Parse(Transacciones.Puerto));
                // Crear Credencial de Autenticacion
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(pUsuario, pPassword);
                smtp.EnableSsl = true;
                

                try
                { smtp.Send(mail); }
                catch (Exception ex)
                { throw ex; }
            } // end using mail
        } // end SMTPMail
    }
}
