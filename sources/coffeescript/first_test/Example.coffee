class test
	contructor: ->
		@myprop = on
	method: (a, b) -> 
		value = null;
		a + b
	method2: ->
		@a = =>
			@a + 1

		arr = []

		if @myprop is on
			alert 1

		for item in arr
			alert item

		for i in [0..10]
			alert 1

		switch @myprop
			when 1 then alert 1
			else 1

		interpolation = "#{@myprop} I'm coffee"