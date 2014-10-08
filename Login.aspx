<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <title>XX中学管理平台</title>
    <link rel="icon" href="Images/Logo_Lite.png"/>
    <meta content="管理系统" name="keywords" />
    <meta content="管理系统" name="description" />
    <link type="text/css" rel="stylesheet" href="Styles/style.css" />
    <link type="text/css" rel="stylesheet" href="Styles/tip-yellowsimple.css" />
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.cookie.js"></script>
    <script type="text/javascript" src="Scripts/jquery.validate.field.js"></script>
    <script type="text/javascript" src="Scripts/jquery.poshytip.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="page">
        <div class="head">
            <div class="czour" style="display: none">
               </div>
        </div>
        <div class="loginLogo">
            <img alt="" src="Images/logo.png" /></div>

        <!--登陆主页面-->
        <div class="loginWindow">
            <div class="login">
                <div class="divSpan"></div>

                <div style="position: absolute; top: 95px; left: 478px; width: 303px; height: 194px;">
                    <asp:Login ID="Login1" runat="server" BackColor="White" BorderColor="#CCCCCC" 
                        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                        Font-Size="0.8em" ForeColor="Black" Height="193px" PasswordLabelText="密  码:" 
                        TitleText="" Width="298px" LoginButtonImageUrl="~/Images/Loginbtn.png" 
                        LoginButtonType="Image" onauthenticate="Login1_Authenticate">
                        <CheckBoxStyle Font-Bold="True" Font-Overline="False" Font-Size="X-Small" 
                            ForeColor="Black" HorizontalAlign="Center" Wrap="True" />
                        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                        <LabelStyle Font-Size="Medium" Font-Strikeout="False" 
                            HorizontalAlign="Center" />
                        <LoginButtonStyle BackColor="#33CC33" BorderColor="#CCCCCC" BorderStyle="Ridge" 
                            BorderWidth="2px" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Large" 
                            ForeColor="Black" Width="298px" />
                        <TextBoxStyle Font-Size="0.8em" />
                        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                            ForeColor="White" />
                        <ValidatorTextStyle BackColor="White" Font-Size="Medium" 
                            Font-Underline="False" />
                    </asp:Login>       
                </div>
                <div class="marLeft row-line">
                </div>
                 <div class="marLeft row" 
                    style="position: absolute; top: 300px; left: 449px; width: 331px;">
                    <asp:Label ID="Label1" runat="server" class="row-lb">励志，进取，勤奋，健美&nbsp;&nbsp;&nbsp;&nbsp;[用户名：admin，密码：admin]</asp:Label>    
                 </div>

            </div>
        </div>
        
    </div>
    <div class="footer">
        <div class="copyright">
            <span>&nbsp;Copyright 2013-2014 by Winbobob, All Rights Reserved .&nbsp;&nbsp如有需要请联系&nbsp;&nbsp[Winbobob]</span>
            <span style="display:none">请保留以上版权信息，谢谢！</span>
        </div>
    </div>
    </form>
</body>
</html>
