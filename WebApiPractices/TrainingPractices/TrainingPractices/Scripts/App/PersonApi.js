

function Person() {
    var self = this;
    self.baseUrl = 'api/Person';

    self.People = ko.observableArray([]);
    self.remove = function (person) {
        
        $.ajax({
            url: self.baseUrl,
            type: 'POST',
            dataType: 'json',
            //contentType:'application/json',
            data: { personId: person.Id }
        }).success(self.refreshGrid)
        .fail(function (xhr) {
            alert(xhr.responseText);
        });
    }

    self.init = function () {
        self.refreshGrid();
    };

    self.refreshGrid=function(){
        $.ajax({
            url: self.baseUrl,
            type: 'GET'
        }).success(function (data) {
            self.People(data);
        }).fail(function (xhr) {
            alert(xhr.responseText);
        });
    }

};