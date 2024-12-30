using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace MyWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        SQL _sql;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Kiểm tra xem người dùng đã đăng nhập chưa
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    // Nếu đã đăng nhập, chuyển hướng đến trang chính
                    Response.Redirect("~/HtmlPage.html");
                }
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ người dùng
            string username = txtUsername.Value;
            string password = txtPassword.Value;

            // Kiểm tra thông tin đăng nhập
            if (CheckLogin(username, password))
            {
                // Nếu đúng, tạo phiên đăng nhập và chuyển hướng đến trang chính
                HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new System.Security.Principal.GenericIdentity(username), null);
                Response.Redirect("~/HtmlPage.html");
            }
            else
            {
                // Nếu sai, hiển thị thông báo lỗi
                lblMessage.Text = "Tên đăng nhập hoặc mật khẩu không đúng.";
            }
        }



            private bool CheckLogin(string username, string password)
        {
            //Chuỗi kết nối tới cơ sở dữ liệu SQL
            string connectionString = "Data Source=DESKTOP-SDR1ISI\\SQLEXPRESS;Initial Catalog=SCADA_2024;User ID=sa;Password=123";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu truy vấn SQL
                    string query = "SELECT COUNT(*) FROM DangNhap WHERE Username = @Username AND Password = @Password";

                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm các tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Thực hiện truy vấn và lấy kết quả
                        int count = (int)command.ExecuteScalar();

                        // Kiểm tra xem có bản ghi nào khớp với thông tin đăng nhập hay không
                        if (count > 0)
                        {
                            return true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu có
                    // Ví dụ: ghi log, hiển thị thông báo lỗi, v.v.
                    Response.Write("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return false;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ người dùng
            string username = txtUsername.Value;
            string password = txtPassword.Value;

            // Kiểm tra xem người dùng đã tồn tại hay chưa
            if (!UserExists(username))
            {
                // Nếu chưa tồn tại, thực hiện đăng ký
                if (RegisterUser(username, password))
                {
                    // Đăng ký thành công, hiển thị thông báo hoặc chuyển hướng đến trang khác
                    lblMessage.Text = "Đăng ký thành công!";
                }
                else
                {
                    // Đăng ký không thành công, hiển thị thông báo lỗi
                    lblMessage.Text = "Đăng ký không thành công. Vui lòng thử lại.";
                }
            }
            else
            {
                // Người dùng đã tồn tại, hiển thị thông báo lỗi
                lblMessage.Text = "Tên đăng nhập đã được sử dụng. Vui lòng chọn tên đăng nhập khác.";
            }
        }

        private bool UserExists(string username)
        {
            // Chuỗi kết nối tới cơ sở dữ liệu SQL
            string connectionString = "Data Source=DESKTOP-SDR1ISI;Initial Catalog=SCADA_2024;User ID=sa;Password=123";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu truy vấn SQL để kiểm tra xem người dùng đã tồn tại hay chưa
                    string query = "SELECT COUNT(*) FROM DangNhap WHERE Username = @Username";

                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@Username", username);

                        // Thực hiện truy vấn và lấy kết quả
                        int count = (int)command.ExecuteScalar();

                        // Kiểm tra xem có người dùng nào tồn tại hay không
                        return count > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu có
                    // Ví dụ: ghi log, hiển thị thông báo lỗi, v.v.
                    Response.Write("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return false;
        }

        private bool RegisterUser(string username, string password)
        {
            //Chuỗi kết nối tới cơ sở dữ liệu SQL
            string connectionString = "Data Source=DESKTOP-SDR1ISI\\SQLEXPRESS;Initial Catalog=SCADA_2024;User ID=sa;Password=123";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu truy vấn SQL để thêm người dùng mới
                    string insertQuery = "INSERT INTO DangNhap (Username, Password) VALUES (@Username, @Password)";

                    // Tạo đối tượng SqlCommand để thực hiện truy vấn
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Thêm các tham số cho câu truy vấn
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        // Thực hiện truy vấn và lấy số hàng đã bị ảnh hưởng (thêm mới)
                        int rowsAffected = command.ExecuteNonQuery();

                        // Kiểm tra xem đã thêm mới người dùng thành công hay không
                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý exception nếu có
                    // Ví dụ: ghi log, hiển thị thông báo lỗi, v.v.
                    Response.Write("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return false;
        }

    }

}