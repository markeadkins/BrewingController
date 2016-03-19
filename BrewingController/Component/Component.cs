using System;

namespace BrewingController
{
	public class Component
	{
		public enum assignEnum { Boil, Mash, HLT_RIMs };


		public Component ()
		{
		}

		public class SSR
		{
			public string ID;
			public int pinNum;
		}

		public class TempProbe
		{
			public string ID;
			protected assignEnum probeAssignedTo { get; set; }

		}

		public class Pump
		{
			public string ID;
			public int pinNum;
		}

	}
}

