<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="Score_Search.aspx.cs" Inherits="Analyse_Score" %>
<%@ Register src="Control2.ascx" tagname="Control" tagprefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCTop" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
    <uc2:Control ID="control" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    
    <!--查询下拉列表-->
    <div style="border: 3px double #006600; position:absolute; top: 34px; left: 0px; background-color:#FFFFFF; color: #000000;">
        <asp:Label ID="Label2" runat="server" Text="班级:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_class" runat="server" Font-Size="medium">
        </asp:DropDownList>
        &nbsp;
        <asp:Label ID="Label3" runat="server" Text="语文:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_yu" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_yu" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label4" runat="server" Text="数学:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_shu" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_shu" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label5" runat="server" Text="英语:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_ying" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_ying" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label6" runat="server" Text="物理:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_wu" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_wu" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label7" runat="server" Text="化学:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_hua" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_hua" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <br />
        <asp:Label ID="Label8" runat="server" Text="生物:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_sheng" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_sheng" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label9" runat="server" Text="自选:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_zixuan" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_zixuan" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label10" runat="server" Text="总分:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_total" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_total" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label11" runat="server" Text="排名:" Font-Size="medium"></asp:Label>
        <asp:DropDownList ID="ddl_MC" runat="server" Font-Size="medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="&gt;=">&gt;=</asp:ListItem>
            <asp:ListItem Value="&lt;">&lt;</asp:ListItem>
            <asp:ListItem Value="=">=</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="txtbox_MC" runat="server"  Font-Size="medium" Width="30px"></asp:TextBox>
        &nbsp;
        <asp:Label ID="Label12" runat="server" Text="学生姓名:" Font-Size="medium"></asp:Label>
        <asp:TextBox ID="txtbox_stuname" runat="server" Font-Size="medium" Width="70px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_Search" runat="server" Text="查询" Font-Size="medium" onclick="btn_Search_Click"/>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btn_Search" EventName="Click"/>
            <asp:AsyncPostBackTrigger ControlID="AspNetPager1" EventName="PageChanged"/>
        </Triggers>
        <ContentTemplate>
            <!--GridView-->
            <!--BoundField：简单的绑定数据，方便快捷;TemplateField：除了绑定数据外，还可以设置控件、复杂的样式。-->
              <!--DataNavigateUrlFields="id"  (这里是你要传值的字段) 
DataNavigateUrlFormatString="default2.aspx?id={0}"   (这里通过id传值到页面default2页面上，在default2.aspx.cs上取出id再做详细处理)-->
            <div style="position: absolute; top: 97px; left: 0px;">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" oninit="GridView1_Init" Width="1000px" 
                onrowdatabound="GridView1_RowDataBound" AutoGenerateColumns="False" 
                    AllowSorting="True" onsorting="GridView1_Sorting">
                <Columns>
                    <asp:BoundField DataField="class" HeaderText="班级"/>                             
                    <asp:BoundField DataField="stunum" HeaderText="学号"/>
                  
                    <asp:HyperLinkField DataTextField="stuname" HeaderText= "姓名" 
                    DataNavigateUrlFields="class,stunum" DataNavigateUrlFormatString="Score_Analyse_li.aspx?class={0}&stunum={1}"
                         Target="_blank" ControlStyle-ForeColor="#0033CC" > 
                    <ControlStyle ForeColor="#0033CC" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="xueji" HeaderText="学籍" />
                    <asp:BoundField DataField="yu" HeaderText="语文" SortExpression="yu" />
                    <asp:BoundField DataField="shu" HeaderText="数学" SortExpression="shu" />
                    <asp:BoundField DataField="ying" HeaderText="英语" SortExpression="ying" />
                    <asp:BoundField DataField="wu" HeaderText="物理" SortExpression="wu" />
                    <asp:BoundField DataField="hua" HeaderText="化学" SortExpression="hua" />
                    <asp:BoundField DataField="sheng" HeaderText="生物" SortExpression="sheng" />
                    <asp:BoundField DataField="zixuan" HeaderText="自选模块" SortExpression="zixuan" />
                    <asp:BoundField DataField="total" HeaderText="总分" SortExpression="total" />
                    <asp:BoundField DataField="MC" HeaderText="排名" SortExpression="MC" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="Black" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
            </asp:GridView>
             </div>
    
            <!--AspNetPager分页控件-->
            <div style="position:absolute; top: 450px; left: 3px; width: 687px;" >
                  <webdiyer:aspnetpager ID="AspNetPager1" runat="server"
                 onpagechanged="AspNetPager1_PageChanged" CssClass="anpager"
                 CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页"
                 NextPageText="后页" PrevPageText="前页" AlwaysShow="True" 
                      Font-Bold="True" Font-Size="XX-Large" Font-Underline="False" PageSize="14">
                 </webdiyer:aspnetpager>  
            </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <!--Excel文件导入导出-->
    <div style="position: absolute; top: 495px; left: 4px;">
        <asp:Label ID="Label1" runat="server" Text="批量导出：" Font-Size="Medium"></asp:Label>
        <asp:Button ID="btnExcel" runat="server" Text="导出Excel文件" onclick="btnExcelOut_Click" Font-Size="Medium"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblExcelIn" runat="server" Text="批量导入：" Font-Size="Medium"></asp:Label>
        <asp:FileUpload ID="fuExcel" runat="server" Font-Size="Medium" Width="220px"/>
        <asp:Button ID="btnOk" runat="server" Text="确认文件" Font-Size="Medium" onclick="btnOk_Click"/>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>    
    </div>
</asp:Content>

