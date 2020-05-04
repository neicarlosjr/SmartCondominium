using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SmartCondominium.Infra
{

    public class Email
    {

        //private string conta;
        // private string smtp;
        // private int porta;

        public string EnviarEmail(string destinatario, string assunto, string corpo)
        {
            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress("SmartCondminium <suporte@thorgranitos.kinghost.net>");

            //Define os destinatários do e-mail.
            objEmail.To.Add(destinatario);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assunto;

            //Define o corpo do e-mail.
            objEmail.Body = corpo;

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            // Caso queira enviar um arquivo anexo
            //Caminho do arquivo a ser enviado como anexo
            //string arquivo = Server.MapPath("arquivo.jpg");

            // Ou especifique o caminho manualmente
            //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

            // Cria o anexo para o e-mail
            //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

            // Anexa o arquivo a mensagemn
            //objEmail.Attachments.Add(anexo);

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails, localhost(recomendado) 
            objSmtp.Host = "smtp.thorgranitos.com.br";
            objSmtp.Port = 587;
            objSmtp.Credentials = new System.Net.NetworkCredential("suporte@thorgranitos.kinghost.net", "th2016");

            //Enviamos o e-mail através do método .send()
            try
            {
                objSmtp.Send(objEmail);
                return ("E-mail enviado com sucesso !");
            }
            catch (Exception ex)
            {
                return ("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }
        }




    }
}