using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using System.Diagnostics;

public class smtpMessage
{
    private Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
    {
        [1] = $"shutdown /s {new Random().Next(1, 59)} /m {new Random().Next(1, 59)} /h {new Random().Next(1, 23)}",
        [2] = $"shutdown /s {new Random().Next(1, 59)} /h {new Random().Next(1, 23)} /m {new Random().Next(1, 59)}",
        [3] = $"shutdown /m {new Random().Next(1, 59)} /s {new Random().Next(1, 59)} /h {new Random().Next(1, 23)}",
        [4] = $"shutdown /m {new Random().Next(1, 59)} /h {new Random().Next(1, 23)} /s {new Random().Next(1, 59)}",
        [5] = $"shutdown /h {new Random().Next(1, 23)} /m {new Random().Next(1, 59)} /s {new Random().Next(1, 59)}",
        [6] = $"shutdown /h {new Random().Next(1, 23)} /s {new Random().Next(1, 59)} /m {new Random().Next(1, 59)}",
        [7] = $"shutdown /h {new Random().Next(1, 23)} /s {new Random().Next(1, 59)}",
        [8] = $"shutdown /s {new Random().Next(1, 59)} /h {new Random().Next(1, 23)}",
        [9] = $"shutdown /h {new Random().Next(1, 23)} /m {new Random().Next(1, 59)}",
        [10] = $"shutdown /m {new Random().Next(1, 59)} /h {new Random().Next(1, 23)}",
        [11] = $"shutdown /m {new Random().Next(1, 59)} /s {new Random().Next(1, 59)}",
        [12] = $"shutdown /s {new Random().Next(1, 59)} /m {new Random().Next(1, 59)}",
        [13] = $"shutdown /s {new Random().Next(1, 59)}",
        [14] = $"shutdown /m {new Random().Next(1, 59)}",
        [15] = $"shutdown /h {new Random().Next(1, 23)}"
    };

    public void SendMessage(int op)
    {
        using var smtpClient = new SmtpClient();
 
        try
        {
            smtpClient.Connect("smtp.gmail.com", 465, MailKit.Security.SecureSocketOptions.Auto);
            smtpClient.Authenticate(ApplicationDatas.FirstMail, ApplicationDatas.Password);

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("Niko", ApplicationDatas.FirstMail));
            message.To.Add(new MailboxAddress("Self", ApplicationDatas.FirstMail));

            message.Subject = "Greetings";

            var part = new TextPart("plain")
            {
                Text = keyValuePairs[op]
            };

            message.Body = part;

            smtpClient.Send(message);

        }
        catch (Exception ex) when (ex is ArgumentNullException or InvalidCastException)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            smtpClient.Disconnect(true);
        }
    }

    public void ShutdownPC()
    {
        using var imapClient = new ImapClient();

        try
        {
            imapClient.Connect("imap.gmail.com", 993, true);

            imapClient.Authenticate(ApplicationDatas.FirstMail, ApplicationDatas.Password);

            var folder = imapClient.GetFolder("Inbox");

            folder.Open(FolderAccess.ReadOnly);

            var messages = folder.GetMessage(folder.Count - 1);

            string messageBody = messages.Body.ToString();

            Console.WriteLine("Сообщение получено и считывается...");

            Console.WriteLine($"Комп выключится через: {GetIntService.GetIntFromStrMethod(messageBody[messageBody.IndexOf(" /")..])} секунд/ы. За минуту до отключения вам придет предупреждение.");

            Process.Start("shutdown",$"/s /t {GetIntService.GetIntFromStrMethod(messageBody[messageBody.IndexOf(" /")..])}");
        }
        catch (Exception ex) when (ex is ArgumentNullException or InvalidCastException)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            imapClient.Disconnect(true);
        }
    }
}
