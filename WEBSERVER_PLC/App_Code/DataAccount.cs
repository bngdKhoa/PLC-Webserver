using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class DataAccount
{
    public String ConnectionString; /* cung cấp đối số đầu vào cho hàm GetData*/
    public DataAccount(String ConnectionString) /* đối số đầu vào của hàm khởi tạo DataAccount, đc gán từ đối tượng ở Web.config */
    {
        this.ConnectionString = ConnectionString;
    }

    //Lay du lieu trong database
    public DataTable CheckAccount(String TaiKhoan, String MatKhau)
    {
        string strSQL = "select * from DangNhap where Username = '" + TaiKhoan + "' AND Password = '" + MatKhau + "'";
        return GetData(strSQL, ConnectionString); // Gọi hàm GetData với hai đối số, một là câu query, hai là biến connectionString
    }
    public System.Data.DataTable GetData(string selectCommand, string connectionString)
    {
        try
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

            System.Data.DataTable table = new System.Data.DataTable();

            table.Locale = System.Globalization.CultureInfo.InvariantCulture;

            dataAdapter.Fill(table);
            return table;

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


}