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

public partial class SortChart : System.Web.UI.Page
{
    public string classes = "1";//网页链接的传值字符串1
    public string stunum = "1";//网页链接的传值字符串2
    public string xueke = "语文";//网页链接的传值字符串3
    public string xueke_en = "yu";
    public string stuname = null;
    public string score = null;
    public int classRank = 0;//班级排名
    public int gradeRank = 0;//年级排名
    public int numClass = 0;//班级学生总人数
    public int numGrade = 0;//年级学生总人数
    public double classTotal = 0;//班级单科总分
    public double gradeTotal = 0;//年级单科总分
    public double classAve = 0;//班级单科平均分
    public double gradeAve = 0;//年级单科平均分

    Dictionary<string, string> myDic = new Dictionary<string, string>();
    OleDbConnection con = new OleDbConnection();
    OleDbCommand cmd = new OleDbCommand();
    OleDbDataAdapter da = new OleDbDataAdapter();
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["class"] != null && Request.QueryString["stunum"].ToString() != null && Request.QueryString["xueke"].ToString() != null)
        {
            classes = Request.QueryString["class"].ToString();
            stunum = Request.QueryString["stunum"].ToString();
            xueke = Request.QueryString["xueke"].ToString();
        }

        myDic.Add("语文","yu");
        myDic.Add("数学", "shu");
        myDic.Add("英语", "ying");
        myDic.Add("物理", "wu");
        myDic.Add("化学", "hua");
        myDic.Add("生物", "sheng");
        myDic.Add("自选", "zixuan");
        string value = null;
        //根据键获得值
        if (myDic.TryGetValue(xueke, out value))
        {
            xueke_en = value;
        }

        //前台Chart中需加上RenderType和ImageType属性
        //<!---RenderType 获取或设置用于显示图表图像的呈现方法。和ImageType属性配合使用。-->
        //<!---http://blog.csdn.net/winbobob/article/details/24347519-->

        //!!javascript必须用二进制流的形式显示图片，所以只能投机取巧，用chart的标题显示类似表格的信息，而图表本身为空
        CreatData(classes, stunum, xueke_en);
        //标题
        Title title0 = new Title();
        title0.Text = stuname;
        title0.Font = new Font("宋体", 13f, FontStyle.Bold);
        Chart1.Titles.Add(title0);

        Title title = new Title();
        title.Text = xueke+ "成绩为：" + score;
        title.Font = new Font("宋体", 13f, FontStyle.Bold);
        Chart1.Titles.Add(title);

        Title title2 = new Title();
        title2.Text = "全班排名为：" + classRank;
        title2.Font = new Font("宋体", 13f, FontStyle.Bold);
        Chart1.Titles.Add(title2);

        Title title4 = new Title();
        title4.Text = "全校排名为：" + gradeRank;
        title4.Font = new Font("宋体", 13f, FontStyle.Bold);
        Chart1.Titles.Add(title4);

        Title title3 = new Title();
        title3.Text = "全班平均分为：" + classAve.ToString("0.0");
        title3.Font = new Font("宋体", 13f, FontStyle.Bold);
        Chart1.Titles.Add(title3);

        Title title5 = new Title();
        title5.Text = "全校平均分为：" + gradeAve.ToString("0.0");
        title5.Font = new Font("宋体", 13f, FontStyle.Bold);
        Chart1.Titles.Add(title5);

    }

    private void CreatData(string classes, string stunum, string xueke)
    {
        con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
        con.Open();
        cmd.Connection = con;
        cmd.CommandText = "select * from exam_li01 where class = '" + classes + "' and stunum = " + stunum;
        da = new OleDbDataAdapter(cmd);
        dt = new DataTable();//如果不重新定义一个DataTable，会出现数据读取混乱
        da.Fill(dt);
        score = dt.Rows[0][xueke].ToString();//得到学生该门课的成绩
        stuname = dt.Rows[0]["stuname"].ToString();//得到学生的姓名

        cmd.CommandText = "select count(*) from exam_li01 where " + xueke + " > " + score;
        da = new OleDbDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        gradeRank = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;//得到学生该门课的成绩的年级排名

        cmd.CommandText = "select count(*) from exam_li01 where " + xueke + " > " + score + " and class = '" + classes + "'";
        da = new OleDbDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        classRank = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;//得到学生该门课的成绩的班级排名

        cmd.CommandText = "select count(*) from exam_li01 where class = '" + classes + "' and total > 0";
        da = new OleDbDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        numClass = Convert.ToInt32(dt.Rows[0][0].ToString());//得到班级学生总人数

        cmd.CommandText = "select sum(" + xueke_en + ") from exam_li01 where class = '" + classes + "'";
        da = new OleDbDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        classTotal = Convert.ToDouble(dt.Rows[0][0].ToString());//得到班级单科总分
        classAve = classTotal / numClass;//得到班级单科平均分

        cmd.CommandText = "select count(*) from exam_li01 where total > 0";
        da = new OleDbDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        numGrade = Convert.ToInt32(dt.Rows[0][0].ToString());//得到年级学生总人数

        cmd.CommandText = "select sum(" + xueke_en + ") from exam_li01";
        da = new OleDbDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        gradeTotal = Convert.ToDouble(dt.Rows[0][0].ToString());//得到年级单科总分
        gradeAve = gradeTotal / numGrade;//得到年级单科平均分

        con.Close();
    }
}