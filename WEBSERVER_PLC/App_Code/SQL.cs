using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SQL
/// </summary>
public class SQL
{
    public string connectionString; /* cung cấp đối số đầu vào cho hàm GetData*/
    public SQL(string connectionString) /* đối số đầu vào của hàm khởi tạo sql, đc gán từ đối tượng ở Web.config */
    {
        this.connectionString = connectionString;
    }

    //Lay tat ca du lieu trong database
    public DataTable GetSenSor(string SensorID)
    {
        string strSQL;
        if (SensorID == "*")
        {
            strSQL = "select * from Sensor_CB order by SensorID, LastUpdate desc ";
        }
        else
        {
            strSQL = "select * from Sensor_CB where SensorID='" + SensorID + "'order by SensorID, LastUpdate desc ";
        }  
        
        return GetData(strSQL, connectionString); // Gọi hàm GetData với hai đối số, một là câu query, hai là biến connectionString
    }

    //Lấy dữ liệu mới nhất của mỗi cảm biến trong database
    public DataTable GetSenSorLastest()
    {
        string strSQL = "select top 6 * from Sensor_CB order by LastUpdate desc ";

        return GetData(strSQL, connectionString);
    }

    //Lấy dữ liệu trong khoảng thời gian mong muốn từ database
    public DataTable GetSenSor(
        string SensorID,
        string starttime,
        string endtime)
    {
        string strSQL = "select * from Sensor_CB where SensorID='" + SensorID + "' " +
            "and LastUpdate > CONVERT(datetime, '" + starttime + "', 103) " +
            "and LastUpdate < CONVERT(datetime, '" + endtime + "', 103) order by LastUpdate desc ";

        return GetData(strSQL, connectionString);
    }


    public System.Data.DataTable GetData(string selectCommand, string connectionString)
    {
        try
        {
            //Create a new data adapter based on the specified query.
            // Tạo một SqlDataAdapter mới dựa trên truy vấn được chỉ định.
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);
            // Create a command builder to generate SQL update insert, and delete
            // delete commands based on selectectCommand. There are used to
            // update the database.
            // Tạo SqlCommandBuilder để tạo các câu lệnh insert, update và delete dựa trên SqlDataAdapter.
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            // Populate a new data table and bind it to the BindingSource.
            // Tạo một DataTable mới để lưu trữ dữ liệu.
            System.Data.DataTable table = new System.Data.DataTable();

            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            // Đổ dữ liệu vào DataTable từ SqlDataAdapter.
            dataAdapter.Fill(table);

            return table;
        }
        catch (Exception ex)
        {
            // Xử lý ngoại lệ nếu có lỗi xảy ra.
            throw ex;
        }
    }
}


