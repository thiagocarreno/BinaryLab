'use-strict'

http = require 'http'

do ->
	args = process.argv.splice(2)

	# * This function estimates pi using Monte-Carlo integration
	# * https://en.wikipedia.org/wiki/Monte_Carlo_integration
	# * @returns {number}
	estimatePi = ->
		n = 10000000
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
		res.end "Pi:#{estimatePi()}"
		return

	# Listen to a specified port, or default to 8000
	server.listen(args[0] || 8000)

	console.log "Server Running..."		

	return