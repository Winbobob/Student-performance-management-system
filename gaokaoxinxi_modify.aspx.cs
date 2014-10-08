using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Web.UI.DataVisualization.Charting;
using Wuqi.Webdiyer;

public partial class gaokaoxinxi_modify : System.Web.UI.Page
{
   public OleDbConnection con = new OleDbConnection();
   public OleDbCommand cmd = new OleDbCommand();
   public OleDbDataAdapter da = new OleDbDataAdapter();
  // public OleDbDataReader dr = new OleDbDataReader();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Login"] == null)
            { Response.Redirect("Login.aspx"); }
        }
        //调用绑定分页和GridView
        BindGridView();

    }

    protected DataSet showData()
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select years as 年份, rate as 重点率, qian100_total as 全省前一百总人数, qian100_li as 理科前一百人数, qian100_wen as 文科前一百人数 from gaokaoxinxi";
        //cmd.CommandText = "select * from gaokaoxinxi";
        DataSet ds = new DataSet();
        da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
       /*  
        GridView1.DataSource = ds;
        GridView1.DataBind(); */
        return ds;
    }

    //执行sql语句，返回影响行数
    protected int showData2(string str, params IDataParameter[] parameters)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = str;
        int num = cmd.ExecuteNonQuery();
        con.Close();
        return num;
    }

    //选择一列数据，下方的文本框出现对应数据
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string year = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");        
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from gaokaoxinxi where years = " + year ;
        //OleDbDataReader是一个局部变量，不能在pageload前面定义，应该临时定义并使用，写法如下
        OleDbDataReader dr = cmd.ExecuteReader();
        //dr提供从数据源读取数据行的只进流的方法
        //在使用 OleDbDataReader时，关联的OleDbConnection不能关闭，直到OleDbDataReader关闭后OleDbConnection才能关闭。
            dr.Read();
            txtbox_year.Text = year;
            txtbox_rate.Text = dr["rate"].ToString();
            txtbox_total.Text = dr["qian100_total"].ToString();
            txtbox_li.Text = dr["qian100_li"].ToString();
            txtbox_wen.Text = dr["qian100_wen"].ToString();
            dr.Close();
        con.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Update gaokaoxinxi Set rate = " + txtbox_rate.Text
        + ", qian100_total = " + txtbox_total.Text
        + ", qian100_li = " + txtbox_li.Text
        + ", qian100_wen = " + txtbox_wen.Text
        + " where years = " + txtbox_year.Text;
        cmd.ExecuteNonQuery();
        con.Close();
         
        //GridView1.DataSource = showData();
        //GridView1.DataBind();
        BindGridView();
        RegisterClientScriptBlock("", string.Format("<script type= 'text/javascript'> alert('成功更新1行数据！'); </script>")); 
       
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Insert Into gaokaoxinxi(years,rate,qian100_total,qian100_li,qian100_wen) Values(" + txtbox_year.Text
        + "," + txtbox_rate.Text
        + "," + txtbox_total.Text
        + "," + txtbox_li.Text
        + "," + txtbox_wen.Text + ")";
        cmd.ExecuteNonQuery();
        con.Close();
         
       // GridView1.DataSource = showData();
        //GridView1.DataBind();
        BindGridView();
        RegisterClientScriptBlock("", string.Format("<script type= 'text/javascript'> alert('成功添加1行数据！'); </script>")); 

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string year = this.GridView1.Rows[e.RowIndex].Cells[1].Text;
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Delete from gaokaoxinxi where years=" + year;
        cmd.ExecuteNonQuery();
        con.Close();
         
        //GridView1.DataSource = showData();
        //GridView1.DataBind();
        BindGridView();
        RegisterClientScriptBlock("", string.Format("<script type= 'text/javascript'> alert('成功删除1行数据！'); </script>")); 
    }

    protected void GridView1_Init(object sender, EventArgs e)
    {
        //GridView1.DataSource = showData();
       // GridView1.DataBind();
        BindGridView();
    }

    //绑定分页和GridView方法
    protected void BindGridView()
    {
        //初始化分页数据源实例
        PagedDataSource pds = new PagedDataSource();
        DataSet ds = new DataSet();
        ds = showData();

        //设置总行数
        AspNetPager1.RecordCount = ds.Tables[0].Rows.Count;
        //设置分页的数据源
        pds.DataSource = ds.Tables[0].DefaultView;
        //设置当前页
        pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
        //设置每页显示页数
        pds.PageSize = 10;
        //启用分页
        pds.AllowPaging = true;
        //设置GridView的数据源为分页数据源
        GridView1.DataSource = pds;
        //绑定GridView
        GridView1.DataBind();
    }

    //分页控件事件
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        BindGridView();
    }

    //鼠标移上去变色
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex > -1 && e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowType != DataControlRowType.Header)//鼠标在表头背景不变
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ccccff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
            }
        }
    }

    //导出Excel文件_NPOI
    protected void btnExcelOut_Click(object sender, EventArgs e)
    {
        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("yyyyMMddhhmmss");
        str = "gaokaoxinxi_" + str + ".xls";
        GridView1.AllowPaging = false;

        ExcelRender.RenderToExcel(showData().Tables[0], Context, str);
    }


    //实现Excel文件上传,并检验上传的Excel文件
    protected void btnOk_Click(object sender, EventArgs e)
    {
        Boolean fileOK = false;
        //指定路径
        String path = Server.MapPath("~/");
        //文件上传控件中如果已经包含文件
        if (fuExcel.HasFile)
        {
            //得到文件的后缀
            String fileExtension = System.IO.Path.GetExtension(fuExcel.FileName).ToLower();
            //允许的文件后缀
            String allowedExtensions = ".xls";
            // 看包含的文件是否是被允许的文件后缀
            if (fileExtension == allowedExtensions)
            {
                fileOK = true;
            }
        }

        //把文件中的数据导入数据库
        if (fileOK)
        {
            try
            {
                byte[] fileBytes = fuExcel.FileBytes;
                if (ExcelRender.HasData(new MemoryStream(fileBytes)))
                {
                    string str = "insert into gaokaoxinxi(years,rate,qian100_total,qian100_li,qian100_wen)";
                    int rowAffected = ExcelRender.RenderToDb(new MemoryStream(fileBytes), str, showData2); //showData2函数作为参数传值
                    //GridView1.DataSource = showData();
                    //GridView1.DataBind();
                    BindGridView();
                    lblMsg.Text = "<strong>成功导入数据，共：" + rowAffected.ToString() + "条</strong>";
                }
                else
                {
                    lblMsg.Text = "没有数据可用于导入";
                }
                fileBytes = null;
            }
            catch(Exception ex)
            {
                lblMsg.Text = "数据格式不正确，请参照<u>模版文件</u>" +ex.ToString();
            }
        }
        else
        {
            lblMsg.Text = "注意：只能上传 *.xls 文件!";
        }
    }

}