// Generated by CoffeeScript 1.8.0
var app, express, port;

express = require('express');

app = new express;

port = process.env.PORT || 4000;

app.use(express["static"](__dirname + '/'));

app.listen(port);
