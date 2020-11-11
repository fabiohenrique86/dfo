function UserController($scope, $http) {

    $scope.user = {};

    $scope.users = [];

    $scope.getAll = function () {
        $http.get('https://localhost:5001/api/user/getall').success(function (users) {
            $scope.users = users;
        });
    }

    $scope.addUser = function () {

        var user = { name: $scope.user.name, age: $scope.user.age, address: $scope.user.address };
        
        $http.post('https://localhost:5001/api/user/create', user).success(function (users) {
            $scope.users = users;
            $scope.user.name = $scope.user.age = $scope.user.address = '';
            toastr.success("User added");
        }).error(function(data) {
        	toastr.error(data.Message);
    	});

    };

    $scope.editUser = function (id) {
        
        $http.get('https://localhost:5001/api/user/getById/' + id).success(function (user) {
            $scope.user = user;
            $scope.edit = true;
        }).error(function(data) {
        	toastr.error(data.Message);
    	});
       
    };

    $scope.applyChanges = function (id) {
        
        var user = { id: id, name: $scope.user.name, age: $scope.user.age, address: $scope.user.address };

        $http.post('https://localhost:5001/api/user/update', user).success(function (users) {
            $scope.users = users;
            $scope.user = {};
            $scope.edit = false;
            toastr.success("User edited");
        }).error(function(data) {
        	toastr.error(data.Message);
    	});
    };
}