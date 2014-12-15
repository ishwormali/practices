var http=require('http');
var path=require('path');
var static=require('node-static');
var fileServer=new static.Server('/content');

http.createServer(function(request,response){
	 console.log(request.url);
	//request.addListener('end', function () {
	//	console.log('end called');
fileServer.serve(request, response);
// });
// response.writeHead(200,{'Content-Type':'text/html'});
// var lookup=path.basename(decodeURI(request.url));
// if(lookup==''){
// 	lookup='HOME PAGE';
// }
// response.end(lookup);

}).listen(1111);