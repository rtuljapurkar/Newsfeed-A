(function () {
	"use strict"
    var common = angular.module("common.service", ["ngResource"]);

    common.constant("appSettings", { 
        "serverRoot": "http://localhost:11810"
    });

})();