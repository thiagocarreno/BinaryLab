package net.andremattos.media
{
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.events.IOErrorEvent;
	import flash.events.NetStatusEvent;
	import flash.events.TimerEvent;
	import flash.media.SoundTransform;
	import flash.media.Video;
	import flash.net.NetConnection;
	import flash.net.NetStream;
	import flash.utils.setTimeout;
	import flash.utils.Timer;
	import net.andremattos.events.VideoEvent;
	
	/**
	 * ...
	 * @author André Mattos - www.ma77os.com
	 * TODO: implementar play de um NetStream direto
	 */
	public class FLVPlayer extends APlayer
	{
		private var _video:Video;
		private var _nc:NetConnection;
		private var _ns:NetStream;
		private var _startTime:Number;
		private var _timerUpdatePlayer:Timer;
		//private var _autoRewind:Boolean = false;
		private var _playbackStarted:Boolean = false;
		private var _playbackEnded:Boolean = false;
		private var _loop:Boolean = false;
		
		public function FLVPlayer() 
		{
			super();
			
			_nc = new NetConnection ()
			_nc.addEventListener (NetStatusEvent.NET_STATUS, _onNetStatus, false, 0, true)
			_nc.addEventListener (IOErrorEvent.IO_ERROR, _onIOError, false, 0, true);
			_nc.connect (null);
			
			_timerUpdatePlayer = new Timer(40); 
			_timerUpdatePlayer.addEventListener (TimerEvent.TIMER, _updatePlayer, false, 0, true);
			
			video = new Video();
			addChild (_video);
		}
		
		
		private function _initNS ():void
		{
			_nc.removeEventListener (NetStatusEvent.NET_STATUS, _onNetStatus)
			_nc.removeEventListener (IOErrorEvent.IO_ERROR, _onIOError);
			
			_ns = new NetStream (_nc);
			_ns.addEventListener (NetStatusEvent.NET_STATUS, _onNetStatus, false, 0, true)
			_ns.client = this;
		}
		
		public function play (strUrl:String, start:Number = 0):void
		{
			_ns.play (strUrl);
			_startTime = start;
			
			_isPlaying = true;
			_controls.playing = _isPlaying;
			_controls._onClickPlay(null);
			_playbackStarted = false;
			
			if (!_timerUpdatePlayer.running) _timerUpdatePlayer.start ();
			// TODO: implementar evento buffer full
			_updateBuffering ();
			
			if (_startTime > 0) pause ();
		}
		
		override public function resume ():void
		{
			if (_playbackEnded) 
			{
				_ns.seek (0);
				_controls.time = 0;
				_playbackEnded = false;
			}
			_ns.resume ();
			
			if (!_timerUpdatePlayer.running) _timerUpdatePlayer.start ();
			super.resume ();
		}
		
		override public function pause ():void
		{
			if (_ns == null) return;
			
			_ns.pause ();
			super.pause ();
		}
		
		public function clearVideo ():void
		{
			if (_timerUpdatePlayer.running) _timerUpdatePlayer.stop ();
			_ns.close ();
		}
		
		override public function dispose ():void
		{
			clearVideo ();
			_nc.close ();
			super.dispose ();
		}
		
		override protected function _onControlSeek(e:VideoEvent):void 
		{
			time = e.time;
			super._onControlSeek (e);
		}
		
		override protected function _onControlChangeVolume(e:VideoEvent):void 
		{
			volume = e.volume;
			super._onControlChangeVolume (e);
		}
		
		override protected function _updatePlayer(e:Event = null):void 
		{
			var loadingRatio:Number = _ns.bytesLoaded / _ns.bytesTotal;
			var timeLoaded:Number = loadingRatio * _duration;
			
			if (_startTime > 0 && timeLoaded > _startTime + 1)
			{
				setTimeout (function(seekTime:Number):void{
					_ns.seek (seekTime);
					resume ();
				},300, _startTime)
				
				_startTime = 0
			}
			
			_controls.bufferRatio = loadingRatio;
			
			if (_isPlaying)
			{
				_controls.time = _ns.time;
			}
			
			super._updatePlayer (e);
		}
		
		private function _onPlaybackEnded ():void
		{
			_playbackEnded = true;
			
			//trace ("_onPlaybackEnded");
			//trace ("_loop:" + _loop);
			
			if (_loop)
			{
				resume ();
				pause ();
			}
			else
			{
				_timerUpdatePlayer.stop ();
				if (_ns) _ns.pause();
			}
			/*if (_autoRewind) 
			{
				_ns.seek (0);
				_controls.time = 0;
			}*/
			
			
			dispatchEvent (new VideoEvent(VideoEvent.COMPLETE));
		}
		
		private function _onIOError(e:IOErrorEvent):void 
		{
			
		}
		
		private function _onNetStatus(e:NetStatusEvent):void 
		{
			//trace ("e.info.code: " + e.info.code);
			switch (e.info.code)
			{
				case "NetConnection.Connect.Success":
					_initNS ();
					_isBuffering = true;
					break;
				case "NetStream.Play.StreamNotFound":
					break;
				case "NetStream.Buffer.Empty":
					if (_playbackEnded) return;
					_isBuffering = true;
					break;
				case "NetStream.Buffer.Full":
					_isBuffering = false;
					if (!_playbackStarted)
					{
						_playbackStarted = true;
						dispatchEvent (new VideoEvent (VideoEvent.STARTED));
					}
					//else dispatchEvent