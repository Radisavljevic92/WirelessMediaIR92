app.controller("UnosProizvodaCtrl", function ($scope, $http, $mdDialog, $q, AddressPrefix, $location) {

    $scope.alertDialog = function (element, naslov, poruka, ok) {
        $mdDialog.show(
                $mdDialog.alert().parent(angular.element(document.querySelector(element))).clickOutsideToClose(true).title(naslov).textContent(poruka).ok(ok)
         );
    };
 
    //Popunjavanje select option sa proizvodjačima
    $http.post("" + "/api/UnosNovogProizvoda/VratiProizvodjaca", "Content-Type:application/json").then(function success(result) {
        if (result.data.success == true) {
            console.log("aaaaa");
            $scope.proizvodjac = result.data.data;
        } else {
            $scope.alertDialog("bodyWrap", "Obaveštenje", "Došlo je do greške prilikom prikupljanja podataka o proizvođačima.", "OK");          
        }
    });

    //Popunjavanje select option sa dobavljacima
    $http.post("" + "/api/UnosNovogProizvoda/VratiDobavljaca", "Content-Type:application/json").then(function success(result) {
        if (result.data.success == true) {
            console.log("bbbbb");
            $scope.dobavljac = result.data.data;
        } else {
            $scope.alertDialog("bodyWrap", "Obaveštenje", "Došlo je do greške prilikom prikupljanja podataka o dobavljačima.", "OK");
        }
    });

    //Popunjavanje select option sa kategorijama
    $http.post("" + "/api/UnosNovogProizvoda/VratiKategoriju", "Content-Type:application/json").then(function success(result) {
        if (result.data.success == true) {
            console.log("cccc");
            $scope.kategorija = result.data.data;
        } else {
            $scope.alertDialog("bodyWrap", "Obaveštenje", "Došlo je do greške prilikom prikupljanja podataka o kategorijama.", "OK");         
        }
    });

    //Snimanje novog proizvoda (nakon klika na dugme)
    $scope.SnimiProizvod = function () {
        $scope.PodaciZaSnimanje =
        {
            IdProizvodjac: $scope.Proizvod.NazivProizvodjaca,
            IdDobavljac: $scope.Proizvod.NazivDobavljaca,
            IdKategorija: $scope.Proizvod.NazivKategorije,
            Naziv: $scope.Proizvod.NazivProizvoda,
            Opis: $scope.Proizvod.OpisProizvoda,
            Cena: $scope.Proizvod.CenaProizvoda
        };
        var podaciZaUnos = $scope.PodaciZaSnimanje;
        $http.post("" + "/api/UnosNovogProizvoda/SnimiProizvod", podaciZaUnos, "Content-Type: application/json").then(function success(result) {
            if (result.data.success == true) {
                $scope.alertDialog("bodyWrap", "Obaveštenje", "Uspešno ste snimili proizvod.", "OK");
            } else {
                $scope.alertDialog("bodyWrap", "Obaveštenje", "Došlo je do greške prilikom snimanja proizvoda.", "OK");               
            }
        });
    }
  

});