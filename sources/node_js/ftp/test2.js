var JSFtp = require("jsftp");
var fs = require("fs");
var Ftp = new JSFtp({
	host: "www3.hmlwunderman.com.br",
	port: 21,
	user: "w8hmluser",
	pass: "K3erplUNK12#"
});

function readFile (path, callback) {
	if (path == '')
		throw "O parâmetro path está incorreto."

	fs.readFile(path, function(err, data) {
		if (err) {
			throw err;
		};

		output = data;
	});
}

function upload(buffer) {
	if (!buffer)
		throw "O parâmetro buffer é nulo.";

	Ftp.put(buffer, '/_testCarreno/test1.txt', function(hadError) {
		if (hadError)
			console.error(hadError);
	});
}

function quit (message) {
	Ftp.raw.quit(function(err, data) {
		if (err) return console.error(err);

		console.log(message);
	});
}

var buffer = readFile("./content/test.txt");
if (buffer) {
	upload(buffer);
	quit("Upload executado com sucesso.");
};
