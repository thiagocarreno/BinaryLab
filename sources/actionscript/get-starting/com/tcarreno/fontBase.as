package com.esouza
{
	import flash.display.MovieClip;	
	import flash.text.TextFieldAutoSize;
	
	public class fontBase extends MovieClip
	{
		public var data:Object;
		
		public function fontBase():void
		{
			texto.autoSize = TextFieldAutoSize.LEFT;
			texto.wordWrap = false;
			texto.mouseEnabled = false;
			texto.multiline = false;
		}
	}
}