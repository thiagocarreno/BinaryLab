package teste
	{
		public class fullDef extends def
			{
				public const PANEL_DATE:String = "20/09/2008";
					public function fullDef()
					{
					}
				public function painelInfo():String 
				{
				return PANEL_DATE + " - " + PANEL_H + "-" + PANEL_W + "-" + PANEL_TITLE;
				}
		}
	}