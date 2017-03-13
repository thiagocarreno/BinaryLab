package com.tcarreno.utils
{
	import flash.display.Sprite;
	
	public class Display extends Sprite
	{
		public function Display():void
		{
			
		}
		
		public static function removeAllChildren( _obj:* ):void
		{
			var n:uint = 0;
			
			var children:uint = _obj.numChildren;
			
			while( n < children ) 
			{
				_obj.removeChildAt(0);
				
				n += 1;
			}
		}
	}
}