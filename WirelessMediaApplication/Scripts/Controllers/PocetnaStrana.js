app.controller("PocetnaStranaCtrl", function ($scope, $http, $mdDialog, $q, AddressPrefix, $location) {

    $scope.alertDialog = function (element, naslov, poruka, ok) {
        $mdDialog.show(
                $mdDialog.alert().parent(angular.element(document.querySelector(element))).clickOutsideToClose(true).title(naslov).textContent(poruka).ok(ok)
         );
    };
   
    //Popunjavanje liste proizvoda
    $http.post("" + "/api/PocetnaStrana/VratiProizvode", "Content-Type:application/json").then(function success(result) {
        if (result.data.success == true) {           
            console.log(result.data.data);
            $scope.items = result.data.data;
        } else {
            $scope.alertDialog("bodyWrap", "Obaveštenje", "Došlo je do greške prilikom prikupljanja podataka o proizvodima.", "OK");
            $scope.items = [];
        }
    });

    //redirekcija na stranu izmene (prosledjuje se id proizvoda)
    $scope.RedirectIzmena = function (id) {       
        window.location.href = AddressPrefix.url + '/Home/IzmenaProizvoda/?id=' + id;
    };

    //redirekcija na stranicu unosa 
    $scope.RedirectUnosProizvoda = function (id) {
        window.location.href = AddressPrefix.url + '/Home/UnosNovogProizvoda';
    };

});

