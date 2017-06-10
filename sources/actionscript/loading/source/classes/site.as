package classes
{
	import flash.display.Sprite;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.events.ProgressEvent;
	
	import com.tcarreno.load.LoadXML;
	import com.tcarreno.load.LoadIMG;
	import caurina.transitions.Tweener;	
			
	public class site extends Sprite
	{
		private var mc:MovieClip;
		private var lxml:LoadXML;
		private var limg:LoadIMG;
		private var xml:XML;
		private var Loading:loading;
			
		public function site(_mc:MovieClip):void
		{
			mc = _mc;
			init();
			
			dGlobal.obj["stage"].scaleMode = StageScaleMode.NO_SCALE;
			dGlobal.obj["stage"].align = StageAlign.TOP_LEFT;
			dGlobal.obj["stage"].addEventListener(Event.RESIZE, Resize);
		}
		
		private function init():void
		{						
			lxml = new LoadXML("xml/site.xml");
			lxml.addEventListener(Event.COMPLETE, loaded);
		}
		
		private function loaded(evt:Event):void
		{
			xml = XML(lxml.data);

			limg = new LoadIMG(xml.img[0]..@source);
			limg.ld.alpha = 0;
			limg.addEventListener("OPEN", imgOpen);
			limg.addEventListener("LOADING", imgLoading);
			limg.addEventListener("LOADED", imgLoaded);
			limg.start();
			
			mc.addChild(limg.ld);
		}
		
		private function imgOpen(evt:Event):void
		{
			Loading = new loading();
			Loading.alpha = 0;
			Loading.x = ((dGlobal.obj["stage"].stageWidth / 2) - (Loading.width / 2));
			Loading.y = ((dGlobal.obj["stage"].stageHeight / 2) - (Loading.height / 2));
			
			mc.addChild(Loading);
			
			Tweener.addTween(Loading, {alpha: 1, transition:"easeOutBack", time: 1});
		}
		
		private function imgLoading(evt:ProgressEvent):void
		{
			Loading.gotoAndStop(limg.pct);
		}
		
		private function imgLoaded(evt:Event):void
		{
			Tweener.addTween(Loading, {alpha: 0, transition:"easeOutBack", time: 0.5, onComplete: rLoading});
			function rLoading ():void
			{
				mc.removeChild(Loading);
			}
			
			mc.width = dGlobal.obj["stage"].stageWidth;
			mc.height = dGlobal.obj["stage"].stageHeight;

			Tweener.addTween(limg.ld, {alpha: 1, transition:"easeOutBack", time: 2});
		}
					
		private function Resize(evt:Event):void
		{
			mc.width = dGlobal.obj["stage"].stageWidth;
			mc.height = dGlobal.obj["stage"].stageHeight;
		}
	}
}