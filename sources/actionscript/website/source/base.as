package
{
	import flash.display.Sprite;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.MouseEvent;
	
	import classes.menu;
	import classes.home;
	import classes.galeria;
	import classes.sobre;
	
	import com.esouza.utils.Display;
	
	import caurina.transitions.Tweener;
	
	public class base extends Sprite
	{
		private var mcMenu:MovieClip;
		private var mcContent:MovieClip;
		
		private var menu_class:menu;
		
		public function base():void
		{
			init();
		}
		
		private function init():void
		{
			dGlobal.obj["stage_width"] = stage.stageWidth;
			dGlobal.obj["stage_height"] = stage.stageHeight;
			
			mcMenu = new MovieClip();
			mcContent = new MovieClip();
			
			addChild( mcMenu );
			addChild( mcContent );
			
			menu_class = new menu( mcMenu );
			
			menu_class.addEventListener( 'ITEM_CLICK', mClick );
			
			menu_class.secao = 'home';
			
			mClick( null );
		}
		
		private function mClick( evt:Event ):void
		{
			Tweener.addTween( mcContent, { alpha: 0, time: .6, onComplete: openpage } );
		}
		
		private function openpage():void
		{
			Display.removeAllChildren( mcContent );
			
			mcContent.alpha = 1;
			
			
			var c:Object;
			
			switch( menu_class.secao )
			{
				case "home":
					
					c = new home( mcContent );
				
				break;
				
				case "galeria":
					
					c = new galeria( mcContent );
				
				break;
				
				case "sobre":
					
					c = new sobre( mcContent );
				
				break;
			}
		}
	}
}