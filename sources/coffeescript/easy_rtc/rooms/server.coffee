http = require 'http'
io = require 'socket.io'
express = require 'express'
easyrtc = require 'easyrtc'

class Server

    constructor: -> 
        @setUp()
        easyrtc.setOption 'roomDefaultEnable', no
    
    setUp: =>
        try
            httpApp = express()
            httpApp.set 'port', (process.env.PORT or 8000)
            httpApp.use express.static "#{__dirname}/wwwroot/"

            webServer = http.createServer(httpApp).listen (process.env.PORT or 8000)
            socketServer = io.listen webServer, {'log level': 1}
            easyrtc.listen httpApp, socketServer

        catch err
            console.error err.message, err.stack

        return

new Server