<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shulihuaxinxi_modify.aspx.cs" Inherits="gaokaoxinxi_modify" %>
<%@ Register src="Control.ascx" tagname="Control" tagprefix="uc1" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCTop" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
    <uc1:Control ID="control" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">
    <!--查询下拉列表-->
    <div style="border: 3px double #006600; position:absolute; top: 34px; left: 0px; background-color:#FFFFFF; color: #000000;">
        <asp:Label ID="Label2" runat="server" Text="年份:" Font-Size="Medium"></asp:Label>
        <asp:DropDownList ID="ddl_year" runat="server" Font-Size="Medium">
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Text="竞赛分类:" Font-Size="Medium"></asp:Label>
        <asp:DropDownList ID="ddl_class" runat="server" Font-Size="Medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="全国信息学奥林匹克联赛">全国信息学奥林匹克联赛</asp:ListItem>
            <asp:ListItem Value="全国高中数学联赛">全国高中数学联赛</asp:ListItem>
            <asp:ListItem Value="全国高中物理竞赛">全国高中物理竞赛</asp:ListItem>
            <asp:ListItem Value="全国高中化学竞赛">全国高中化学竞赛</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Text="镇中获奖人数:" Font-Size="Medium"></asp:Label>
        <asp:DropDownList ID="ddl_zhzxNum" runat="server" Font-Size="Medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem>&lt;5</asp:ListItem>
            <asp:ListItem>&gt;=5</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Text="备注:" Font-Size="Medium"></asp:Label>
        <asp:DropDownList ID="ddl_note" runat="server" Font-Size="Medium">
            <asp:ListItem Selected="True" Value="all">全部</asp:ListItem>
            <asp:ListItem Value="国际决赛">国际决赛</asp:ListItem>
            <asp:ListItem Value="全国决赛">全国决赛</asp:ListItem>
            <asp:ListItem Value="团体优胜">团体优胜</asp:ListItem>
            <asp:ListItem Value="优秀参赛学校">优秀参赛学校</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;
        <asp:Button ID="btn_Search" runat="server" Text="查询" Font-Size="Medium" onclick="btn_Search_Click"/>
    </div>

    <!--GridView-->
    <div style="position: absolute; top: 67px; left: 0px;">
            <asp:GridView ID="GridView1" runat="server" BackColor="White" 
            BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
            GridLines="Horizontal" oninit="GridView1_Init" 
                onselectedindexchanging="GridView1_SelectedIndexChanging" 
                onrowdeleting="GridView1_RowDeleting" Width="1000px" 
                onrowdatabound="GridView1_RowDataBound">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" />
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
                <PagerStyle CssClass="GridViewPager" HorizontalAlign="Center" />
            </asp:GridView>
    </div>
    
    <!--AspNetPager分页控件-->
    <div style="position:absolute; top: 333px; left: 5px; width: 687px;">
          <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
         onpagechanged="AspNetPager1_PageChanged" CssClass="anpager"
         CurrentPageButtonClass="cpb" FirstPageText="首页" LastPageText="尾页"
         NextPageText="后页" PrevPageText="前页" AlwaysShow="True" 
              Font-Bold="True" Font-Size="XX-Large" Font-Underline="True">
         </webdiyer:AspNetPager>  
    </div> 
    
    <!--输入框&Excel文件导入导出-->      
    <div style="border: 3px double #006600; position:absolute; top: 365px; left: 1px; background-color:#FFFFFF; color: #000000; font-weight: bold; font-size: x-large;">
        <asp:Label ID="lbl_names" runat="server" Text="学科:" Font-Size="Medium"></asp:Label>
        
        <asp:DropDownList ID="ddl_names" runat="server" Font-Size="Medium">
            <asp:ListItem Value="全国信息学奥林匹克联赛">全国信息学奥林匹克联赛</asp:ListItem>
            <asp:ListItem Value="全国高中数学联赛">全国高中数学联赛</asp:ListItem>
            <asp:ListItem Value="全国高中物理竞赛">全国高中物理竞赛</asp:ListItem>
            <asp:ListItem Value="全国高中化学竞赛">全国高中化学竞赛</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Label ID="lbl_year" runat="server" Text="年份:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_year" runat="server" Font-Size="Medium"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_zhzx" runat="server" Text="镇海中学人数:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_zhzx" runat="server" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lbl_ningbo" runat="server" Text="宁波大市人数:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_ningbo" runat="server" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lbl_zhejiang" runat="server" Text="浙江省人数:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_zhejiang" runat="server" Font-Size="Medium"></asp:TextBox>
        <br />
        <asp:Label ID="lbl_note" runat="server" Text="备注:" Font-Size="Medium"></asp:Label>
        <asp:TextBox ID="txtbox_note" runat="server" Width="510px" Font-Size="Medium"></asp:TextBox>
        <br />
        <asp:Button ID="btnUpdate" runat="server" Text="更新" onclick="btnUpdate_Click" Font-Size="Medium"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAdd" runat="server" Text="添加" onclick="btnAdd_Click" Font-Size="Medium"/>    
        <br />
        <asp:Label ID="Label1" runat="server" Text="批量导出：" Font-Size="Medium"></asp:Label>
        <asp:Button ID="btnExcel" runat="server" Text="导出Excel文件" onclick="btnExcelOut_Click" Font-Size="Medium"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblExcelIn" runat="server" Text="批量导入：" Font-Size="Medium"></asp:Label>
        <asp:FileUpload ID="fuExcel" runat="server" Font-Size="Medium" Width="220px"/>
        <asp:Button ID="btnOk" runat="server" Text="确认文件" Font-Size="Medium" onclick="btnOk_Click"/>
        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>    
    
    </div>
</asp:Content>

