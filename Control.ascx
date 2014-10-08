<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Control.ascx.cs" Inherits="infotree" %>
<asp:TreeView ID="TreeView1" runat="server" 
    CollapseImageUrl="~/Images/openfoldericon.png" ExpandImageUrl="~/Images/foldericon.png" 
    Font-Names="微软雅黑" ForeColor="#003300" Font-Size="Large">
    <Nodes>
        <asp:TreeNode Text="数据库修改" Value="数据库修改">
            <asp:TreeNode Text="历年高考信息" Value="历年高考信息" NavigateUrl="~/gaokaoxinxi_modify.aspx"></asp:TreeNode>
            <asp:TreeNode Text="数理化信息竞赛" Value="数理化信息竞赛" NavigateUrl="~/shulihuaxinxi_modify.aspx"></asp:TreeNode>
            <asp:TreeNode Text="初级" Value="初级" NavigateUrl=""></asp:TreeNode>
            <asp:TreeNode Text="中级" Value="中级" NavigateUrl=""></asp:TreeNode>
            <asp:TreeNode Text="高级" Value="高级" NavigateUrl=""></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="练习" Value="练习">
                <asp:TreeNode Text="初级" Value="初级" NavigateUrl=""></asp:TreeNode>
                <asp:TreeNode Text="中级" Value="中级" NavigateUrl=""></asp:TreeNode>
                <asp:TreeNode Text="高级" Value="高级" NavigateUrl=""></asp:TreeNode>
            </asp:TreeNode>
        
    </Nodes>
</asp:TreeView>

