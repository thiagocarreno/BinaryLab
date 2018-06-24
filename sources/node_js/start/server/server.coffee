'use strict'

http = require('http')

http.createServer (req, res) ->
	res.writeHead(
		200,
		{'Content-Type': 'text-plain'}
	)
	res.end('Hello World\n')
	return
.listen('1337', '127.0.0.1')

console.log('Server running http://127.0.0.1:1337/')