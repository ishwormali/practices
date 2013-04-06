/// <reference path="jquery-1.7.1.js" />
/// <reference path="Office/1.0/office.js" />
/// <reference path="OffQuery.js" />



function saveContent() {

    $.when(OffQuery.getContent({ sliceSize: 50000 }, function (j, data, result, file, opt) {
        var temp = data;

    })).then(function (finalByteArray, file, opt) {
        //this function is called at the end.
        //FullData contains byte array.
        //file is the file object of Office.js
        //opt is the option supplied at the very beginning when calling OffQuery.getContent() function.
        var fileContent = OSF.OUtil.encodeBase64(finalByteArray); //encode the byte array into base64 string.
        sendFileMethod(fileContent)
        

    }).progress(function(j, chunkOfData, result, file, opt){
        //handle the progress here.
    });
}

function sendFileMethod(fileContent) {

    $.ajax({
        url: saveContentUrl,
        data: { contentByte: fileContent },
        type: 'POST'


    }).then(function (a, b, c) {
        var tempa = a;
        var tempb = b;

    });
}