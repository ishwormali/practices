/// <reference path="../jquery.validate.js" />
/// <reference path="../jquery.validate.unobtrusive.js" />

//$.validator.unobtrusive.adapters.addSingleVal("nospace", "trimfirst");/*myparams in validator function becomes single value object when used with this*/

$.validator.unobtrusive.adapters.add("nospace"
    ,["trimfirst","trimsecond"]/*should be an array of attributes value expected in params property of options*/
    , function (options) {
    var params = {
        trimFirst: options.params.trimfirst
    };
    
    options.rules['nospace'] = options.params; //this is passed as myparams in validator function.
    if (options.message) {
        options.messages['nospace'] = options.message;
    }
});

$.validator.addMethod("nospace", function (value, element, myparams/* this is sinle valued when used with addSingleVal adapter helper*/) {
    var temp = myparams;
    var strValue=value+'';
    strValue = myparams.trimfirst == "True" ? $.trim(strValue) : strValue;
    var result = true;
    
    if (strValue.replace(' ', '').length != strValue.length) {
        //result = false;
        return false;
    }

    return result;
});