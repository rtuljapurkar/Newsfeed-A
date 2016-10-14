(function () {
    var common = angular.module("common.service");
    common.factory("newsResource", ["$resource", "appSettings", newsResource]);

    function newsResource($resource, appSettings) {
        return $resource(appSettings.serverRoot + "/api/news/", null, {
            'update': { method: 'PUT' }
        });
    }
})();