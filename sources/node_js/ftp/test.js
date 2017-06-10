var JSFtp = require("jsftp");
var fs = require("fs");

var Ftp = new JSFtp({
	host: "186.202.139.26",
	port: 22,
	user: "hmlwunderman",
	pass: "Ne3w#wun51a"
});

fs.readFile("./content/test.txt", function(err, data) {

	if (err) {
		throw err;
	};

	upload(data);
});

function upload(buffer) {

	if (!buffer)
		throw "O parâmetro buffer é nulo.";

	Ftp.put(buffer, '/_testCarreno/test1.txt', function(hadError) {
		if (!hadError)
			quit("Upload executado com sucesso.");
		else
			console.error(hadError);
	});
}

function quit (message) {
	Ftp.raw.quit(function(err, data) {
		if (err) return console.error(err);

		console.log(message);
	});
}