// Generated by CoffeeScript 1.9.0
'use strict';
var http, url;

http = require('http');

url = require('url');

http.createServer(function(request, response) {
  var input, numInput, numOutput, params;
  response.writeHead(200, {
    "Content-Type": "text/plain"
  });
  params = url.parse(request.url, true).query;
  input = params.number;
  numInput = new Number(input);
  numOutput = new Number(Math.random() * numInput).toFixed(0);
  response.write(numOutput);
  response.end();
}).listen(8000);

console.log("Random Number Generator Running...");
