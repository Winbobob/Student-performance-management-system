<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="cover.aspx.cs" Inherits="cover" %>
<%@ Register src="Control.ascx" tagname="Control" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCTop" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
   <uc1:Control ID="control" runat="server" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">

    <table style="width:100%; height:100%;text-align:center;">
        <tr>
            <td style="text-align:center; vertical-align:middle;line-height:30px; font-size: x-large;" class="infoTitle">
            WEB后台管理平台欢迎您！<br /><br />请点击左边菜单进行操作。</td>
        </tr>
    </table>

</asp:Content>

