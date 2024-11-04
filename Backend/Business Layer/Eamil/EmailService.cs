using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Business_Layer.Customer;
using CakeDeliveryDTO.CustomerDTOs;


public class EmailService
    {
        private static IConfigurationRoot? _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public static async Task SendEmail(int? CustomerID ,decimal totalAmount ,DateTime orderTime)
        {
            CustomerDTO customer = Customer.FindById(CustomerID);

            var email = _configuration.GetSection("Email").Value;
            var password = _configuration.GetSection("Password").Value;
            var host = _configuration.GetSection("Host").Value;
            var port = int.Parse(_configuration.GetSection("Port").Value);

            // Log for debugging
            Console.WriteLine($"Email: {email}, Password: {password}, Host: {host}, Port: {port}");

            var smptpClient = new SmtpClient(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email, password)
            };

            string subject = "Hi !! from sweet cake 😊";
            string body = $"Dear {customer.FirstName}  {customer.LastName},\n\n" +
                        "Thank you for trying our delicious cake! We truly appreciate your choice and support.\n\n" +
                        $"We are excited to let you know that your cake will be delivered on {orderTime} " +
                        "If you have any special instructions or requests, please don't hesitate to reach out to us.\n\n" +
                        "Thank you once again for choosing us. We hope you enjoy your cake!\n\n" +
                        "Best regards,\n Yasmin Muntaser \n[Sweet Cake]";
        var message = new MailMessage(email, customer.Email, subject, body);
            await smptpClient.SendMailAsync(message);
        }
    }
