/// <reference path="./nodelib/node.js"/>


var server=require('./server');
var router=require('./router');

server.start(router.route);
