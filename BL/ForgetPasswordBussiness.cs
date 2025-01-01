using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DL;
using Microsoft.IdentityModel.Tokens;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BL
{
    public class ForgetPasswordBusiness
    {
        private readonly ForgetPasswordData _data;

        public ForgetPasswordBusiness()
        {
            _data = new ForgetPasswordData();
        }

        public async Task<bool> SendResetPasswordEmail(string email)
        {
            // Lấy số điện thoại từ email
            var phoneNumber = _data.GetPhoneNumberByEmail(email);

            // Kiểm tra email có trong hệ thống hay không
            if (string.IsNullOrEmpty(phoneNumber))
                throw new Exception("Email không tồn tại trong hệ thống.");

            // Gửi email qua SendGrid
            string apiKey = "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"; // Thay bằng API Key của bạn
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("hoangtang010191@gmail.com", "Your Application");
            var to = new EmailAddress(email);
            var subject = "Password Recovery";
            var plainTextContent = $"Your registered phone number is: {phoneNumber}";
            var htmlContent = $"<strong>Your registered phone number is: {phoneNumber}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            try
            {
                var response = await client.SendEmailAsync(msg);
                if (!response.IsSuccessStatusCode)
                {
                    // Đọc nội dung phản hồi từ SendGrid
                    var responseBody = await response.Body.ReadAsStringAsync();
                    throw new Exception($"Gửi email thất bại: {response.StatusCode} - {responseBody}");
                }
                return true; // Gửi email thành công
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi gửi email: {ex.Message}");
            }
        }
    }
}
