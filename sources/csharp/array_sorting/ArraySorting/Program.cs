package data 
{
	import flash.display.Sprite;
	import flash.geom.Point;
	import flash.geom.Rectangle;
	import flash.text.TextField;
	import flash.utils.Dictionary;
	import net.andremattos.utils.StringUtils;
	/**
	 * ...
	 * @author André Mattos - www.ma77os.com
	 */
	public class AETrackParser 
	{
		private var _frames:Dictionary = new Dictionary ();
		
		public function AETrackParser() 
		{
			
		}
		
		public function fromFields(initialFrame:int = 0, ...points):String 
		{
			log (this, "fromtxt");
			
			for (var a:int=0; a < points.length; a++)
			{
				var txt:TextField = points[a];
				
				var totalLines:uint = txt.numLines;
				
				//log (this, "total lines: " + totalLines);
				//log (this, "lines[0]: " + txt.getLineText(0));
				
				for (var i:int=0; i < totalLines; i++)
				{
					var line:Array = txt.getLi