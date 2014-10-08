using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Web.UI.DataVisualization.Charting;

public partial class Score_Analyse : System.Web.UI.Page
{
    public string classes = null;//网页链接的传值字符串1
    public string stunum = null;//网页链接的传值字符串2
    public string stuname = null;
    public string xuekeName;  
    public double score;
    OleDbConnection con = new OleDbConnection();
    OleDbCommand cmd = new OleDbCommand();
    OleDbDataAdapter da = new OleDbDataAdapter();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["class"] != null && Request.QueryString["stunum"].ToString() != null)
        {
            classes = Request.QueryString["class"].ToString();
            stunum = Request.QueryString["stunum"].ToString();
        }
        bindGridView();
        CreatData();//绑定数据
        #region 柱形图

            OleDbDataReader dr = CreatData2();
            //该语句的作用就是向图表中加入数据!!!!!!!!!!
            Chart1.Series["Series1"].Points.DataBindXY(dr, "xueke", dr, "score");

            Title title = new Title();
            title.Text = stuname + "各科成绩分析";
            title.ShadowColor = Color.Gray;
            title.ShadowOffset = 2;
            title.Font = new Font("Times New Rome", 20f, FontStyle.Bold);
            title.Alignment = ContentAlignment.TopLeft;
            title.ForeColor = Color.Black;
            Chart1.Titles.Add(title);
        #endregion

            UpdateAttrib();
    }

    /// <summary>
    /// 创建一张二维数据表
    /// </summary>
    /// <returns>Datatable类型的数据表</returns>
    private void CreatData()
    {
        //单个学生的成绩生成临时表，用于生成图表（Access不支持临时表,so先建表再删表咯）
        #region 生成新表
        cmd.CommandText = null;
        cmd.CommandText = "Drop Table temp1;";
        cmd.ExecuteNonQuery();

        cmd.CommandText = "Create Table temp1 (xueke varchar(50) NOT NULL, score decimal NOT NULL)";
        cmd.ExecuteNonQuery();

        //自定义字典
        Dictionary<string,string> myDic = new Dictionary<string,string>();
        myDic.Add("yu", "语文");
        myDic.Add("shu", "数学");
        myDic.Add("ying", "英语");
        myDic.Add("wu", "物理");
        myDic.Add("hua", "化学");
        myDic.Add("sheng", "生物");
        myDic.Add("zixuan", "自选");

        string[] xueke = { "yu", "shu", "ying", "wu", "hua", "sheng", "zixuan"};
        foreach (string item in xueke)
        {
            if (myDic.TryGetValue(item, out xuekeName))
            {
                score = Convert.ToDouble(dt.Rows[0][item].ToString());
                cmd.CommandText = " Insert Into temp1 (xueke,score) Values('" + xuekeName + "'," + score.ToString() + ")";
                cmd.ExecuteNonQuery();
            }
        }
    #endregion
        con.Close();
    }

    private OleDbDataReader CreatData2()
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from temp1";
        OleDbDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return myReader;
    }

    private DataSet CreatData3()
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from temp1";
        da = new OleDbDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    private void bindGridView()
    {
        #region 绑定Gridview
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from exam_li01";

        if (classes != null && stunum != null)
        {
            cmd.CommandText += " where class = '" + classes + "' and stunum = " + stunum;
        }
        else
        {
            cmd.CommandText += " where class = '1' and stunum = 1";
        }
        da = new OleDbDataAdapter(cmd);
        da.Fill(dt);
        Datalist1.DataSource = dt;
        Datalist1.DataBind();
        stuname = dt.Rows[0]["stuname"].ToString();
        #endregion
    }

    //JavaScript
    public void UpdateAttrib()
    {

        // Set series tooltips
        foreach (Series series in Chart1.Series)
        {
            for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
            {
                string toolTip = "";

                toolTip = "<img src=SortChart.aspx?class=" + classes + "&stunum=" + stunum + "&xueke=" + series.Points[pointIndex].AxisLabel + ">";
                series.Points[pointIndex].MapAreaAttributes = "onmouseover=\"DisplayTooltip('" + toolTip + "');\" onmouseout=\"DisplayTooltip('');\"";
               // series.Points[pointIndex].Url = "SortChart.aspx?class=" + classes + "&stunum=" + stunum + "&xueke=" + series.Points[pointIndex].AxisLabel;
            }
        }

    }
}