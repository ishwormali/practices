
var http=require('http');
var url=require('url');
var querystring = require('querystring');
function start(route){
console.log('starting server');
function callback(request,response){
    response.writeHead('200',{'Content-Type':'text/plain'});
    var urlObj=url.parse(request.url);
	var pathname=urlObj.pathname;
	response.write('pathname= '+pathname);
	//response.write('hellow world');
	var parsed = querystring.parse(urlObj.query);
	//console.log(parsed);
	if (parsed.query) {
	    response.write('\n querys='+parsed.query);
	}
	route(pathname);
	response.end();
}
http.createServer(callback).listen(5858);

console.log('server started');

};

exports.start=start;