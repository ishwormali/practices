var express = require('express');
var router = express.Router();

/* GET home page. */
router.get('/', function(req, res) {
  res.render('index', { title: 'Express' });
});

router.get('/hell', function(req, res) {
  res.send("hell");
});

router.get('/userlist',function(req,res){
	var db=req.db;
	var collection=db.get('usercollection');
	collection.find({},{},function(e,docs){
		res.render('userlist',{
			"userlist":docs

		});
	});
//res.send('something');
});

module.exports = router;
