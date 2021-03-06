var webdriver=require('selenium-webdriver');
var Q=require('q');

var client = require('twilio')('abc', 'zys');
var driver=new webdriver.Builder()
			.withCapabilities(webdriver.Capabilities.chrome()).build();

// var myurl='file:///C:/Users/ishan/Desktop/smstest/British%20Council%20IELTS%20Online%20Application.html';
 var myurl='https://ielts.britishcouncil.org/nepal';
var elementid='ctl00_ContentPlaceHolder1_ddlDateMonthYear';//'ctl00_ContentPlaceHolder1_ddlTownCityVenue';

setInterval(checkSite,240000);
var beepstarted=false;
process.on('uncaughtException', function(err) {
  console.log('Caught uncaught exception: ' + err);
});

checkSite();

function checkSite(){
	Q(Q.Promise(function(resolve,reject){
		console.log('checking site ');
		driver.get(myurl);
		var children=driver.findElement(webdriver.By.id(elementid))
		.findElements(webdriver.By.tagName('option'));
		//console.log(children);
		// webdriver.promise.filter(children,function(mychild){
		// 	return mychild.getText().indexOf('no test date')<0;
		// })
		return children.then(function(options){
			console.log('found options :'+options.length);
			if(options.length>0){
				return options[0].getText().then(function(txt){
					if(txt.indexOf('no test date')<0){
						console.log('Date found '+txt);
						if(!beepstarted){
							startBeeping();
							beepstarted=true;
						}

						//sendSMS('new ielts date');
					}
				});


			}
			return true;
			// console.log('closing driver');
			//driver.quit();
		});
	}))
	.catch(function(err){
		console.log('.....................ERROR...........');
		console.log(err);
	});
}


function sendSMS(message){
	console.log('sending sms '+message);
	return;
//Send an SMS text message
client.sendMessage({

    to:'+9779841627969', // Any number Twilio can deliver to
    from: '+16506845115', // A number you bought from Twilio and can use for outbound communication
    body: message // body of the SMS message

}, function(err, responseData) { //this function is executed when a response is received from Twilio

    if (!err) { // "err" is an error received during the request, if any

        // "responseData" is a JavaScript object containing data received from Twilio.
        // A sample response from sending an SMS message is here (click "JSON" to see how the data appears in JavaScript):
        // http://www.twilio.com/docs/api/rest/sending-sms#example-1
        console.log('sms send complete');
        // console.log(responseData.from); // outputs "+14506667788"
        // console.log(responseData.body); // outputs "word to your mother."

    }
    else{
    	console.log('error while sending SMS');
    	console.log(err);
    }
});
}

function startBeeping(){
	setInterval(function(){
		process.stdout.write('\x07');
	},2000);

}
