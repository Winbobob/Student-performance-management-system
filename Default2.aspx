<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>三线表</title>
    <link rel="icon" href="Images/Logo_Lite.png"/>
    <!-- Javascript goes in the document HEAD -->
    <script type="text/javascript">
        function altRows(id) {
            if (document.getElementsByTagName) {
                var table = document.getElementById(id);
                var rows = table.getElementsByTagName("tr");
                for (i = 0; i < rows.length; i++) {
                    if (i % 2 == 0) {
                        rows[i].className = "evenrowcolor";
                    } else {
                        rows[i].className = "oddrowcolor";
                    }
                }
            }
        }

        window.onload = function () {
            altRows('alternatecolor1');
            altRows('alternatecolor2');
            altRows('alternatecolor3');
            altRows('alternatecolor4');
        }
    </script>
    <link type="text/css" rel="stylesheet" href="Styles/tblStyle.css"/>
   
</head>
<body>
    <form id="form1" runat="server">

        <!--全国信息学奥林匹克联赛-->
        <div>
        <b>全国信息学奥林匹克联赛</b>
            <asp:DataList ID="xinxi" runat="server" RepeatDirection="Horizontal" >
    	        <ItemTemplate>
                <table class="tblStyle" cellpadding="0px" cellspacing="0px" id="alternatecolor1">
                    
    	            <tr><td><%#Eval("years") + "年"%></td></tr>
                    <tr><td><%#Eval("zhzx_num")%></td></tr>
                    <tr><td><%#Eval("ningbo_num")%></td></tr>
                    <tr><td><%#Eval("zhejiang_num")%></td></tr>
                    <tr><td><%#Eval("notes")%></td></tr>
                </table>
    	        </ItemTemplate>
    	     </asp:DataList>
        </div>
        <br />
        <!--全国高中化学竞赛-->
        <div>
        <b>全国高中化学竞赛</b>
            <asp:DataList ID="chem" runat="server" RepeatDirection="Horizontal" >
    	        <ItemTemplate>
                <table class="tblStyle" cellpadding="0px" cellspacing="0px" id="alternatecolor2">
                    
    	            <tr><td><%#Eval("years") + "年"%></td></tr>
                    <tr><td><%#Eval("zhzx_num")%></td></tr>
                    <tr><td><%#Eval("ningbo_num")%></td></tr>
                    <tr><td><%#Eval("zhejiang_num")%></td></tr>
                    <tr><td><%#Eval("notes")%></td></tr>
                </table>
    	        </ItemTemplate>
    	     </asp:DataList>
        </div>
        <br />
         <!--全国高中数学联赛-->
        <div>
        <b>全国高中数学联赛</b>
            <asp:DataList ID="math" runat="server" RepeatDirection="Horizontal" >
    	        <ItemTemplate>
                <table class="tblStyle" cellpadding="0px" cellspacing="0px" id="alternatecolor3">
                    
    	            <tr><td><%#Eval("years")+"年"%></td></tr>
                    <tr><td><%#Eval("zhzx_num")%></td></tr>
                    <tr><td><%#Eval("ningbo_num")%></td></tr>
                    <tr><td><%#Eval("zhejiang_num")%></td></tr>
                    <tr><td style="font-size: small; height: 60px;"><%#Eval("notes")%></td></tr>
                </table>
    	        </ItemTemplate>
    	     </asp:DataList>
        </div>
        <br />
         <!--全国高中物理竞赛-->
        <div>
        <b>全国高中物理竞赛</b>
            <asp:DataList ID="physics" runat="server" RepeatDirection="Horizontal" >
    	        <ItemTemplate>
                <table class="tblStyle" cellpadding="0px" cellspacing="0px" id="alternatecolor4">
                    
    	            <tr><td><%#Eval("years") + "年"%></td></tr>
                    <tr><td><%#Eval("zhzx_num")%></td></tr>
                    <tr><td><%#Eval("ningbo_num")%></td></tr>
                    <tr><td><%#Eval("zhejiang_num")%></td></tr>
                    <tr><td style="font-size: small; height: 60px;"><%#Eval("notes")%></td></tr>
                </table>
    	        </ItemTemplate>
    	     </asp:DataList>
        </div>
        <br />

        <!--全国高中数学联赛-->
        <div>
            <b>全国高中数学联赛</b>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" PageSize="5" AllowSorting="True"
                            AutoGenerateColumns="False" HeaderStyle-VerticalAlign="Middle" CellPadding="3"
                            Font-Size="Medium" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            Width="700px" oninit="GridView1_Init" GridLines="Horizontal" Height="350px" BackColor="#FFFFCC" ForeColor="#0066FF">
                <Columns>
                    <asp:BoundField DataField="years" HeaderText="年份" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px"/>                             
                    <asp:BoundField DataField="zhzx_num" HeaderText="镇中人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"/>
                    <asp:BoundField DataField="ningbo_num" HeaderText="宁波市人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="zhejiang_num" HeaderText="浙江省人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="notes" HeaderText="备注" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" />
                </Columns>
                <RowStyle BackColor="White" ForeColor="#FF6666" Font-Bold="True" Font-Size="11" Height="60px" />
                <AlternatingRowStyle BackColor="#FFFFCC" ForeColor="#0066FF" Font-Bold="True" Font-Size="11" Height="60px" />
                <SelectedRowStyle BackColor="#CCCCFF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <PagerSettings Visible="False" />
                <FooterStyle Font-Bold="True" />
                <HeaderStyle Font-Bold="False" Font-Italic="False" />
            </asp:GridView>
        </div>
        <br />
         <!--全国高中物理竞赛-->
        <div>
            <b>全国高中物理竞赛</b>
            <asp:GridView ID="GridView2" runat="server" AllowPaging="true" PageSize="5" AllowSorting="True"
                            AutoGenerateColumns="False" HeaderStyle-VerticalAlign="Middle" CellPadding="3"
                            Font-Size="Medium" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            Width="700px" GridLines="Horizontal" Height="350px" 
                BackColor="#FFFFCC" ForeColor="#0066FF" oninit="GridView2_Init">
                <Columns>
                    <asp:BoundField DataField="years" HeaderText="年份" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px"/>                             
                    <asp:BoundField DataField="zhzx_num" HeaderText="镇中人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"/>
                    <asp:BoundField DataField="ningbo_num" HeaderText="宁波市人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="zhejiang_num" HeaderText="浙江省人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="notes" HeaderText="备注" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" />
                </Columns>
                <RowStyle BackColor="White" ForeColor="#FF6666" Font-Bold="True" Font-Size="11" Height="60px" />
                <AlternatingRowStyle BackColor="#FFFFCC" ForeColor="#0066FF" Font-Bold="True" Font-Size="11" Height="60px" />
                <SelectedRowStyle BackColor="#CCCCFF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <PagerSettings Visible="False" />
                <FooterStyle Font-Bold="True" />
                <HeaderStyle Font-Bold="False" Font-Italic="False" />
            </asp:GridView>
        </div>
        <br />
         <!--全国高中化学竞赛-->
        <div>
            <b>全国高中化学竞赛</b>
            <asp:GridView ID="GridView3" runat="server" AllowPaging="true" PageSize="5" AllowSorting="True"
                            AutoGenerateColumns="False" HeaderStyle-VerticalAlign="Middle" CellPadding="3"
                            Font-Size="Medium" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            Width="700px" GridLines="Horizontal" Height="350px" 
                BackColor="#FFFFCC" ForeColor="#0066FF" oninit="GridView3_Init">
                <Columns>
                    <asp:BoundField DataField="years" HeaderText="年份" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px"/>                             
                    <asp:BoundField DataField="zhzx_num" HeaderText="镇中人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"/>
                    <asp:BoundField DataField="ningbo_num" HeaderText="宁波市人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="zhejiang_num" HeaderText="浙江省人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="notes" HeaderText="备注" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" />
                </Columns>
                <RowStyle BackColor="White" ForeColor="#FF6666" Font-Bold="True" Font-Size="11" Height="60px" />
                <AlternatingRowStyle BackColor="#FFFFCC" ForeColor="#0066FF" Font-Bold="True" Font-Size="11" Height="60px" />
                <SelectedRowStyle BackColor="#CCCCFF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <PagerSettings Visible="False" />
                <FooterStyle Font-Bold="True" />
                <HeaderStyle Font-Bold="False" Font-Italic="False" />
            </asp:GridView>
        </div>
        <br />
        <!--全国信息学奥林匹克联赛-->
        <div>
            <b>全国信息学奥林匹克联赛</b>
            <asp:GridView ID="GridView4" runat="server" AllowPaging="true" PageSize="5" AllowSorting="True"
                            AutoGenerateColumns="False" HeaderStyle-VerticalAlign="Middle" CellPadding="3"
                            Font-Size="Medium" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            Width="700px" GridLines="Horizontal" Height="350px" 
                BackColor="#FFFFCC" ForeColor="#0066FF" oninit="GridView4_Init">
                <Columns>
                    <asp:BoundField DataField="years" HeaderText="年份" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px"/>                             
                    <asp:BoundField DataField="zhzx_num" HeaderText="镇中人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px"/>
                    <asp:BoundField DataField="ningbo_num" HeaderText="宁波市人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="zhejiang_num" HeaderText="浙江省人数" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" />
                    <asp:BoundField DataField="notes" HeaderText="备注" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" />
                </Columns>
                <RowStyle BackColor="White" ForeColor="#FF6666" Font-Bold="True" Font-Size="11" Height="60px" />
                <AlternatingRowStyle BackColor="#FFFFCC" ForeColor="#0066FF" Font-Bold="True" Font-Size="11" Height="60px" />
                <SelectedRowStyle BackColor="#CCCCFF" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <PagerSettings Visible="False" />
                <FooterStyle Font-Bold="True" />
                <HeaderStyle Font-Bold="False" Font-Italic="False" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
