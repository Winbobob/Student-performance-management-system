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

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 柱形图1
            //标题
            Title title = new Title();
            title.Text = "重点率";
            title.Font = new Font("宋体", 16f, FontStyle.Bold);
            Chart1.Titles.Add(title);
             
             Chart1.DataSource = CreatData();//绑定数据
             Chart1.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;//设置图表类型:柱形图
             Chart1.Series[0].XValueMember = "years";//X轴数据成员列
             Chart1.Series[0].YValueMembers = "rate";//Y轴数据成员列
             Chart1.ChartAreas["ChartArea1"].AxisX.Title = "年份";//X轴标题
             Chart1.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMaxFontSize = 13;//X轴刻度大小
             //Chart1.ChartAreas["ChartArea1"].AxisX.ArrowStyle = AxisArrowStyle.Triangle; //X轴箭头 
             Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("宋体", 13f);
             Chart1.ChartAreas["ChartArea1"].AxisX.LineColor = Color.DarkRed;//X轴颜色
             Chart1.ChartAreas["ChartArea1"].AxisX.LineWidth = 3;//X轴颜色
             Chart1.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;//X轴数据的间距
             Chart1.ChartAreas["ChartArea1"].AxisY.Maximum = 1.1;//X轴数据的间距

             Chart1.ChartAreas["ChartArea1"].AxisY.Title = "重点率";//Y轴标题
             Chart1.ChartAreas["ChartArea1"].AxisY.LabelAutoFitMaxFontSize = 13;//X轴刻度大小
             Chart1.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "0%";//格式化，为了显示百分号
             Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("宋体", 13f);
             Chart1.ChartAreas["ChartArea1"].AxisY.LineColor = Color.DarkRed;//X轴颜色
             Chart1.ChartAreas["ChartArea1"].AxisY.LineWidth = 3;//X轴颜色
             Chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart1.ChartAreas["ChartArea1"].AxisY.Interval = 0.5;//Y轴数据的间距

             Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;//不显示横着的分割线
             Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
             Chart1.Series[0].IsValueShownAsLabel = true;//显示坐标值
             Chart1.Series[0].LabelFormat = "0.0%";//格式化，为了显示百分号
             Chart1.Series[0].Font = new Font("Times New Rome", 11f);//标签的字体设置
             Chart1.Series[0].LabelForeColor = Color.DarkRed;//标签的字体设置
        #endregion

        #region 折线图
            /* //标题
             Chart2.Titles.Add(title);

             Chart2.DataSource = CreatData();//绑定数据
             Chart2.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;//设置图表类型:柱形图
             Chart2.Series[0].XValueMember = "years";//X轴数据成员列
             Chart2.Series[0].YValueMembers = "rate";//Y轴数据成员列
             Chart2.ChartAreas["ChartArea1"].AxisX.Title = "年份";//X轴标题
             Chart2.ChartAreas["ChartArea1"].AxisX.ArrowStyle = AxisArrowStyle.Triangle; //X轴箭头
            
             Chart2.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart2.ChartAreas["ChartArea1"].AxisY.Title = "重点率";//Y轴标题
             Chart2.ChartAreas["ChartArea1"].AxisY.LabelStyle.Format = "0%";//格式化，为了显示百分号
             Chart2.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1;//X轴数据的间距
             Chart2.ChartAreas["ChartArea1"].AxisY.Interval = 0.5;//Y轴数据的间距
             Chart2.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;//不显示横着的分割线
             Chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
             Chart2.Series[0].IsValueShownAsLabel = true;//显示坐标值
             Chart2.Series[0].LabelFormat = "0.0%";//格式化，为了显示百分号 */
         #endregion

        #region 柱形图2
             //标题
             Title title2 = new Title();
             title2.Text = "全省前100名文理合计人数";
             title2.Font = new Font("宋体", 16f, FontStyle.Bold);
             Chart3.Titles.Add(title2);
                  
             Chart3.DataSource = CreatData();//绑定数据
             Chart3.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;//设置图表类型:柱形图
             Chart3.Series[0].XValueMember = "years";//X轴数据成员列
             Chart3.Series[0].YValueMembers = "qian100_total";//Y轴数据成员列
             Chart3.ChartAreas["ChartArea1"].AxisX.Title = "年份";//X轴标题
             Chart3.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMaxFontSize = 13;//X轴刻度大小
             //Chart3.ChartAreas["ChartArea1"].AxisX.ArrowStyle = AxisArrowStyle.Triangle; //X轴箭头 
             Chart3.ChartAreas["ChartArea1"].AxisX.LineColor = Color.DarkRed;//X轴颜色
             Chart3.ChartAreas["ChartArea1"].AxisX.LineWidth = 3;//X轴颜色
             Chart3.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("宋体", 13f);
             Chart3.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart3.ChartAreas["ChartArea1"].AxisX.Interval = 1;//X轴数据的间距
                  
             Chart3.ChartAreas["ChartArea1"].AxisY.Title = "人数";//Y轴标题
             Chart3.ChartAreas["ChartArea1"].AxisY.LabelAutoFitMaxFontSize = 13;//X轴刻度大小
             Chart3.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("宋体", 13f);
             Chart3.ChartAreas["ChartArea1"].AxisY.LineColor = Color.DarkRed;//X轴颜色
             Chart3.ChartAreas["ChartArea1"].AxisY.LineWidth = 3;//X轴颜色
             Chart3.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart3.ChartAreas["ChartArea1"].AxisY.Interval = 5;//Y轴数据的间距
                  
             Chart3.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;//不显示横着的分割线
             Chart3.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
             Chart3.Series[0].IsValueShownAsLabel = true;//显示坐标值
             Chart3.Series[0].Font = new Font("Times New Rome", 13f);//标签的字体设置
             Chart3.Series[0].LabelForeColor = Color.DarkRed;//标签的字体设置
             #endregion

        #region 柱形图3
             //标题
             Title title3 = new Title();
             title3.Text = "理科全省前100名人数";
             title3.Font = new Font("宋体", 16f, FontStyle.Bold);
             Chart4.Titles.Add(title3);
                  
             Chart4.DataSource = CreatData();//绑定数据
             Chart4.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;//设置图表类型:柱形图
             Chart4.Series[0].XValueMember = "years";//X轴数据成员列
             Chart4.Series[0].YValueMembers = "qian100_li";//Y轴数据成员列
             Chart4.ChartAreas["ChartArea1"].AxisX.Title = "年份";//X轴标题
             Chart4.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMaxFontSize = 13;//X轴刻度大小
             //Chart4.ChartAreas["ChartArea1"].AxisX.ArrowStyle = AxisArrowStyle.Triangle; //X轴箭头 
             Chart4.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("宋体", 13f);
             Chart4.ChartAreas["ChartArea1"].AxisX.LineColor = Color.DarkRed;//X轴颜色
             Chart4.ChartAreas["ChartArea1"].AxisX.LineWidth = 3;//X轴颜色
             Chart4.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart4.ChartAreas["ChartArea1"].AxisX.Interval = 1;//X轴数据的间距
                  
             Chart4.ChartAreas["ChartArea1"].AxisY.Title = "人数";//Y轴标题
             Chart4.ChartAreas["ChartArea1"].AxisY.LabelAutoFitMaxFontSize = 12;//X轴刻度大小
             Chart4.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("宋体", 13f);
             Chart4.ChartAreas["ChartArea1"].AxisY.LineColor = Color.DarkRed;//X轴颜色
             Chart4.ChartAreas["ChartArea1"].AxisY.LineWidth = 3;//X轴颜色
             Chart4.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart4.ChartAreas["ChartArea1"].AxisY.Interval = 5;//Y轴数据的间距
                  
             Chart4.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;//不显示横着的分割线
             Chart4.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
             Chart4.Series[0].IsValueShownAsLabel = true;//显示坐标值
             Chart4.Series[0].Font = new Font("Times New Rome", 13f);//标签的字体设置
             Chart4.Series[0].LabelForeColor = Color.DarkRed;//标签的字体设置
             #endregion

        #region 柱形图4
             //标题
             Title title4 = new Title();
             title4.Text = "文科全省前100名人数";
             title4.Font = new Font("宋体", 16f, FontStyle.Bold);
             Chart5.Titles.Add(title4);
                  
             Chart5.DataSource = CreatData();//绑定数据
             Chart5.Series["Series1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;//设置图表类型:柱形图
             Chart5.Series[0].XValueMember = "years";//X轴数据成员列
             Chart5.Series[0].YValueMembers = "qian100_wen";//Y轴数据成员列
             Chart5.ChartAreas["ChartArea1"].AxisX.Title = "年份";//X轴标题
             Chart5.ChartAreas["ChartArea1"].AxisX.LabelAutoFitMaxFontSize = 13;//X轴刻度大小
             Chart5.ChartAreas["ChartArea1"].AxisX.LineColor = Color.DarkRed;//X轴颜色
             Chart5.ChartAreas["ChartArea1"].AxisX.LineWidth = 3;//X轴颜色
            // Chart5.ChartAreas["ChartArea1"].AxisX.ArrowStyle = AxisArrowStyle.Triangle; //X轴箭头 
              
             Chart5.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("宋体", 13f);
             Chart5.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart5.ChartAreas["ChartArea1"].AxisX.Interval = 1;//X轴数据的间距
                  
             Chart5.ChartAreas["ChartArea1"].AxisY.Title = "人数";//Y轴标题
             Chart5.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("宋体", 13f);
             Chart5.ChartAreas["ChartArea1"].AxisY.LabelAutoFitMaxFontSize = 12;//X轴刻度大小
             Chart5.ChartAreas["ChartArea1"].AxisY.LineColor = Color.DarkRed;//X轴颜色
             Chart5.ChartAreas["ChartArea1"].AxisY.LineWidth = 3;//X轴颜色
             Chart5.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;//设置Y轴标题的名称所在位置位远
             Chart5.ChartAreas["ChartArea1"].AxisY.Interval = 2;//Y轴数据的间距
                  
             Chart5.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;//不显示横着的分割线
             Chart5.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
             Chart5.Series[0].IsValueShownAsLabel = true;//显示标签
             Chart5.Series[0].Font = new Font("Times New Rome", 13f);//标签的字体设置
             Chart5.Series[0].LabelForeColor = Color.DarkRed;//标签的字体设置


             #endregion
    }

         /// <summary>
         /// 创建一张二维数据表
         /// </summary>
         /// <returns>Datatable类型的数据表</returns>
         private DataTable CreatData()
         {
             OleDbConnection con = new OleDbConnection();
             OleDbCommand cmd = new OleDbCommand();
             OleDbDataAdapter da = new OleDbDataAdapter();

             DataTable dt = new DataTable();
             con.ConnectionString = "provider=Microsoft.ACE.OLEDB.12.0;data source=" + Server.MapPath("app_data/gaokao.accdb");
             con.Open();
             cmd.Connection = con;
             cmd.CommandText = "select * from gaokaoxinxi";
             da = new OleDbDataAdapter(cmd);
             da.Fill(dt);

 
             /*string[] n = new string[] { "C#", "Java", "Object-C" };
             string[] c = new string[] { "30", "50", "35" };
 
             for (int i = 0; i < 3; i++)
             {           
                 DataRow dr = dt.NewRow();
                 dr["Language"] = n[i];
                 dr["Count"] = c[i];
                 dt.Rows.Add(dr);
             }*/
             con.Close();
             return dt;
         }
}