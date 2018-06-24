package com.tcarreno.load
{
	import flash.display.DisplayObject;
	import flash.display.Sprite;
	import flash.display.Loader;
	import flash.events.Event;
	import flash.net.URLRequest;
	import flash.events.ProgressEvent;
	
	public class LoadIMG extends Sprite
	{
		private var URL:String;
		public var ld:Loader;
		public var data:Object = null;
		
		private var bl:Number;
		private var bt:Number;
		public var pct:Number;
		
		public function LoadIMG( _URL:String ):void
		{
			URL = _URL;
			ld = new Loader();
		}
		
		public function start():void
		{
			ld.load( new URLRequest( URL ) );
			ld.contentLoaderInfo.addEventListener( Event.OPEN, imgOpen);
			ld.contentLoaderInfo.addEventListener( ProgressEvent.PROGRESS, imgLoading );
			ld.contentLoaderInfo.addEventListener( Event.COMPLETE, imgLoaded );
			dispatchEvent(new Event("INIT", true) );
		}
		
		private function imgOpen(evt:Event):void
		{
			dispatchEvent(new Event( "OPEN", true ));
		}
		
		private function imgLoading(evt:ProgressEvent):void
		{
			bl = evt.bytesLoaded;
			bt = evt.bytesTotal;
			pct = Math.round(((bl / bt) * 100));
			dispatchEvent(new ProgressEvent( "LOADING", true));
		}
		
		private function imgLoaded(evt:Event):void
		{
			dispatchEvent(new Event( "LOADED", true ));
		}
		
		override public function set x(_x:Number):void
		{
			ld.x = _x;
		}
		
		override public function set y(_y:Number):void
		{
			ld.y = _y;
		}
		
		public function get image():DisplayObject
		{
			return ld;
		}
	}
}