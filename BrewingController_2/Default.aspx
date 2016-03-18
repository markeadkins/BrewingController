<%@ Page Language="C#" Inherits="BrewingController_2.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Brewing Controller</title>
    <link href="css/stylesheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">

		<asp:ScriptManager id="ScriptManager" runat="server" />	
		<asp:Timer runat="server" id="UpdateTemp" Interval="2000" OnTick="UpdateTemp_Tick" />

		<div id = "container">
        	<div id = "header">

        		<img class="header_image" src="images/header_logo.jpeg" alt="beer" width="900px" height = "150px"/>

                <div id = "nav">

                </div><!---/#nav-->

             </div><!---/#header-->

             <div id = "content_wrapper">

				<div id="tempControls1" class="tempControls">
					<asp:UpdatePanel runat="server" id="TempPanel1" UpdateMode="Conditional">
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
						</Triggers>
						<ContentTemplate>
							<asp:Label runat="server" id="TempLabel1" Text="" /><br />
						</ContentTemplate>
					</asp:UpdatePanel>
					<h4>Boil Temp is set to</h4>
					<asp:Label runat="server" id="CurrentSetTemp1" OnInit="setCurrentTemp1" /><br />
					<h3>Set Temp to</h3>
					<asp:TextBox runat="server" id="TempSet1" /><br />
					<asp:Button runat="server" id="SendTemp1" Text="Set" OnClick="sendTemp1" /><br />
					<asp:UpdatePanel runat="server" id="TempIndicator1" UpdateMode="Conditional">
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
						</Triggers>
						<ContentTemplate>
							<asp:Label runat="server" id="HeatingIndicator1" /><br />
						</ContentTemplate>
					</asp:UpdatePanel>
				</div><!---/#tempControls1-->


				<div id="tempControls2" class="tempControls">
					<asp:UpdatePanel runat="server" id="TempPanel2" UpdateMode="Conditional">
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
						</Triggers>
						<ContentTemplate>
							<asp:Label runat="server" id="TempLabel2" Text="" /><br />
						</ContentTemplate>
					</asp:UpdatePanel>
				</div><!---/#tempControls2-->

				<div id="tempControls3" class="tempControls">
					<asp:UpdatePanel runat="server" id="TempPanel3" UpdateMode="Conditional">
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
						</Triggers>
						<ContentTemplate>
							<asp:Label runat="server" id="TempLabel3" Text="" /><br />
						</ContentTemplate>
					</asp:UpdatePanel>
					<h4>Mash Temp is set to</h4>
					<asp:Label runat="server" id="CurrentSetTemp3" OnInit="setCurrentTemp3" /><br />
					<h3>Set Temp to</h3>
					<asp:TextBox runat="server" id="TempSet3" /><br />
					<asp:Button runat="server" id="SendTemp3" Text="Set" OnClick="sendTemp3" /><br />
					<asp:UpdatePanel runat="server" id="TempIndicator3" UpdateMode="Conditional">
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="UpdateTemp" EventName="Tick" />
						</Triggers>
						<ContentTemplate>
							<asp:Label runat="server" id="HeatingIndicator3" /><br />
						</ContentTemplate>
					</asp:UpdatePanel>
				</div><!---/#tempControls3-->


				<div id="pumpButtons">
						<asp:Button runat="server" id="PumpButton1" Text="Pump 1" OnClick="togglePump1SSR" /><br /><br />
						<asp:Label runat="server" id="Pump1Status" Text="Off" /><br />
						<asp:Button runat="server" id="PumpButton2" Text="Pump 2" OnClick="togglePump2SSR" /><br /><br />
						<asp:Label runat="server" id="Pump2Status" Text="Off" /><br />
						<asp:Button runat="server" id="AllPumpsOff" Text="Turn Off All Pumps" OnClick="turnOffAllPumps" /><br />
				</div><!---/#pumpButtons-->

			</div><!---/#content_wrapper-->
		</div><!--/#container-->
	</form>
</body>
</html>

