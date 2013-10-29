
var http=require('http');
var url=require('url');

function start(route){
console.log('starting server');
function callback(request,response){
	response.writeHead('200',{'Content-Type':'text/plain'});
	var pathname=url.parse(request.url).pathname;
	response.write('pathname= '+pathname);
	//response.write('hellow world');
	
	route(pathname);
	response.end();
}
http.createServer(callback).listen(555);

console.log('server started');

};

exports.start=start;