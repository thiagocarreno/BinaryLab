package net.andremattos.controls 
{
	import flash.display.DisplayObject;
	import flash.display.MovieClip;
	import flash.events.Event;
	import flash.events.EventDispatcher;
	import flash.events.KeyboardEvent;
	import flash.events.MouseEvent;
	import flash.text.TextField;
	import flash.ui.Keyboard;
	import net.andremattos.utils.StringUtils;
	import net.andremattos.utils.TextFieldUtils;
	
	/**
	 * ...
	 * @author André Mattos - www.ma77os.com
	 * TODO: merge this with combobox
	 */
	public class AutocompleteList extends EventDispatcher 
	{		
		public var view:MovieClip;
		private var _floatingMode:Boolean;
		private var _txt:TextField;
		private var _txtMc:MovieClip;
		private var _list:MovieClip;
		private var _listController:List;
		private var _listOpened:Boolean;
		private var _dataProvider:Array;
		private var _resultsFounded:Boolean;
		private var _selectedItem:Object;
		private var _initLabel:String;
		private var _disableSelect:Boolean;
		private var _currentSearchTerm:String;
		
		public function AutocompleteList(pView:MovieClip, itemListClass:*, disableSelect:Boolean = false) 
		{
			super();
			view = pView;
			_txtMc = view["txtMc"];
			_list = view["list"];
			_txt = _txtMc.txt;
			_disableSelect = disableSelect;
			
			if (_txt.length > 0) initLabel = _txt.text;
			
			floatingMode = true;
			
			_listController = new List (_list, itemListClass, disableSelect);
			if (!disableSelect) _listController.addEventListener (Event.SELECT, _onListSelect, false, 0, true);
			
			_txt.addEventListener (KeyboardEvent.KEY_UP, _onKeyOnTxt);
			
			if (!view.stage) view.addEventListener (Event.ADDED_TO_STAGE, _added);
			else _added();
		}
		
		public function close(...e):void 
		{
			if (!_floatingMode) return;
			_listOpened = false;
			if (view.contains(_list) && _floatingMode)view.removeChild (_list);
			if (_dataProvider) _listController.dataProvider = _dataProvider;
		}
		
		public function open(...e):void 
		{
			if (!_floatingMode) return;
			if (!_dataProvider || _dataProvider.length == 0) return;
			
			if (_floatingMode)
			{
				view.addChild (_list);
				view.addChild (_txtMc);
			}
			
			_listOpened = true;
		}
		
		public function clear ():void
		{
			close ();
			//_txt.text = "";
			_dataProvider = null;
			_listController.clear();
			_selectedItem = null;
			_resultsFounded = false;
		}
		
		public function addItem (label:String, data:Object):void
		{
			if (_dataProvider == null) _dataProvider = new Array ();
			var itemData:Object = {label:label, data:data}
			_dataProvider.push (itemData)
			_listController.dataProvider = _dataProvider;
		}
		
		public function removeItem (itemData:Object):void
		{
			// implementar
		}
		
		private function _added(e:Event = null):void 
		{
			if (view.hasEventListener (Event.ADDED_TO_STAGE))
				view.removeEventListener(Event.ADDED_TO_STAGE, _added);
			
			view.stage.addEventListener (MouseEvent.CLICK, _stageClick);
		}
		
		private function _onKeyOnTxt(e:KeyboardEvent):void 
		{
			switch (e.keyCode)
			{
				case Keyboard.ENTER:
					if (_listController.dataProvider && _listController.dataProvider.length > 0)
					{
						//_subFounded();
					}
					break;
				//case Keyboard.UP:
				//_idItemSelected--;
				//_selectCurrentItem ();
				//break;
				//case Keyboard.DOWN:
				//_idItemSelected++;
				//_selectCurrentItem ()
				//break;
			}
			
			search();
		}
		
		private function _stageClick(e:MouseEvent):void 
		{
			if (e.target == _txt) search()
			else if (_listOpened && !_list.contains (e.target as DisplayObject)) close();
		}
		
		public function search (term:String = null):void
		{
			var strSearch:String = term || _txt.text;
			if (term) _txt.text = term;
			
			var results:Array = new Array ();
			
			for (var i:String in _dataProvider)
			{
				if (StringUtils.searchMatch (strSearch, _dataProvider[i].label))
				{
					results.push (_dataProvider[i]);
				}
			}
			
			_resultsFounded = results.length > 0;
			//_matched = results.length == 1 && StringUtils.searchMatch (strSearch, _dataProvider[0].label);
			
			if (_resultsFounded)
			{
				_listController.dataProvider = results;
				open ();
			}
			else 
			{
				close();
			}
			
			_listController.resetScroll ();
			dispatchEvent (new Event (Event.CHANGE));
		}
		
		private function _onListSelect(e:Event):void 
		{
			_onSelectItem ();
			close();
		}
		
		private function _onSelectItem():void 
		{
			if (!_listController.selectedItem) return;
			//trace ("combobox onSelectItem");
			//trace ("_listController.selectedItem: " + _listController.selectedItem)
			_txt.text = _listController.selectedItem.label;
			search ();
			_selectedItem = _listController.selectedItem;
			//_matched = true;
			dispatchEvent (new Event (Event.SELECT));
		}
		
		
		public function set dataProvider (value:Array):void
		{
			_dataProvider = value;
			_listController.dataProvider = _dataProvider;
		}
		
		//Getter que retorna a array com os objetos
		public function get dataProvider ():Array
		{
			return _dataProvider;
		}
		
		public fun