'use-strict'

http = require 'http'
httpProxy = require 'http-proxy'
seaport = require 'seaport'

do ->
	argument = process.argv.splice(2)
	ports = seaport.connect '127.0.0.1', 9000
	i = 0
	
	ports.once 'synced', ->
		proxy = httpProxy.createProxyServer()
		http.createServer (req, res) ->
			addresses = ports.query 'pi_server'

			if addresses.length is 0
				res.writeHead 503, { 'Content-Type': 'text/plain' }
				res.end 'Service Unavailable'
				return

			address = addresses[i]
			if address?
				objTarget = {
					target: {
						host: address.host,
						port: address.port
					}
				}

				json = JSON.stringify objTarget, true, 2
				console.log "> Target: #{json}"
				
				proxy.web req, res, objTarget
				i = (i + 1) % addresses.length

			res.end

			return
		.listen(argument[0] || 8000)

		proxy.on 'open', (proxySocket) ->
			console.log '> Proxy Open'
			return

		proxy.on 'proxyReq', (proxyReq, req, res, options) ->
			# json = JSON.stringify options, true, 2
			console.log "> Start Req"
			return

		proxy.on 'proxyRes', (proxyRes, req, res) ->
			# json = JSON.stringify proxyRes.headers, true, 2
			console.log "> Start Res"
			return

		proxy.on 'close', (req, socket, head) ->
			console.log '> Proxy Close'
			return

		return

	console.log "Server Running..."

	return