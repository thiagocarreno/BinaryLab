package com.tcarreno.effects
{
	import flash.display.Sprite;	
	import flash.events.Event;	
	import flash.events.MouseEvent;
	
	import caurina.transitions.Tweener;	
	import caurina.transitions.properties.ColorShortcuts;
	
	public class Fade extends Sprite
	{
		public function Fade():void
		{
			ColorShortcuts.init()
		}
		
		public static function mouseInOut(_obj:*):void
		{
			_obj.addEventListener(MouseEvent.MOUSE_OVER, mOver);				
			_obj.addEventListener(MouseEvent.MOUSE_OUT, mOut);			
			
			function mOver(evt:Event):void
			{
				Tweener.addTween(evt.currentTarget, {alpha: 0.5, time: 1});				
			}
			
			function mOut(evt:Event):void
			{
				Tweener.addTween(evt.currentTarget, {alpha: 1, _color: null, time: 1});
			}
		}
	}
}