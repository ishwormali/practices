

function PersonViewModel() {
    var self = this;
    self.baseUrl = 'api/Person';
    self.form = ko.observable(new Person());
    self.People = ko.observableArray([]);
    self.GetByFirstName = function (person) {
        $.ajax({
            url: self.baseUrl + '?firstName=' + person.FirstName,
            type: 'GET',
            contentType: 'application/json'

        }).success(self.loadData)
       .fail(function (xhr) {
           alert(xhr.responseText);
       });
    };
    self.GetById = function (person) {
        $.ajax({
            url: self.baseUrl + '/' + person.Id,
            type: 'GET',
            contentType: 'application/json'
            
        }).success(self.loadData)
       .fail(function (xhr) {
           alert(xhr.responseText);
       });
    };
    self.loadData=function(data){
        self.form(data);
    };
    self.changeMarried = function (person) {
        
        $.ajax({
            url: self.baseUrl,
            type: 'PUT',
            //dataType: 'json',
            contentType: 'application/json',
            data: ko.toJSON(person)
        }).success(self.refreshGrid)
       .fail(function (xhr) {
           alert(xhr.responseText);
       });
        return true;
    };
    self.save = function () {
       //console.log(ko.toJSON( self.form()));
        $.ajax({
            url: self.baseUrl,// + '?someParam=someparamvalue',
            type: 'POST',
            //dataType: 'json',
            contentType:'application/json',
            data: ko.toJSON( self.form())
        }).success(self.refreshGrid)
       .fail(function (xhr) {
           alert(xhr.responseText);
       });
    };
    
    self.remove = function (person) {
       // alert(person.Id);
        $.ajax({
            url: self.baseUrl + '/' + person.Id,
            type: 'DELETE',
            //dataType: 'json',
           // contentType:'application/json',
            data:  person.Id +''
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

function Person() {
    var self = this;
    self.FirstName = ko.observable('');
    self.LastName = ko.observable('');
    self.Address = ko.observable('');
    self.PhoneNumber = ko.observable('');
    self.IsMarried = ko.observable(false);
}