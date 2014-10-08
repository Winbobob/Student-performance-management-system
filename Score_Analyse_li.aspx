<%@ Page Title="" Language="C#" MasterPageFile="~/FrontMasterPage.master" AutoEventWireup="true" CodeFile="Score_Analyse_li.aspx.cs" Inherits="Score_Analyse" %>
<%@ Register src="Control2.ascx" tagname="Control" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderCTop" Runat="Server">
    <style type="text/css">
        td{font-size: large;height:30px;}
        .tdStyle{background-color: #FFFFFF;color:Black;border-style: solid;border-width:thin; border-color: #336666;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
    <uc2:Control ID="control" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMain" Runat="Server">

    <!--DataList纵向显示，节约空间-->
    <div>
        <asp:DataList ID="Datalist1" runat="server" RepeatDirection="Horizontal" >
    	    <ItemTemplate>
                <table style="border-style: solid; border-color: #336666; background-color: #336666; color: #FFFFFF">
    	            <tr><td>班级&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("class") + "班"%></td></tr>
    	            <tr><td>学号&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("stunum")%>&nbsp;</td></tr>
    	            <tr><td>姓名&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("stuname")%></td></tr>
    	            <tr><td>语文&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("yu")%></td></tr>
    	            <tr><td>数学&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("shu")%></td></tr>
    	            <tr><td>英语&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("ying")%></td></tr>
    	            <tr><td>物理&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("wu")%></td></tr>
    	            <tr><td>化学&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("hua")%></td></tr>
    	            <tr><td>生物&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("sheng")%></td></tr>
    	            <tr><td>自选&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("zixuan")%></td></tr>
    	            <tr><td>总分&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("total")%></td></tr>
    	            <tr><td>排名&nbsp;</td><td class="tdStyle">&nbsp;<%#Eval("MC")%></td></tr>
                    
                </table>
    	        </ItemTemplate>
    	</asp:DataList>
    </div>

    <asp:Panel ID="Panel1" runat="server">
        <div style="position: absolute; top: 55px; left: 280px;">

        <asp:Chart ID="Chart1" runat="server" BackColor="#D3DFF0" Palette="BrightPastel"
            ImageType="Png" ImageUrl="~/TempImages/ChartPic_#SEQ(300,3)" Width="680px" Height="460px"
            borderlinestyle="Solid" backgradientendcolor="White" backgradienttype="TopBottom"
            BorderlineWidth="2" BorderlineColor="26, 59, 105" >
            <Titles>
            </Titles>
            <Legends>
                <asp:Legend Enabled="False" Name="Default" BackColor="Transparent" Font="Times New Rome, 8.25pt, style=Bold">
                    <Position Y="21" Height="22" Width="18" X="73"></Position>
                </asp:Legend>
            </Legends>
            <BorderSkin SkinStyle="Emboss"></BorderSkin>
            <Series>
                <asp:Series Name="Series1" BorderColor="180, 26, 59, 105" XValueMember="xueke"
                    YValueMembers="score" IsValueShownAsLabel="True" LabelFormat="0.0" Font="Times New Rome, 13pt" LabelForeColor="Maroon">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                    BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent"
                    BackGradientStyle="TopBottom">
                    <AxisY LineColor="64, 64, 64, 64" IsLabelAutoFit="False" Maximum="150">
                        <LabelStyle Font="Times New Rome, 13pt" ForeColor="Black" Format="0.0"></LabelStyle>
                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                    </AxisY>
                    <AxisX LineColor="64, 64, 64, 64" IsLabelAutoFit="False">
                        <LabelStyle Font="Times New Rome, 13pt" ForeColor="Black"></LabelStyle>
                        <MajorGrid LineColor="64, 64, 64, 64"></MajorGrid>
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
        </div>

        <style type="text/css">.fadingTooltip { BORDER-RIGHT: darkgray 1px outset; BORDER-TOP: darkgray 1px outset; FONT-SIZE: 12pt; BORDER-LEFT: darkgray 1px outset; WIDTH: auto; COLOR: black; BORDER-BOTTOM: darkgray 1px outset; HEIGHT: auto; BACKGROUND-COLOR: lemonchiffon; MARGIN: 3px 3px 3px 3px; padding: 3px 3px 3px 3px; borderBottomWidth: 3px 3px 3px 3px }
		</style>
		<div class="fadingTooltip" id="fadingTooltip" style="Z-INDEX: 999; VISIBILITY: hidden; POSITION: absolute"></div>
		<script type="text/javascript">
			    var fadingTooltip;
			    var wnd_height, wnd_width;
			    var tooltip_height, tooltip_width;
			    var tooltip_shown = false;
			    var transparency = 100;
			    var timer_id = 1;
			    var tooltiptext;

			    // override events
			    window.onload = WindowLoading;
			    window.onresize = UpdateWindowSize;
			    document.onmousemove = AdjustToolTipPosition;

			    function DisplayTooltip(tooltip_text) {
			        fadingTooltip.innerHTML = tooltip_text;
			        tooltip_shown = (tooltip_text != "") ? true : false;
			        if (tooltip_text != "") {
			            // Get tooltip window height
			            tooltip_height = (fadingTooltip.style.pixelHeight) ? fadingTooltip.style.pixelHeight : fadingTooltip.offsetHeight;
			            transparency = 0;
			            ToolTipFading();
			        }
			        else {
			            clearTimeout(timer_id);
			            fadingTooltip.style.visibility = "hidden";
			        }
			    }

			    function AdjustToolTipPosition(e) {
			        if (tooltip_shown) {
			            // Depending on IE/Firefox, find out what object to use to find mouse position
			            var ev;
			            if (e)
			                ev = e;
			            else
			                ev = event;

			            fadingTooltip.style.visibility = "visible";
			            offset_y = (ev.clientY + tooltip_height - document.body.scrollTop + 30 >= wnd_height) ? -15 - tooltip_height : 20;
			            fadingTooltip.style.left = Math.min(wnd_width - tooltip_width - 10, Math.max(-135, ev.clientX - 175)) + document.body.scrollLeft + 'px';
			            fadingTooltip.style.top = ev.clientY + offset_y - 50 + document.body.scrollTop + 'px';
			        }
			    }

			    function WindowLoading() {
			        fadingTooltip = document.getElementById('fadingTooltip');

			        // Get tooltip  window width				
			        tooltip_width = (fadingTooltip.style.pixelWidth) ? fadingTooltip.style.pixelWidth : fadingTooltip.offsetWidth;

			        // Get tooltip window height
			        tooltip_height = (fadingTooltip.style.pixelHeight) ? fadingTooltip.style.pixelHeight : fadingTooltip.offsetHeight;

			        UpdateWindowSize();
			    }

			    function ToolTipFading() {
			        if (transparency <= 100) {
			            fadingTooltip.style.filter = "alpha(opacity=" + transparency + ")";
			            fadingTooltip.style.opacity = transparency / 100;
			            transparency += 5;
			            timer_id = setTimeout('ToolTipFading()', 35);
			        }
			    }

			    function UpdateWindowSize() {
			        wnd_height = document.body.clientHeight;
			        wnd_width = document.body.clientWidth;
			    }
			</script>
    </asp:Panel>

    
</asp:Content>

