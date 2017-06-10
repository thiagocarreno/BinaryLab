package com.tcarreno.load
{
	import flash.display.Sprite;	
	import flash.events.Event;	
	import flash.net.URLLoader;	
	import flash.net.URLRequest;
	
	public class LoadXML extends Sprite
	{
		private var URL:String;		
		public var data:XML;
		
		public function LoadXML( _URL:String ):void
		{
			URL = _URL;
			init();
		}
		
		private function init():void
		{
			var ld:URLLoader = new URLLoader();			
			ld.load( new URLRequest( URL ) );
			
			ld.addEventListener( Event.COMPLETE, xmlLoaded );			
			dispatchEvent( new Event( Event.INIT , true ) );
		}
		
		private function xmlLoaded(evt:Event):void
		{
			data = new XML( evt.target.data );			
			dispatchEvent( new Event( Event.COMPLETE, true ) );
		}
	}
}