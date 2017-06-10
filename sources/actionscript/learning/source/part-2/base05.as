package
{
	import flash.display.MovieClip;
	
	import com.thiago.utils.converterTempo;
	
	
	public class base05 extends MovieClip
	{
		//private - acesso apenas dentro da própria classe
		
		//public - acesso a qualquer lugar
		
		//protected classes extendidas
		
		public function base05():void
		{
			init();
		}
		
		private function init():void
		{
			var converter:converterTempo = new converterTempo( 3600 );
			
			converter.segundos = 3600;
			
			converter.update();
			
			
			trace( converter.tempo );
			
			
			converter.segundos = 500;
			
			converter.update();
			
			
			trace( converter.tempo );
		}
	}
}