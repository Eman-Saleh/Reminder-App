//using Microsoft.AspNet.SignalR;
//using Microsoft.Extensions.Logging;
//using Quartz;
//using Quartz.Impl;
//using Reminder.DB.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;

//namespace Reminder.BE.Repositories
//{
//    [DisallowConcurrentExecution]

//    public class EmanEmailJob : IJob
//    {
//        private readonly ILogger<EmanEmailJob> _logger;
      

//        public EmanEmailJob(ILogger<EmanEmailJob> logger,
//            IHubContext<JobsHub> hubContext)
//        {
//            _logger = logger;
//        }

//        public async Task Execute(IJobExecutionContext context)
//        {
//            try
//            {

//              //_logger.LogInformation("Hello world!");

//            Console.WriteLine($"Job 1 zaman dilim {DateTime.Now:U}");

//            //using (var message = new MailMessage("remasshaitham@gmail.com", "emansothman13@gmail.com"))
//            //{
//            //    message.Subject = "Message Subject test";
//            //    message.Body = "Message body test at " + DateTime.Now;
//            //    using (SmtpClient client = new SmtpClient
//            //    {
//            //        EnableSsl = true,
//            //        Host = "smtp.gmail.com",
//            //        Port = 587,
//            //        Credentials = new NetworkCredential("eng.esaleh@gmail.com", "Pow#07er")
//            //    })
//            //    {
//            //        client.Send(message);
//            //    }
//            //}
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("EEEE", ex.Message);
//            }
         
//           // return Task.CompletedTask;

//        }
  
//    }

//}