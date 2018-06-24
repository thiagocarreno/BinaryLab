'use strict'

net = require('net')

server = net.createServer (socket) ->
	socket.write('Echo server\r\n')
	socket.pipe(socket)
	return

server.listen('1337', '127.0.0.1')