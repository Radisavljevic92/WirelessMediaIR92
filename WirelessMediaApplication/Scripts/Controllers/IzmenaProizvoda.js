app.controller("IzmenaProizvodaCtrl", function ($scope, $http, $mdDialog, $q, AddressPrefix, $location) {

    $scope.alertDialog = function (element, naslov, poruka, ok) {
        $mdDialog.show(
                $mdDialog.alert().parent(angular.element(document.querySelector(element))).clickOutsideToClose(true).title(naslov).textContent(poruka).ok(ok)
         );
    };

    //inicijalizacija proizvoda
    $scope.Proizvod =
    {
        NazivProizvoda:"",
        OpisProizvoda:"",
        CenaProizvoda:0,
        NazivDobavljaca:"",
        NazivProizvodjaca:"",
        NazivKategorije: "",
        Id:0
    };

    //pri ucitavanju stranice popunjava se  forma (prosledjuje se id proizvoda)
    $scope.init = function (Id) {     
        $scope.IdProizvoda = Id;
        $http.post("" + "/api/IzmenaProizvoda/VratiProizvodePoId", $scope.IdProizvoda, "Content-Type: application/json").then(function success(result) {

            if (result.data.success == true) {       
                console.log(result.data.data[0].NazivProizvoda);
                $scope.Proizvod.NazivProizvoda = result.data.data[0].NazivProizvoda;
                $scope.Proizvod.OpisProizvoda = result.data.data[0].OpisProizvoda;
                $scope.Proizvod.CenaProizvoda = result.data.data[0].CenaProizvoda;
                $scope.Proizvod.NazivDobavljaca = result.data.data[0].NazivDobavljaca;
                $scope.Proizvod.NazivProizvodjaca = result.data.data[0].NazivProizvodjaca;
                $scope.Proizvod.NazivKategorije = result.data.data[0].NazivKategorije;
                $scope.Proizvod.Id = result.data.data[0].Id;
            } else {             
                $scope.alertDialog("bodyWrap", "Obaveštenje", "Došlo je do greške prilikom prikupljanja podataka o proizvodu.", "OK");
                $scope.items = [];
            }
        });
    };

    //Snimanje izmene Proizvoda
    $scope.SnimiPromenu = function ()
    {
        $scope.PodaciZaSnimanje =
        {
            Id: $scope.Proizvod.Id,
            Naziv: $scope.Proizvod.NazivProizvoda,
            Opis: $scope.Proizvod.OpisProizvoda,
            Cena: $scope.Proizvod.CenaProizvoda                   
        };
        
        var podaci = $scope.PodaciZaSnimanje;

        $http.post("" + "/api/IzmenaProizvoda/SnimiPromene", podaci, "Content-Type: application/json").then(function success(result) {
            if (result.data.success == true) {
                $scope.alertDialog("bodyWrap", "Obaveštenje", "Uspešno ste izmenili podatke o proizvodu.", "OK");
            } else {
                $scope.alertDialog("bodyWrap", "Obaveštenje", "Došlo je do greške prilikom izmene podataka o proizvodu.", "OK");        
            }
        });
    }

});