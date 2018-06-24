'use-strict'

http = require 'http'
seaport = require 'seaport'
bouncy = require 'bouncy'

do ->
	arg = process.argv.splice(2)
	server = seaport.createServer()
	server.listen 9090

	i = 0

	bouncy (req, res, bounce) ->
		addresses = server.query 'vivo_4g_exagerado@0.1.0'

		if addresses.length > 0
			address = addresses[i]
			if address?
				console.log address
				i = (i + 1) % addresses.length
				bounce address
		else
			res.writeHead 503, { 'Content-Type': 'text/plain' }
			res.end 'Service Unavailable'

		return
	.listen(arg[0] || 8000)



	console.log "Server Running..."

	return