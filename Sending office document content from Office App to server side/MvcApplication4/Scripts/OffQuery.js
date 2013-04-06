/// <reference path="Office/MicrosoftAjax.js" />
/// <reference path="Office/1.0/office.js" />
/// <reference path="Office/1.0/word-15.js" />

var OffQuery = {};

$.extend(OffQuery, {
    getContent: function (opt, callback) {
        var that = this;
        if ($.isFunction(opt)) {
            callback = opt;
            opt = {};
        }
        
        if (!$.isFunction(callback)) {
            callback = OffQuery.emptyFunction;
        }
        
        opt = $.extend({
            
        }, opt);

        var deff = $.Deferred();

        Office.context.document.getFileAsync(Office.FileType.Compressed, opt, function (asyncResult) {
            if (asyncResult.status == Office.AsyncResultStatus.Succeeded) {
                var file = asyncResult.value;
                var sliceCount = file.sliceCount;
                if (sliceCount > 0) {
                    i = 0;
                    //for (var i = 0; i < sliceCount; i++) {
                    var getSliceFunc = function (j) {
                        file.getSliceAsync(j, function (result) {
                            if (result.status == Office.AsyncResultStatus.Succeeded) {
                                if (opt.FullData == undefined || opt.FullData == null || !$.isArray(opt.FullData)) {
                                    opt.FullData = [];
                                }
                                $.merge(opt.FullData, result.value.data);

                                var ret = callback.call(that, j, result.value.data, result, file, opt);
                                deff.notifyWith(that, [j, result.value.data, result, file, opt]);
                                if (j < file.sliceCount - 1) {
                                    if (ret == undefined || ret == true) {
                                        getSliceFunc(j + 1);
                                    }
                                }
                                else if (j == file.sliceCount - 1) {
                                    deff.resolveWith(that, [opt.FullData, file, opt]);
                                }
                            }
                            else {
                                callback.call(that, null, result, file, opt);
                                deff.rejectWith(that, [j, null, result, file, opt]);

                            }
                        });
                    }
                    getSliceFunc(i);

                }
            }
            else {
                ///on error;
                //deff.resolveWith()
                deff.rejectWith(that,[opt,asyncResult])
            }
            //}
        });

        return deff.promise();

    },
    emptyFunction: function () {
        
        //return { isEmptyFn: true };
    },
    IsEditable:function(){
        return Office.context.document.mode == Office.DocumentMode.ReadWrite;
        Office.context.document.getFileAsync
    },
    setText:function(data,opt,callback){
        var that = this;
        return that._setDataCore(Office.CoercionType.Text, data, opt, callback);
    },
    setHtml: function (data, opt, callback) {
        var that = this;
        return that._setDataCore(Office.CoercionType.Html, data, opt, callback);
    },
    _setDataCore: function (coercionType, data, opt, func) {
        var that = this;
        if ($.isFunction(opt)) {
            func = opt;
            opt = {};
        }

        var tempOpt = $.extend(opt, { returnFn: func });
        //if (!tempOpt.coercionType) {
        tempOpt.coercionType = coercionType;
        //}
        var deff = $.Deferred();

        Office.context.document.setSelectedDataAsync(data, tempOpt, function(asyncResult){
            return that._resolveDeferredCallback(deff, tempOpt, asyncResult);
        });
        return deff.promise();
    },
    getSelectedText:function(opt,func){
        return this._getSelectedCore(Office.CoercionType.Text, opt, func);

    },
    getSelectedHtml:function(opt,func){
        return this._getSelectedCore(Office.CoercionType.Html, opt, func);
    },
    _getSelectedCore: function (resultType, opt, func) {
        var that = this;
        if($.isFunction(opt)){
            func = opt;
            opt = {};
        }

        var tempOpt = $.extend(opt, {returnFn:func});
        
        var deff=$.Deferred();
        Office.context.document.getSelectedDataAsync(resultType, tempOpt, function (asyncResult) {
            
            that._resolveDeferredCallback(deff,tempOpt,asyncResult)
        });

        return deff.promise();
    },
    _resolveDeferredCallback: function (deff, opt,asyncResult) {
        if (opt.returnFn) {
            opt.returnFn.call(this, asyncResult, opt);

        }
        var context = opt.context || this;
        if (asyncResult.status == Office.AsyncResultStatus.Succeeded) {
            deff.resolveWith(context, [asyncResult, opt]);
        }
        else {
            deff.rejectWith(context, [asyncResult, opt]);
        }
    }

});