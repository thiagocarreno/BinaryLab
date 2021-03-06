// Generated by CoffeeScript 1.9.0
'use-strict';
var http, seaport;

http = require('http');

seaport = require('seaport');

(function() {
  var estimatePi, ports, server;
  ports = seaport.connect('127.0.0.1', 9000);
  estimatePi = function() {
    var calc, i, inside, n, x, y, _i;
    n = Math.pow(10, 6);
    inside = 0;
    for (i = _i = 0; 0 <= n ? _i <= n : _i >= n; i = 0 <= n ? ++_i : --_i) {
      x = Math.random();
      y = Math.random();
      calc = Math.sqrt(x * x + y * y);
      if (calc <= 1) {
        inside++;
      }
    }
    return 4 * inside / n;
  };
  server = http.createServer(function(req, res) {
    res.writeHead(200, {
      'Content-Type': 'text/plain'
    });
    res.write("Pi:" + (estimatePi()));
    return res.end();
  });
  server.listen(ports.register('pi_server'));
  console.log("Server Running...");
})();
