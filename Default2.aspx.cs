using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Web.UI.DataVisualization.Charting;

public partial class Default2 : System.Web.UI.Page
{

    public OleDbConnection con = new OleDbConnection();
    public OleDbCommand cmd = new OleDbCommand();
    public OleDbDataAdapter da = new OleDbDataAdapter();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        xinxi.DataSource = datalistbind("全国信息学奥林匹克联赛");
        xinxi.DataBind();
        chem.DataSource = datalistbind("全国高中化学竞赛");
        chem.DataBind();
        math.DataSource = datalistbind("全国高中数学联赛");
        math.DataBind();
        physics.DataSource = datalistbind("全国高中物理竞赛");
        physics.DataBind();
    }

    private DataSet datalistbind(string names)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from shulihuaxinxi where class = '" + names +"' order by years desc";
        DataSet ds = new DataSet();
        da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    private DataSet gridviewbind(String names)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from shulihuaxinxi where class='" + names + "' order by years desc";
        DataSet ds = new DataSet();
        da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
        return ds;
    }

    protected void GridView1_Init(object sender, EventArgs e)
    {
        GridView1.DataSource = gridviewbind("全国高中数学联赛");
        GridView1.DataBind();
    }
    protected void GridView2_Init(object sender, EventArgs e)
    {
        GridView2.DataSource = gridviewbind("全国高中物理竞赛");
        GridView2.DataBind();
    }
    protected void GridView3_Init(object sender, EventArgs e)
    {
        GridView3.DataSource = gridviewbind("全国高中化学竞赛");
        GridView3.DataBind();
    }
    protected void GridView4_Init(object sender, EventArgs e)
    {
        GridView4.DataSource = gridviewbind("全国信息学奥林匹克联赛");
        GridView4.DataBind();
    }
}