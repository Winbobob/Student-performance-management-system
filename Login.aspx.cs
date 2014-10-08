using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Web.Security;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //登陆验证，e.Authenticated,da的判断有问题

    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        

        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from users where userName = '" + Login1.UserName + "' and password = '" + Login1.Password + "'";
       /* StringBuilder strSql=new StringBuilder();
        strSql.Append("select count @n from users where ");
        strSql.Append("userName = @username and ");
        strSql.Append("password = @password");
        OleDbParameter[] parameters = {
            new OleDbParameter("@userName", OleDbType.VarChar,255),
            new OleDbParameter("@password", OleDbType.VarChar,255)
        };
        parameters[0].Value = Login1.UserName;
        parameters[1].Value = Login1.Password;
        int n = new int();
        n = (int)cmd.ExecuteScalar();
        //da = new OleDbDataAdapter(cmd);
        //da.Fill(dt);*/
        Session["Login"] = Login1.UserName;
        object obj = cmd.ExecuteScalar();
        con.Close();

        if (obj != null)
        {
            e.Authenticated = true;
        }
        else
        {
            e.Authenticated = false;
        }
        
        if (e.Authenticated)
        {
            Response.Redirect("cover.aspx");
        }
    }
}


 