var PBController = function($scope, $http) {
    var entries = function(userIntenalId) {
        $http({
            method: 'GET',
            url: '/PhoneBookSPA/api/PhoneBook?cardList[0]=' + userIntenalId
        }).then(function(response) {
            alert(JSON.stringify(response.data));
            $scope.entries = response.data;
            //console.log($scope.loyaltyRecord);
        }, function(response) {
            console.log(response.errorString);
        });
    }
}