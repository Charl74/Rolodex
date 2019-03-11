/// <reference path="angular.js" />
var PBApp = angular.module("PBApp", ["ngRoute"])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "Template/Contacts.html",
                controller: "contactsController"
            })
            .when("/addNewContact", {
                templateUrl: "Template/AddNewContact.html",
                controller: "addNewContactController"
            });
        $locationProvider.html5Mode(true);
    });

//PBApp.controller("appController", function($scope, $location) {
//    $scope.isActive = function(path) {
//        return $location.path() === path;
//    };
//});

PBApp.controller("contactsController", function($scope, $http) {
    $http({
        method: "GET",
        //url: '/PhoneBookSPA/api/PhoneBook?userInternalId=' + userIntenalId
        url: 'http://localhost:59686/api/PhoneBook?userInternalId=' + document.getElementById("UserInternalId").value
        //'7f55950d-e493-4f37-9528-d9c998608a0d'
    }).then(function(response) {
        //alert(JSON.stringify(response.data));
        $scope.entries = response.data;
        //console.log($scope.loyaltyRecord);
    }, function(response) {
        console.log(response.errorString);
    });
});

PBApp.controller("addNewContactController", function ($scope, $http) {
    $scope.addNewContact = function () {
        $http({
            method: 'POST',
            //url: '/PhoneBookSPA/api/PhoneBook'
            url: 'http://localhost:59686/api/PhoneBook',
            data: {
                Person: document.getElementById('Person').value,
                Number: document.getElementById('Number').value,
                UserName: document.getElementById('UserName').value,
                UserInternalId: document.getElementById("UserInternalId").value
            },
            headers: { 'Content-Type': 'application/json' }
        }).success(function(data, status, headers) {
            $scope.message = status;
        });
    }
});