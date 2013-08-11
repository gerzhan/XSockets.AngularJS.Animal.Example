

function AnimalsController($scope,xsocket) {
    $scope.animals = [];
    $scope.order = "Name"; // Order the data in the repater by the Name Property

    // Expose a function that will be used to remove an 'animal'
    $scope.removeAnimal =  function (id) {
        xsocket.publish("removeAnimal", { id: id }); // tel others and me that the animal is removed..
    };
  
    xsocket.subscribe("getAnimals").process(function (data) {
        $scope.animals = data; // data is retrived.
    });
  
    // If someone adds and animal, add it to the list
    xsocket.subscribe("addAnimal").process(function (added) {
        $scope.animals.unshift(added); // add the animal to the "list"
    });
    
    // Some has removed a animal, lets get rid of it from the list...
    xsocket.subscribe("removeAnimal").process(function (removed) {
        var index = $scope.animals.indexOf(removed);
        $scope.animals.splice(index, 1);
    });

    xsocket.publish("getAnimals"); // Get the list of animals

};


function CreateAnimalController($scope,$location,xsocket) {
    $scope.animal = {
        Name: 'Ape',
        Description: 'Animals are nice...'
    };
    
    // Expose a methid that will be used to create an animal...
    $scope.createAnimal = function () {
        xsocket.publish("addAnimal", $scope.animal);
        $location.path('/animals/'); // Lets route/navigate to the list ...
    };
}

