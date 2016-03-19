<%@ Page Language="C#" Inherits="BrewingController.Home" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Brewing Controller</title>
    <link href="css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">

		<div id = "container">
        	<div id = "header">

        		<img class="header_image" src="images/header_logo.jpeg" alt="beer" width="900px" height = "150px"/>

                <div id = "nav">

                </div><!---/#nav-->

             </div><!---/#header-->

             <div id = "content_wrapper">

             	<h2>Boil Probe</h2>
             	<asp:DropDownList id="DropDownList1" runat="server" OnInit="MakeDropDownListOfTempProbes" />
             	<asp:Label id="Label1" runat="server" />
             	<br />

             	<h2>Mash Probe</h2>
             	<asp:DropDownList id="DropDownList2" runat="server" />
             	<asp:Label id="Label2" runat="server" />
             	<br />

             	<h2>HLT/RIMs Probe</h2>
             	<asp:DropDownList id="DropDownList3" runat="server" />
             	<asp:Label id="Label3" runat="server" />
             	<br /><br />

             	<asp:Button id="StartSessionButton" runat="server" Text="Start Session" OnClick="StartSessionButton_Click" />

			</div><!---/#content_wrapper-->
		</div><!--/#container-->
	</form>
</body>
</html>

