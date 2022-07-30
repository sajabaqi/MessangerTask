using learn.core.DTO;
using learn.core.Repository;
using learn.core.service;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace learn.infra.service
{
    public class Emailservice : IEmalservice
    {
        private readonly IEmployee_apinewrepository employee_Apinewrepository;
        private readonly IUser_repository UR;
        public Emailservice(IUser_repository UR, IEmployee_apinewrepository employee_Apinewrepository)
        {
            this.employee_Apinewrepository = employee_Apinewrepository;
            this.UR = UR;
        }

        public string BlockEmail(BlockF_dto BlockF_)
        {
            List<BlockF_dto> c = UR.BlockF(BlockF_);

            bool result = employee_Apinewrepository.Exist1(BlockF_);
            if (BlockF_.MemState == "0")
            {
                if (result == false)
                {
                    return "Email not Exist";
                }
                else if (result == true)
                {
                    for (int k = 0; k < c.Count; k++)
                    {
                        if (c[k].Email == BlockF_.Email)
                        {

                            Random r = new Random();
                            MimeMessage message = new MimeMessage();
                            BodyBuilder B = new BodyBuilder();
                            MailboxAddress From = new MailboxAddress("User", "Saja_sjsj@hotmail.com");
                            MailboxAddress to = new MailboxAddress("user", BlockF_.Email);

                            B.HtmlBody = "" + c[k].Blocker +" Blocked you" + "<br><div style=\"width: 100px;height: 100px;padding-top:15px;padding-bottom:13px;border: 2px solid pink;\"><h2 style=\"color:pink;margin-right:4px;\">Now You Not in the Group :)</h2> </div>";
                            //B.HtmlBody = "<h1>"+ c[k].Blocker + " Blocked " + c[k].Blocked;
                            message.Body = B.ToMessageBody();
                            message.From.Add(From);
                            message.To.Add(to);
                            message.Subject = "Block";
                            using (var item = new SmtpClient())
                            {
                                item.Connect("smtp.office365.com", 587, false);
                                item.Authenticate("Saja_sjsj@hotmail.com", "Saja0799");
                                item.Send(message);
                                item.Disconnect(true);
                            }
                            return "True";
                        }
                    }
                }
            }
            return "True";
        }

        public string GetEmail(Employee_newDto e)
        {
            bool result = employee_Apinewrepository.Exist(e);
            if (result == false)
            {
                return "Email not Exist";
            }
            else if (result == true)
            {
                Random r = new Random();
                e.Verfication_code = Convert.ToString(r.Next(1000, 9999));
                employee_Apinewrepository.Verify1(e);
                MimeMessage message = new MimeMessage();
                BodyBuilder B = new BodyBuilder();
                MailboxAddress From = new MailboxAddress("User", "Saja_sjsj@hotmail.com");
                MailboxAddress to = new MailboxAddress("user", e.email);

                B.HtmlBody = "<h1>" + e.Verfication_code;
                message.Body = B.ToMessageBody();
                message.From.Add(From);
                message.To.Add(to);
                message.Subject = "Checking";
                using (var item = new SmtpClient())
                {
                    item.Connect("smtp.office365.com", 587, false);
                    item.Authenticate("Saja_sjsj@hotmail.com", "Saja0799");
                    item.Send(message);
                    item.Disconnect(true);
                }
                return "True";
            }
            return "True";
        }
    }
    }
