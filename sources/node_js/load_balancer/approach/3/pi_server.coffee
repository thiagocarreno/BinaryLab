'use-strict'

http = require 'http'
seaport = require 'seaport'

do ->
	conn = seaport.connect '127.0.0.1', 9090

	# * This function estimates pi using Monte-Carlo integration
	# * https://en.wikipedia.org/wiki/Monte_Carlo_integration
	# * @returns {number}
	estimatePi = ->
		n = Math.pow 10, 6
		inside = 0

		for i in [0..n]
			x = Math.random()
			y = Math.random()
			
			calc = Math.sqrt (x * x + y * y)
			if calc <= 1
				inside++

		4 * inside / n

	# Create a basic server that responds to any request with the pi estimation
	server = http.createServer (req, res) ->
		res.writeHead 200, { 'Content-Type': 'text/plain' }
		res.write "Pi:#{estimatePi()}"
		res.end() 

	# Listen to a service
	server.listen(conn.register 'vivo_4g_exagerado@0.1.0')

	console.log "Server Running..."
	return