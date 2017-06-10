package
{
	import flash.display.Sprite;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.MouseEvent;
	
	import classes.site;
	
	import com.tcarreno.utils.Display;
	import caurina.transitions.Tweener;	
	import classes.dGlobal;
	
	public class Default extends Sprite
	{
		private var mcSite:MovieClip;
		private var Site:site;
		
		public function Default():void
		{
			init();
		}
		
		private function init():void
		{
			dGlobal.obj["stage"] = stage;
			
			mcSite = new MovieClip();
			
			addChild(mcSite);
			
			Site = new site(mcSite);
		}
	}
}