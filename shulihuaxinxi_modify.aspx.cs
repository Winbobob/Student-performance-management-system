using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
   public OleDbDataAdapter da;
   public static DataSet dsAboutExcel; //关于生成Excel文档的数据
   public static StringBuilder str = new StringBuilder();//论static的重要性

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Login"] == null)
            { Response.Redirect("Login.aspx"); }
            BindDDL();
            //str.Append("select years as 年份, class as 竞赛名称, zhzx_num as 镇海中学人数, ningbo_num as 宁波大市人数, zhejiang_num as 浙江省人数, notes as 备注 from shulihuaxinxi");
            dsAboutExcel = showData(str);
        }
    }

    protected DataSet showData(StringBuilder str)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = str.ToString();
        //cmd.CommandText = "select * from shulihuaxinxi";
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
        string years = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
        string names = GridView1.Rows[e.NewSelectedIndex].Cells[2].Text;  
      
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");        
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from shulihuaxinxi where years = " + years + " and class = '" + names + "'";
        //OleDbDataReader是一个局部变量，不能在pageload前面定义，应该临时定义并使用，写法如下
        OleDbDataReader dr = cmd.ExecuteReader();
        //dr提供从数据源读取数据行的只进流的方法
        //在使用 OleDbDataReader时，关联的OleDbConnection不能关闭，直到OleDbDataReader关闭后OleDbConnection才能关闭。
            dr.Read();
            ddl_names.SelectedValue = names;           
            txtbox_year.Text = years;
            txtbox_zhzx.Text = dr["zhzx_num"].ToString();
            txtbox_ningbo.Text = dr["ningbo_num"].ToString();
            txtbox_zhejiang.Text = dr["zhejiang_num"].ToString();
            txtbox_note.Text = dr["notes"].ToString();
            dr.Close();
        con.Close();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string names = ddl_names.SelectedValue;
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Update shulihuaxinxi Set zhzx_num = " + txtbox_zhzx.Text
        + ", ningbo_num = " + txtbox_ningbo.Text
        + ", zhejiang_num = " + txtbox_zhejiang.Text
        + ", notes = '" + txtbox_note.Text
        + "' where years = " + txtbox_year.Text + "and class = '" + names + "'";
        cmd.ExecuteNonQuery();
        con.Close();
       
        //GridView1.DataSource = showData(str);
        //GridView1.DataBind();
        BindGridView(showData(str));
        RegisterClientScriptBlock("", string.Format("<script type= 'text/javascript'> alert('成功更新1行数据！'); </script>")); 
       
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Insert Into shulihuaxinxi(years,class,zhzx_num,ningbo_num,zhejiang_num,notes) Values(" + txtbox_year.Text
        + ",'" + ddl_names.SelectedItem.Text 
        + "'," + txtbox_zhzx.Text
        + "," + txtbox_ningbo.Text
        + "," + txtbox_zhejiang.Text
        + ",'" + txtbox_note.Text + "')";
        cmd.ExecuteNonQuery();
        con.Close();
         
        //GridView1.DataSource = showData(str);
        //GridView1.DataBind();
        BindGridView(showData(str));
        RegisterClientScriptBlock("", string.Format("<script type= 'text/javascript'> alert('成功添加1行数据！'); </script>")); 

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string years = this.GridView1.Rows[e.RowIndex].Cells[1].Text;
        string names = this.GridView1.Rows[e.RowIndex].Cells[2].Text;
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "Delete from shulihuaxinxi where years=" + years + " and class = '" + names + "'";
        cmd.ExecuteNonQuery();
        con.Close();
        
        //GridView1.DataSource = showData(str);
        //GridView1.DataBind();
        BindGridView(showData(str));
        RegisterClientScriptBlock("", string.Format("<script type= 'text/javascript'> alert('成功删除1行数据！'); </script>")); 
    }

    protected void GridView1_Init(object sender, EventArgs e)
    {
        //GridView1.DataSource = showData(str);
        //GridView1.DataBind();
        if (!IsPostBack)
        {
            str.Clear();
            str.Append("select years as 年份, class as 竞赛名称, zhzx_num as 镇海中学人数, ningbo_num as 宁波大市人数, zhejiang_num as 浙江省人数, notes as 备注 from shulihuaxinxi");
        }
        BindGridView(showData(str));
        this.GridView1.Columns[0].ItemStyle.Width = new Unit("60");
    }

    //绑定分页和GridView方法
    protected void BindGridView(DataSet dataset)
    {
        //初始化分页数据源实例
        PagedDataSource pds = new PagedDataSource();
        DataSet ds = new DataSet();
        ds = dataset;

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

    //绑定DDL控件
    protected void BindDDL()
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select distinct years from shulihuaxinxi";
        DataSet ds = new DataSet();
        da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        ddl_year.DataSource = ds.Tables[0].DefaultView;
        ddl_year.DataTextField = "years";
        ddl_year.DataBind();
        ddl_year.Items.Insert(0, new ListItem("全部", "all"));
        con.Close();
    }

    //分页控件事件
    protected void AspNetPager1_PageChanged(object src, EventArgs e)
    {
        BindGridView(showData(str));
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
        str = "shulihuaxinxi_" + str + ".xls";
        GridView1.AllowPaging = false;

        ExcelRender.RenderToExcel(dsAboutExcel.Tables[0], Context, str);
    }

    //导入Excel文件，更新数据库
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
                    str.Clear();
                    str.Append("insert into shulihuaxinxi(years,class,zhzx_num,ningbo_num,zhejiang_num,notes)");
                    int rowAffected = ExcelRender.RenderToDb(new MemoryStream(fileBytes), str.ToString(), showData2); //showData2函数作为参数传值
                    //GridView1.DataSource = showData(str);
                    //GridView1.DataBind();
                    BindGridView(showData(str));
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

    //查询数据
    protected void btn_Search_Click(object sender, EventArgs e)
    {
        cmd.CommandText = null;

        string year = ddl_year.SelectedValue;
        string c = ddl_class.SelectedValue;
        string zhzxNum = ddl_zhzxNum.SelectedValue;
        string note = ddl_note.SelectedValue;

        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        //StringBuilder str = new StringBuilder();
        str.Clear();
        str.Append("select years as 年份, class as 竞赛名称, zhzx_num as 镇海中学人数, ningbo_num as 宁波大市人数, zhejiang_num as 浙江省人数, notes as 备注 from shulihuaxinxi");

        if ((year != "all") || (c != "all") || (zhzxNum != "all") || (note != "all")) { str.Append(" where"); }

        if (year != "all") { str.AppendFormat(" years = {0} and", year); }

        if (c != "all") {  str.AppendFormat(" class = '{0}' and", c); }

        if (zhzxNum != "all") { str.AppendFormat(" zhzx_num {0} and", zhzxNum); }

        if (note != "all") { str.AppendFormat(" notes Like '%{0}%'", note); }
        
        string cmdtext = str.ToString();
        if (cmdtext.EndsWith("and")) { cmdtext = cmdtext.Remove(cmdtext.Length - 4); }

        cmd.CommandText = cmdtext;
        str.Clear();
        str.Append(cmdtext);
        DataSet ds = new DataSet();
        da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        dsAboutExcel = ds;
        con.Close();
        BindGridView(ds);
    }
}