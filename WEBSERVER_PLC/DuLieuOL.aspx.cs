using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    SQL _sql; //khai báo một biến toàn cục của class SQL, sử dụng cho cả hàm Page_Load và hàm HienThiGiaTriCamBien
    protected void Page_Load(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConStr"].ToString(); //kết nối đến câu truy xuất đến SQL server để lưu vào biến connectionString
        _sql = new SQL(connectionString); //khởi tạo mới một đối tượng sql cho biến _sql

        HienThiGiaTriCamBienMoiNhat();
    }

    void HienThiGiaTriCamBienMoiNhat()
    {
        //Literal_HienThiGiaTriCamBien.Text = 
        //    "<table>"+
        //        "<tr>"+
        //            "<th>Mã cảm biến</th>"+
        //            "<th>Giá trị cảm biến</th>"+
        //            "<th>Thời điểm</th>"+
        //        "</tr>"+
        //        "<tr>"+
        //            "<td>CB_PH</td>"+
        //            "<td>6</td>"+
        //            "<td>2024-01-15 10:30:00</td>"+
        //        "</tr>"+
        //        "<tr>"+
        //           "<td>CB_CDAS</td>"+
        //            "<td>6</td>"+
        //            "<td>2024-01-15 10:50:00</td>"+
        //        "</tr>"+
        //    "</table>";

        string html1 =
            "<!DOCTYPE html>" +
             "<html>" +
             "<style>" +
             "table, th, td " +
             "{  border:2px solid black;}" +
             "</style>" +
             "<body>" +

            "<table style=\"width:100%\">" +
                "<tr>" +
                    "<th>Mã cảm biến</th>" +
                    "<th>Tên cảm biến</th>" +
                    "<th>Giá trị cảm biến</th>" +
                    "<th>Thời điểm</th>" +
                "</tr>";

        string html2 = "";
        DataTable cb = _sql.GetSenSorLastest(); //gọi hàm GetSensorLastest trả về dữ liệu trong bảng cb
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

        Literal3.Text = html1 + html2 + html3;

    }


    protected void Timer1_Tick(object sender, EventArgs e) // hàm sự kiện
    {
        HienThiGiaTriCamBienMoiNhat();
    }
}