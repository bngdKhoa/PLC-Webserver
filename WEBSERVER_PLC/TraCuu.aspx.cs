using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    SQL _sql; //khai báo một biến toàn cục của class SQL, sử dụng cho cả hàm Page_Load và hàm HienThiGiaTriCamBien
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ToString(); //kết nối đến câu truy xuất đến SQL server để lưu vào biến connectionString
        _sql = new SQL(connectionString); //khởi tạo mới một đối tượng sql cho biến _sql

        //HienThiGiaTriCamBien();

        //HienThiGiaTriCamBien("CB_PH", "13/01/2024 12:00:00", "13/01/2024 15:00:00");
    }



    void HienThiGiaTriCamBien(
        string SensorID,
        string starttime,
        string endtime)
    {
        string html1 =
            "<!DOCTYPE html>" +
             "<html>" +
             "<style>" +
             "table, th, td " +
             "{  border:2px solid black;}" +
             "</style>" +
             "<body>" +

            "<table style=\"width: 80%; max-width: 1000px; margin-left: auto; margin-right: auto;\">" +
                "<tr>" +
                    "<th>Mã cảm biến</th>" +
                    //"<th>Tên cảm biến</th>" +
                    "<th>Giá trị cảm biến</th>" +
                    "<th>Thời điểm</th>" +
                "</tr>";

        string html2 = "";
        DataTable cb = _sql.GetSenSor(SensorID, starttime, endtime); //gọi hàm GetSensor trả về dữ liệu trong bảng cb
        for (int i = 0; i < cb.Rows.Count; i++) //đếm số dòng
        {
            string macambien = cb.Rows[i]["SensorID"].ToString(); //lấy mã cảm biến của dòng thứ i trả về kiểu chuỗi
            /*string tencambien = cb.Rows[i]["SensorName"].ToString();*/ //Lấy tên cảm biến của dòng thứ i trả về kiểu chuỗi
            double giatri = Convert.ToDouble(cb.Rows[i]["Value"]); //Lấy giá trị cảm biến của dòng thứ i ép dữ liệu về kiểu số thực
            DateTime thoigian = Convert.ToDateTime(cb.Rows[i]["LastUpdate"]); //Lấy thời gian cập nhât của dòng thứ i ép dữ liệu về kiểu datetime

            html2 +=
                "<tr>" +
                    "<td>" + macambien + "</td>" +
                    //"<td>" + tencambien + "</td>" +
                    "<td>" + giatri.ToString() + "</td>" + //trả về kiểu chuỗi để hiển thị
                    "<td>" + thoigian.ToString() + "</td>" +
                "</tr>";
            //cộng dồn các giá trị theo vòng lặp for
        }

        string html3 = "</table>"; // đóng table 

        Literal2.Text = html1 + html2 + html3;
    }


    protected void btnXem_Click(object sender, EventArgs e) //Hàm sự kiện khi nhấn btnXem
    {
        string SensorID = tbxSensorId.Text; //lấy dữ liệu từ ô SensorId truyền cho đối số SensorID
        string starttime = tbxStarttime.Text;
        string endtime = tbxEndtime.Text;
        HienThiGiaTriCamBien(SensorID, starttime, endtime); //gọi hàm hiển thị và truyền các giá trị từ textbox
    }
}