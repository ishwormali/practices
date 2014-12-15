var page = require('webpage').create();
//console.log('The default user agent is ' + page.settings.userAgent);
page.settings.userAgent = 'SpecialAgent';
setInterval(accessWeb,60000);

function accessWeb(){
page.open('https://ielts.britishcouncil.org/nepal', function(status) {
  if (status !== 'success') {
    console.log('Unable to access network');
  } else {
    var ua = page.evaluate(function() {
      return document.getElementById('ctl00_ContentPlaceHolder1_ddlTownCityVenue').children.length;
    });
    console.log(ua);
  }
  
});
}