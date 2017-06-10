'use strict'

http = require 'http'
url = require 'url'

http.createServer (request, response) ->
	response.writeHead(
		200,
		{ "Content-Type": "text/plain" }
	)

	params = url.parse(
		request.url,
		true
	).query

	input = params.number;
	numInput = new Number(input)
	numOutput = new Number(Math.random() * numInput).toFixed(0)

	response.write(numOutput)
	response.end()
	return
.listen(8000)

console.log("Random Number Generator Running...")