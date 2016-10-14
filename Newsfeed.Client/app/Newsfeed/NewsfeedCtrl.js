(function () {

    var app = angular.module("NewsfeedMgmt");

    app.controller("NewsfeedCtrl", ["newsResource", NewsfeedCtrl]);

    function NewsfeedCtrl(newsResource) {
        vm = this;
        vm.newItem = {};
        vm.message = '';

        vm.open = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = !vm.opened;
        };
        vm.isBusy = true;
        vm.getNews = function() {
            newsResource.query({ $orderby: "PublishedDate desc" },
                function(data) {
                    vm.newsfeed = data;
                    vm.isBusy = false;
                });
        }
        vm.getNews();
       

        vm.getNewItem = function() {
            newsResource.get({ id: 0 },
                function(data) {
                    vm.newItem = data;                   
                },
                function(response) {
                    vm.message = response.statusText + "\r\n";
                    if (response.data.exceptionMessage)
                        vm.message += response.data.exceptionMessage;
                });
        }
        vm.getNewItem();

    vm.submit = function () {
        vm.message = '';
        vm.opened = false;
            vm.newItem.$save(
                function (data) {                   
                     vm.message = "... Save Complete";
                     vm.getNews();
                     vm.getNewItem();
                },
                function (response) {
                    vm.message = response.statusText + "\r\n";
                    if (response.data.modelState) {
                        for (var key in response.data.modelState) {
                            vm.message += response.data.modelState[key] + "\r\n";
                        }
                    }
                    if (response.data.exceptionMessage)
                        vm.message += response.data.exceptionMessage;
                });
           
        };

        vm.cancel = function(editForm) {
            editForm.$setPristine();
            vm.newItem = {};
            vm.message = '';
        }

      

    };

})();