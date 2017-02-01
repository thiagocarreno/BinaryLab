﻿package net.andremattos.display
{
	import flash.display.Sprite;
	import flash.events.Event;
	import flash.display.MovieClip;
	import flash.display.DisplayObject;
	
	/**
	 * ...
	 * @author André Mattos - www.ma77os.com
	 */
	public class DisplayScalable extends Sprite
	{
		public static const CROP:String = "crop";
		public static const REVEAL:String = "reveal";
		public static const FIT_RATIO:String = "fitRatio";
		public static const FIT_DISTORT:String = "fitDistort";
		
		private var _mode:String;
		
		private var _autoResize:Boolean = true;
		private var _widthInit:Number;
		private var _heightInit:Number;
		private var _wDest:Number;
		private var _hDest:Number;
		private var _scaleXDest:Number;
		private var _scaleYDest:Number;
		private var _t:DisplayObject;
		private var _ratio:Number;
		private var _destRatio:Number;
	
		public function DisplayScalable(target:DisplayObject = null) 
		{
			super();
			_t = target != null ? target : this;
			
			_widthInit = _t.width;
			_heightInit = _t.height;
			
			_mode = CROP;
			
			if (_t.stage != null) _registerResize ();
			else _t.addEventListener (Event.ADDED_TO_STAGE, _init);
			
			_t.addEventListener (Event.REMOVED_FROM_STAGE, dispose, false, 0, true);
		}
		
		public function dispose(e:Event = null):void 
		{
			_t.removeEventListener (Event.ADDED_TO_STAGE, _init);
			_t.removeEventListener(Event.REMOVED_FROM_STAGE, dispose);
			if (_t.stage != null) _t.stage.removeEventListener (Event.RESIZE, _sizeResize);
		}
		
		private function _init(e:Event):void 
		{
			_t.removeEventListener(Event.ADDED_TO_STAGE, _init);
			
			_registerResize ();
		}
		
		private function _registerResize():void
		{
			if (_autoResize) 
			{
				_t.stage.addEventListener (Event.RESIZE, _sizeResize, false, 0, true);
				onResize ();
			}
		}
		
		private function _sizeResize (e:Event):void
		{
			onResize ();
		}
		
		public function onResize(w:Number = 0, h:Number = 0):void
		{
			if (_t.stage == null) return;
			
			if (_widthInit == 0)
			{
				if (_t.width > 0)
				{
					_widthInit = _t.width;
					_heightInit = _t.height;
				}
				else return;
			}
			
			_wDest = w > 0? w : _t.stage.stageWidth;
			_hDest = h > 0 ? h : _t.stage.stageHeight;
			
			_scaleXDest = _wDest / _widthInit;
			_scaleYDest = _hDest / _heightInit;
			
			_destRatio = _wDest / _hDest;
			_ratio = _t.width / _t.height;
			
			switch (_mode)
			{
				case CROP:
					_scaleCrop ();
					break;
				case REVEAL:
					_scaleReveal ();
					break;
				case FIT_RATIO:
					_scaleFitRatio();
					break;
				case FIT_DISTORT:
					_scaleFitDistort();
					break;
			}
			
			
			centerPosition ();
		}
		
		private function _scaleCrop ():void
		{
			if (_scaleXDest > _scaleYDest)
			{
				_t.scaleX = _scaleXDest;
				_t.scaleY = _t.scaleX;
			}
			else if (_scaleXDest < _scaleYDest)
			{
				_t.scaleY = _scaleYDest;
				_t.scaleX = _t.scaleY;
			}
			else
			{
				_t.scaleX = _scaleXDest;
				_t.scaleY = _scaleYDest;
			}
		}
		
		private function _scaleReveal():void
		{
			if (_wDest > widthInit || _heightInit > heightInit)
			{
				_scaleCrop ();
			}
			else
			{
				if (_t.scaleX != 1) _t.scaleX = _t.scaleY = 1;
				centerPosition ();
			}
		}
		
		private function _scaleFitRatio ():void
		{
			if (_destRatio > ratio)
			{
				_t.scaleY = _scaleYDest;
				_t.scaleX = _t.scaleY;
			}
			else if (_destRatio < ratio)
			{
				_t.scaleX = _scaleXDest;
				_t.scaleY = _t.scaleX;
			}
		}
		
		private function _scaleFitDistort():void
		{
			_t.scaleX = _scaleXDest;
			_t.scaleY = _scaleYDest;
		}
		
		public function centerPosition ():void
		{
			_t.x = (_wDest - _t.width) / 2;
			_t.y = (_hDest - _t.height) / 2;
		}
		
		public function get mode():String { return _mode; }
		
		public function set mode(value:String):void 
		{
			_mode = value;
			onResize ();
		}
		
		public function get widthInit():Number { return _widthInit; }
		
		public function set widthInit(value:Number):void 
		{
			_widthInit = value;
		}
		
		public function get heightInit():Number { return _heightInit; }
		
		public function set heightInit(value:Number):void 
		{
			_heightInit = value;
		}
		
		public function get ratio():Number
		{
			return _ratio;
		}
		
		public function get destRatio():Number
		{
			return _destRatio;
		}
		
		public function get autoResize():Boolean { return _autoResize; }
		
		public function set autoResize(value:Boolean):void 
		{
			_autoResize = value;
			if (_t.stage != null)
			{
				if (_autoResize) 
				{
					_t.stage.addEventListener (Event.RESIZE, _sizeResize, false, 0, true);
					onResize ();
				}
				else _t.stage.removeEventListener (Event.RESIZE, _sizeResize);
			}
		}
		
	}

}                                                                                                                                                                                                                                                                                                                                           