using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;

namespace BrewingController
{
	
	public partial class Home : System.Web.UI.Page 
	{

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void MakeDropDownListOfTempProbes(object sender, EventArgs e)
		{
			Array arr = GetTempProbeNames ();

			List<string> list1 = new List<string> ();

			foreach (string arrItem in arr) 
			{
				list1.Add (arrItem);
			}

			list1.Add ("null");

			DropDownList1.DataSource = list1;
			DropDownList1.DataBind ();
			DropDownList2.DataSource = list1;
			DropDownList2.DataBind ();
			DropDownList3.DataSource = list1;
			DropDownList3.DataBind ();

		}

		public static Array GetTempProbeNames()
		{
			string folderLocation = "/sys/bus/w1/devices/w1_bus_master1";
			string[] dir = Directory.GetDirectories (folderLocation, "28-0*");
			int indexNum = 0;
			foreach (string str in dir) {
				int i = str.IndexOf ("28-0");
				string newStr = str.Substring (i, 15);
				dir [indexNum] = newStr;
				indexNum++;
			}

			return dir;
		}
			
		protected void StartSessionButton_Click(object sender, EventArgs e)
		{
			Component.TempProbe tempProbe1 = new Component.TempProbe ();
			tempProbe1.ID = DropDownList1.SelectedItem.ToString ();

			Component.TempProbe tempProbe2 = new Component.TempProbe ();
			tempProbe2.ID = DropDownList2.SelectedItem.ToString ();

			Component.TempProbe tempProbe3 = new Component.TempProbe ();
			tempProbe3.ID = DropDownList3.SelectedItem.ToString ();


			Label1.Text = "Temp Probe 1: " + tempProbe1.ID;
			Label2.Text = "Temp Probe 2: " + tempProbe2.ID;
			Label3.Text = "Temp Probe 3: " + tempProbe3.ID;


		}

	}

}

