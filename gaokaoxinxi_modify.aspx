<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="gaokaoxinxi_modify.aspx.cs" Inherits="gaokaoxinxi_modify" %>
<%@ Register src="Control.ascx" tagname="Control" tagprefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCTop" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
    <uc1:Control ID="control" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <div>
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" oninit="GridView1_Init" 
                onselectedindexchanging="GridView1_SelectedIndexChanging" 
                onrowdeleting="GridView1_RowDeleting" Width="500px" 
                onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" Font-Bold="True" Font-Size="Medium" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="Black"/>
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
                <PagerStyle CssClass="GridViewPager" HorizontalAlign="Center" />
            </asp:GridView>
    </div> 

    <!--AspNetPager分页控件-->
    <div style="position: absolute; top: 306px; left: 6px; width: 491px;">
         <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
        onpagechanged="AspNetPager1_PageChanged" CssClass="anpager"
        CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页"
        NextPageText="下一页" PrevPageText="上一页" AlwaysShow="True" Font-Bold="True" 
             Font-Size="XX-Large" Font-Underline="True" ForeColor="Black">
        </webdiyer:AspNetPager>
    </div>
       

    <div style="border: 3px double #006600; position:absolute; top: 356px; left: -1px; background-color:#FFFFFF; color: #000000; font-weight: bold; font-size: x-large;">
        <asp:Label ID="lbl_year" runat="server" Text="年份:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_year" runat="server" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lbl_rate" runat="server" Text="重点率:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_rate" runat="server" Font-Size="Medium"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_total" runat="server" Text="全省前一百总人数:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_total" runat="server" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lbl_li" runat="server" Text="理科前一百人数:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_li" runat="server" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lbl_wen" runat="server" Text="文科前一百人数:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_wen" runat="server" Font-Size="Medium"></asp:TextBox>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="更新" onclick="btnUpdate_Click" Font-Size="Medium" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="添加" onclick="btnAdd_Click" Font-Size="Medium" />
        <br />
        <br />
        <asp:Label ID="lblExcelOut" runat="server" Text="批量导出：" Font-Size="Medium"></asp:Label>
        <asp:Button ID="btnExcelOut" runat="server" Text="导出Excel文件" onclick="btnExcelOut_Click" Font-Size="Medium" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblExcelIn" runat="server" Text="批量导入：" Font-Size="Medium"></asp:Label>
        <asp:FileUpload ID="fuExcel" runat="server" Font-Size="Medium" Width="220px"/>
        <asp:Button ID="btnOk" runat="server" Text="确认文件" Font-Size="Medium" onclick="btnOk_Click"/>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>

