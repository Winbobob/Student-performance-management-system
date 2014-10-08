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

public partial class Analyse_Score : System.Web.UI.Page
{
    public OleDbConnection con = new OleDbConnection();
    public OleDbCommand cmd = new OleDbCommand();
    public OleDbDataAdapter da;
    public static DataSet dsAboutExcel; //关于生成Excel文档的数据
    public static StringBuilder str = new StringBuilder();//论static的重要性
    public string classes = null;//网页链接的传值字符串1
    public string stunum = null;//网页链接的传值字符串2
    Dictionary<string, string> myDic = new Dictionary<string, string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            /* if (Session["Login"] == null)
             { Response.Redirect("Login.aspx"); } */
            BindDDL();
            dsAboutExcel = showData(str);
           
        }
        if (Request.QueryString["class"] != null && Request.QueryString["stunum"].ToString() != null)
        {
            classes = Request.QueryString["class"].ToString();
            stunum = Request.QueryString["stunum"].ToString();

        }
    }

    protected DataSet showData(StringBuilder str)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = str.ToString();

        //判断传入值为升序，降序或null
        /*if (ViewState["Field"] != null)
        {
            str.AppendFormat(" Order By {0}", ViewState["sort"]);
        }*/

        DataSet ds = new DataSet();
        da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        con.Close();
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

    //初始化Gridview，执行顺序早于Page_Load
    protected void GridView1_Init(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            str.Clear();
            str.Append("select * from exam_li01");
        }
        BindGridView(showData(str));
        ViewState["sort"] = "desc";
        ViewState["Field"] = null;

        //字典用于存储各门学科排序的键值信息<学科名称，排序顺序>
        myDic.Add("yu", "desc");
        myDic.Add("shu", "desc");
        myDic.Add("ying", "desc");
        myDic.Add("wu", "desc");
        myDic.Add("hua", "desc");
        myDic.Add("sheng", "desc");
        myDic.Add("zixuan", "desc");
        myDic.Add("total", "desc");
        myDic.Add("MC", "asc");
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
        pds.PageSize = 14;
        int pagenum = AspNetPager1.PageCount;

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
        cmd.CommandText = "select distinct class from exam_li01";
        DataSet ds = new DataSet();
        da = new OleDbDataAdapter(cmd);
        da.Fill(ds);
        ddl_class.DataSource = ds.Tables[0].DefaultView;
        ddl_class.DataTextField = "class";
        ddl_class.DataBind();
        ddl_class.Items.Insert(0, new ListItem("全部", "all"));
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

        #region 加排序的头方法
        //判断是否是表头
        if (e.Row.RowType == DataControlRowType.Header)
        {
            string [] arr = new string[]{"yu","shu","ying","wu","hua","sheng","zixuan","total","MC"};
            //判断是否进行排序
            if (ViewState["Field"] != null)
            {
                Literal li = new Literal();
                string value = null;
                int i = 0;//计数
                for(i = 0 ; i < 9; i++)
                {
                    if (arr[i] == ViewState["Field"].ToString())
                        break;
                }

                if(myDic.TryGetValue(ViewState["Field"].ToString(), out value))
                {
                    if (value == "asc")
                    {
                        li.Text = "▲";
                    }
                    else
                    {
                        li.Text = "▼";
                    }
                    e.Row.Cells[i + 4].Controls.Add(li);
                }
            }
        }
                
        #endregion 完成排序
        

    }

    //导出Excel文件_NPOI
    protected void btnExcelOut_Click(object sender, EventArgs e)
    {
        DateTime dt = System.DateTime.Now;
        string str = dt.ToString("yyyyMMddhhmmss");
        str = "chengjichaxun_" + str + ".xls";
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
                    str.Append("insert into exam_li01(class,stunum,stuname,xueji,yu,shu,ying,wu,hua,sheng,zixuan,total,MC)");
                    int rowAffected = ExcelRender.RenderToDb(new MemoryStream(fileBytes), str.ToString(), showData2); //showData2函数作为参数传值
                    BindGridView(showData(str));
                    lblMsg.Text = "<strong>成功导入数据，共：" + rowAffected.ToString() + "条</strong>";
                }
                else
                {
                    lblMsg.Text = "没有数据可用于导入";
                }
                fileBytes = null;
            }
            catch (Exception ex)
            {
                lblMsg.Text = "数据格式必须为<u>常规</u>而不是<u>数值</u>，请<u>参照模版文件</u>" + ex.ToString();
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

        string classes = ddl_class.SelectedValue;
        string yu = ddl_yu.SelectedValue;
        string shu = ddl_shu.SelectedValue;
        string ying = ddl_ying.SelectedValue;
        string wu = ddl_wu.SelectedValue;
        string hua = ddl_hua.SelectedValue;
        string sheng = ddl_sheng.SelectedValue;
        string zixuan = ddl_zixuan.SelectedValue;
        string total = ddl_total.SelectedValue;
        string MC = ddl_MC.SelectedValue;

        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        //StringBuilder str = new StringBuilder();
        str.Clear();
        str.Append("select * from exam_li01");

        if ((classes != "all") || (yu != "all") || (shu != "all") || (ying != "all") || (wu != "all") || (hua != "all") || (sheng != "all") || (zixuan != "all") || (total != "all") || (MC != "all") || (txtbox_stuname.Text != null)) { str.Append(" where"); }

        if (classes != "all") { str.AppendFormat(" class = '{0}' and", classes); }

        if (yu != "all") { str.AppendFormat(" yu {0}{1} and", yu, txtbox_yu.Text); }

        if (shu != "all") { str.AppendFormat(" shu {0}{1} and", shu, txtbox_shu.Text); }

        if (ying != "all") { str.AppendFormat(" ying {0}{1} and", ying, txtbox_ying.Text); }

        if (wu != "all") { str.AppendFormat(" wu {0}{1} and", wu, txtbox_wu.Text); }

        if (hua != "all") { str.AppendFormat(" hua {0}{1} and", hua, txtbox_hua.Text); }

        if (sheng != "all") { str.AppendFormat(" sheng {0}{1} and", sheng, txtbox_sheng.Text); }

        if (zixuan != "all") { str.AppendFormat(" zixuan {0}{1} and", zixuan, txtbox_zixuan.Text); }

        if (total != "all") { str.AppendFormat(" total {0}{1} and", total, txtbox_total.Text); }

        if (MC != "all") { str.AppendFormat(" MC {0}{1} and MC > 0 and", MC, txtbox_MC.Text); }

        if (txtbox_stuname.Text != null) { str.AppendFormat(" stuname Like '%{0}%'", txtbox_stuname.Text); }

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

    //页面排序
    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["Field"] = e.SortExpression; //根据委托事件,e.sortexpression取到name
        str.Clear();
        string value = null;
        if (myDic.TryGetValue(ViewState["Field"].ToString(), out value))
        {
            if (value == null)
            {
                str.Append("select * from exam_li01 ");
            }
            else if (value == "asc")
            {
                str.AppendFormat("select * from exam_li01 order by {0} {1}", ViewState["Field"], value);
            }
            else
            {
                str.AppendFormat("select * from exam_li01 order by {0} {1}", ViewState["Field"], value);
            } 
        }

        
        DataSet ds = new DataSet();
        ds = showData(str);
        BindGridView(ds);

    }

}
