package com.tcarreno
{
	import flash.display.MovieClip;	
	import flash.text.TextFieldAutoSize;
	
	public class fontBase extends MovieClip
	{
		public var data:Object;
		
		public function fontBase():void
		{
			txt.autoSize = TextFieldAutoSize.LEFT;
			txt.wordWrap = false;
			txt.mouseEnabled = false;
			txt.multiline = false;
		}
	}
}