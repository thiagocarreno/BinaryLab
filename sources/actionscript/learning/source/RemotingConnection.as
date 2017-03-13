package 
{ 
	import flash.net.NetConnection;
	
	import flash.net.Responder;
	
	import flash.net.ObjectEncoding;
	
	import flash.events.NetStatusEvent;
	
	
	public class RemotingConnection extends NetConnection 
	{ 
		public var callBack:Function;
		
		public var responder:Responder;
		
		
		public function RemotingConnection(url:String) 
		{ 
			connect(url);
		} 
		
		public function setService( _classe:String, _metodo:String, _callBack:Function, _arr:Object = null ):void
		{ 
			this.responder = new Responder( Remoting_Result, onFault );
			
			this.callBack = _callBack;
			
			
			if( _arr == null || _arr.length < 0 )
			{
				super.call(_classe + "." + _metodo, this.responder);
			}
			else
			{
				super.call( _classe + "." + _metodo, this.responder, _arr );
			}
		} 
			
		public function Remoting_Result( re:Object ):Object 
		{ 
			if(re)
			{
				return this.callBack( re );
			}
			else
			{
				return this.callBack( false ); 
			}
		} 
			
		public function onFault(re:Object):void 
		{ 
			trace("Error:");
			
			for (var info in re) trace( re[info] ); 
		} 
	} 
}