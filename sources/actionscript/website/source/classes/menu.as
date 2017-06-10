package classes
{
	import flash.display.MovieClip;
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.MouseEvent;
	
	import com.esouza.load.LoadXML;
	
	import caurina.transitions.Tweener;
	import caurina.transitions.properties.ColorShortcuts;
	
	public class menu extends Sprite
	{
		private var lxml:LoadXML;
		private var mc:MovieClip;
		
		public var secao:String = "home";
		
		public function menu( _mc:MovieClip ):void
		{
			mc = _mc;
			
			ColorShortcuts.init();
			
			init();
		}
		
		private function init():void
		{			
			lxml = new LoadXML( 'xml/menu.xml' );
			
			lxml.addEventListener( Event.COMPLETE, loaded );
		}
		
		private function loaded( evt:Event ):void
		{
			var xml:XML = XML( lxml.data );
			
			
			var nnode:uint = xml.item.length();
			
			var n:uint = 0;
			
			var item:itemMenu;
			
			
			while(n < nnode)
			{
				item = new itemMenu();
				
				item.texto.text = xml.item[n].@label.toUpperCase();
				item.x = n > 0 ? mc.width + 18 : 0;
				item.buttonMode = true;
				
				item.data = {
								data: xml.item[n].@data
							}
				
				item.addEventListener( MouseEvent.MOUSE_DOWN, mClick );
				item.addEventListener( MouseEvent.MOUSE_OVER, mOver );
				item.addEventListener( MouseEvent.MOUSE_OUT, mOut );
				
				mc.addChild( item );
				
				n++;
			}
			
			mc.x = dGlobal.obj["stage_width"] - mc.width - 20;
			mc.y = 20;
			
			mc.alpha = 0;
			Tweener.addTween( mc, { alpha: 1, time: 1 } );
		}
		
		private function mClick( evt:MouseEvent ):void
		{
			secao = MovieClip( evt.currentTarget ).data.data;
			
			dispatchEvent( new Event( "ITEM_CLICK", true ) );
		}
		
		private function mOver( evt:MouseEvent ):void
		{
			Tweener.addTween( evt.currentTarget, { _color: 0x0066EF, time: 1 });
		}
		
		private function mOut( evt:MouseEvent ):void
		{
			Tweener.addTween( evt.currentTarget, { _color: null, time: 1 });
		}
		
	}
}