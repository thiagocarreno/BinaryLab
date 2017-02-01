cluster = require 'cluster'
http = require 'http'
os = require 'os'

do -> 
	cpus = os.cpus()

	# Fork Workers
	if cluster.isMaster
		for i in [0..cpus.length]
			cluster.fork()
		
		cluster.on 'fork', (worker) ->
			# console.log "> #{worker.id}"

		cluster.on 'listening', (worker, address) ->
			json = JSON.stringify address, true, 2
			console.log "> #{worker.id}, #{json}"

		cluster.on 'exit', (worker, code, signal) ->
			console.log "worker #{worker.process.id} died."
	else
		# Workers can share any TCP connection
		# In this case its a HTTP server
		http.createServer (req, res) ->
			res.writeHead 200, { 'Content-Type', 'text/plain' }
			res.write 'Hello World'
			res.end()
		.listen 8000

	# console.log 'Server Running...'
	return