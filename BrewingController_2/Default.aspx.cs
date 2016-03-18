using System;
using System.Web;
using System.Web.UI;
using System.IO;
using Raspberry.IO.GeneralPurpose;

namespace BrewingController_2
{
	
	public partial class Default : System.Web.UI.Page
	{

		protected void initializeSetTemps(object sender, EventArgs e)
		{
			TempSet1.Text = "212";
			TempSet3.Text = "152";
		}

		protected void UpdateTemp_Tick(object sender, EventArgs e)
		{
			string strTemp1 = ReturnTemp ("28-0000066fe252");
			TempLabel1.Text = strTemp1;
			int intTemp1 = Int32.Parse(strTemp1);


			string strTemp2 = ReturnTemp("28-000006704f3b");
			TempLabel2.Text = strTemp2;

			string strTemp3 = ReturnTemp("28-0000068a2a37");
			TempLabel3.Text = strTemp3;
			int intTemp3 = Int32.Parse(strTemp3);

			int setTemp1 = Int32.Parse(CurrentSetTemp1.Text);
			int setTemp3 = Int32.Parse(CurrentSetTemp3.Text);

			if (intTemp1 < setTemp1 && HeatingIndicator1.Text == "Off") 
			{
				HeatingIndicator1.Text = "Heating";
				toggleHeatSSR (1, "On");
			} 

			else if (intTemp1 >= setTemp1 && HeatingIndicator1.Text == "Heating") 
			{
				HeatingIndicator1.Text = "Off";
				toggleHeatSSR (1, "Off");
			} 
				

			if (intTemp3 < setTemp3 && HeatingIndicator3.Text == "Off") 
			{
				HeatingIndicator3.Text = "Heating";
				toggleHeatSSR (2, "On");
			} 
			else if (intTemp3 >= setTemp3 && HeatingIndicator3.Text == "Heating") 
			{
				HeatingIndicator3.Text = "Off";
				toggleHeatSSR (2, "Off");
			} 


		}

		protected void toggleHeatSSR(int ssrNumber, string onOff)
		{
			var ssr = ConnectorPin.P1Pin31.Output();
			onOff = onOff.ToLower();

			if (ssrNumber == 1) 
			{
				ssr = ConnectorPin.P1Pin33.Output();
			}


			var connection = new GpioConnection(ssr);

			if (onOff == "on" )
			{
				connection.Toggle(ssr);
			}
			else
			{
				connection.Close();
			}


		}
			

		public static string ReturnTemp(string probeName)
		{
			string tempDir = "/sys/bus/w1/devices/";
			StreamReader sr = new StreamReader (tempDir + probeName + "/w1_slave");
			string line = sr.ReadToEnd();
			int numStart = line.IndexOf("t=");
			string lineSubStr = line.Substring((numStart + 2), 5);
			int tempC = (Int32.Parse(lineSubStr))/1000;
			int tempF = ((tempC * 9) / 5) + 32;
			string strTempF = tempF.ToString();
			return strTempF;
		}

		protected void togglePump1SSR(object sender, EventArgs e)
		{
			var ssr = ConnectorPin.P1Pin22.Output();
			var connection = new GpioConnection(ssr);

			if (Pump1Status.Text == "Off") 
			{
				Pump1Status.Text = "On";
				connection.Toggle(ssr);
			}
			else
			{
				Pump1Status.Text = "Off";
				connection.Close();
			}

		}

		protected void togglePump2SSR(object sender, EventArgs e)
		{
			var ssr = ConnectorPin.P1Pin36.Output();
			var connection = new GpioConnection(ssr);

			if (Pump2Status.Text == "Off") 
			{
				Pump2Status.Text = "On";
				connection.Toggle(ssr);
			}
			else
			{
				Pump2Status.Text = "Off";
				connection.Close();
			}
		}

		protected void sendTemp1 (object sender, EventArgs e)
		{
			int temp = Int32.Parse(TempSet1.Text);
			setCurrentTemp1_1(temp);
		}

		protected void setCurrentTemp1 (object sender, EventArgs e)
		{
			CurrentSetTemp1.Text = "212";
		}

		protected void setCurrentTemp1_1 (int temp = 90)
		{
			string strTemp = temp.ToString();
			CurrentSetTemp1.Text = strTemp;

		}




		protected void sendTemp3 (object sender, EventArgs e)
		{
			int temp = Int32.Parse(TempSet3.Text);
			setCurrentTemp3_1(temp);
		}

		protected void setCurrentTemp3 (object sender, EventArgs e)
		{
			CurrentSetTemp3.Text = "152";
		}

		protected void setCurrentTemp3_1 (int temp = 90)
		{
			string strTemp = temp.ToString();
			CurrentSetTemp3.Text = strTemp;
		}



		protected void turnOffAllPumps(object sender, EventArgs e)
		{
			var ssr1 = ConnectorPin.P1Pin36.Output ();
			var ssr2 = ConnectorPin.P1Pin22.Output ();

			var connection1 = new GpioConnection (ssr1);
			var connection2 = new GpioConnection (ssr2);

			connection1.Close ();
			connection2.Close ();

			Pump1Status.Text = "Off";
			Pump2Status.Text = "Off";
		}

	}
}

