using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TL;

namespace DL
{
    public class ForgetPasswordData
    {
        private readonly DataProvider _dataProvider;

        public ForgetPasswordData()
        {
            _dataProvider = new DataProvider();
        }

        public string GetPhoneNumberByEmail(string email)
        {
            using (var connection = _dataProvider.OpenConnection())
            {
                var query = "SELECT Phone FROM Employees WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    var result = command.ExecuteScalar();
                    return result?.ToString(); // Trả về số điện thoại hoặc null nếu không tồn tại
                }
            }
        }
    }
}

