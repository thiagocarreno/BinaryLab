package net.andremattos.animation
{
	import adobe.utils.CustomActions;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.utils.Dictionary;
	import flash.utils.getTimer;
	/**
	 * ...
	 * @author André Mattos - www.ma77os.com
	 * TODO: 
	 * - fix execptions
	 * - implement delay correctly
	 * - implement callbacks (onUpdate, onComplete...)
	 */
	public class SimpleTween
	{
		private static var _instance:SimpleTween;
		private static var _initied:Boolean = false;
		private var _tweenObjects:Vector.<TweenObj>
		private var _targetsDict:Dictionary;
		private var _updater:MovieClip;
		private var _running:Boolean = false;
		private var _defaultEase:Function = easeOutQuad;
		private var _lastTime:Number;
		
		public function SimpleTween (singleton:Singleton)
		{
			
		}
		
		
		public static function tween (target:Object, time:Number, props:Object)
		{
			trace ("tween");
			if (!_initied) _init ();
			
			if (_instance._targetsDict[target] != null) _instance._deleteObj (_instance._targetsDict[target]);
			
			if (props == null) props = { };
			
			var tweenObject:TweenObj = new TweenObj ();
			tweenObject.target = target;
			tweenObject.time = time;
			tweenObject.delay = props.delay != null ? props.delay : 0;
			tweenObject.ease = props.ease != null ? props.ease : _instance._defaultEase;
			tweenObject.props = _instance._validateProps(tweenObject, props);
			
			_instance._tweenObjects.fixed = false;
			_instance._tweenObjects.push (tweenObject);
			_instance._tweenObjects.fixed = true;
			
			_instance._targetsDict[target] = tweenObject;
			
			_instance._start ();
		}
		
		private function _validateProps(tweenObject:TweenObj, props:Object):Vector.<TweenProp>
		{
			var tweenProps:Vector.<TweenProp> =  new Vector.<TweenProp> ();
			for (var p:String in props)
			{
				if (!isNaN(props[p]))
				{
					var tweenProp:TweenProp = new TweenProp (p, Number(tweenObject.target[p]), Number (props[p]) - Number(tweenObject.target[p]), tweenObject.time);
					tweenProps.push (tweenProp);
				}
			}
			tweenProps.fixed = true;
			return tweenProps;
		}
		
		private static function _init():void
		{
			_instance = new SimpleTween (new Singleton ());
			_instance._updater = new MovieClip ();
			_instance._tweenObjects = new Vector.<TweenObj>();
			_instance._targetsDict = new Dictionary (true);
			
			_initied = true;
		}
		
		private function _start():void
		{
			if (_running) return;
			_lastTime = getTimer();
			_updater.addEventListener (Event.ENTER_FRAME, _update, false, 0, true);
			_running = true;
		}
		
		private function _stop():void
		{
			_updater.removeEventListener (Event.ENTER_FRAME, _update);
			_running = false;
		}
		
		
		private function _update (e:Event)
		{
			var tweenObj:TweenObj;
			var p:TweenProp;
			const currentTime:Number = (getTimer()-_lastTime) * 0.001;
			
			for each (tweenObj in _tweenObjects)
			{
				for each (p in tweenObj.props)
				{
					if (currentTime < p.duration)
					{
						tweenObj.target[p.prop] = tweenObj.ease (currentTime, p.start, p.change, p.duration);
					}
					else
					{
						tweenObj.target[p.prop] = p.start + p.change;
						_complete (tweenObj);
					}
				}
			}
		}

		private function _complete (tweenObj:TweenObj):void
		{
			trace ("_complete: " + tweenObj);
			
			_deleteObj (tweenObj);
			
			if (_tweenObjects.length == 0)
			{
				trace ("ALL TWEENS COMPLETED");
				_stop ();
			}
			//
			//trace ("complete")
		}
		
		private function _deleteObj (tweenObj:TweenObj):void
		{
			if (_tweenObjects.length > 0 && _tweenObjects.indexOf (tweenObj) > -1)
			{
				_tweenObjects.fixed = false;
				_tweenObjects.splice(_tweenObjects.indexOf (tweenObj), 1);
				_tweenObjects.fixed = true;
			}
			
			_targetsDict[tweenObj.target] = null;
			
			tweenObj.target = null;
			tweenObj = null;
		}
		
		public static function linear (t:Number, b:Number, c:Number, d:Number):Number
		{
			return c*t/d + b;
		}	
		
		public static function easeOutQuad(t:Number, b:Number, c:Number, d:Number):Number
		{
			return -c * (t/=d)*(t-2) + b;
		}
	}
}
internal class TweenObj
{
	public var target:Object;
	public var time:Number;
	public var delay:Number;
	public var ease:Function;
	public var onUpdate:Function;
	public var onComplete:Function;
	public var props:Vector.<TweenProp>;
}
internal class TweenProp
{
	public var prop:String;
	public var start:Number;
	public var change:Number;
	public var duration:Number;
	
	public function TweenProp(prop:String, start:Number, change:Number, duration:Number) 
	{
		this.prop = prop;
		this.start = start;
		this.change = change;
		this.duration = duration;
	}
}
internal class Singleton { }                                                                                                                                                                                                                                                                                                                                                                                                       