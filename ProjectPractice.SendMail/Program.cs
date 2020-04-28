using System;
using System.Net;
using System.Net.Mail;

namespace ProjectPractice.SendMail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            MailAddress Messagefrom = new MailAddress("2020554040@qq.com", "尘土");  //发件人邮箱地址
            string MessageTo = "18138900@qq.com";  //收件人邮箱地址
            string MessageSubject = "测试发邮件";        //邮件主题
            string MessageBody = "没啥内容";    //邮件内容
            //Send(MessageTo, MessageSubject, MessageBody, Messagefrom);

            
            MailMessage email = new MailMessage();
            email.From = Messagefrom;
            email.To.Add(MessageTo);//收件人邮箱地址可以是多个以实现群发
            email.To.Add("137814643@qq.com"); //第二个收件人
            email.Subject = MessageSubject;
            email.Body = MessageBody;
            email.IsBodyHtml = false; //是否为html格式 
            email.Priority = MailPriority.Normal;  //发送邮件的优先等级
            email.Attachments.Add(new Attachment(@"C:\Users\Administrator\Desktop\奖励计算表.xlsx") { Name = "奖励计算表" }); //发送附件
            SmtpClient sc = new SmtpClient();
            sc.Host = "SMTP.qq.com";              //指定发送邮件的服务器地址或IP
            sc.Port = 25;//指定发送邮件端口
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;//指定如何发送电子邮件
            sc.UseDefaultCredentials = true;//是否随请求一起发送
            sc.EnableSsl = true;//安全连接设置

            //QQ批量发邮件必须要授权码，不是QQ的登录密码  fttsramppefhdbji
            sc.Credentials = new System.Net.NetworkCredential("2020554040@qq.com", "fttsramppefhdbji"); //指定登录服务器的用户名和密码
            sc.Send(email);

        }
    }
}
