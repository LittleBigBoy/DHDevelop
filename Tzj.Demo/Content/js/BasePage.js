var BasePage = function() {
    this.baseUrl = "http://localhost:8810/api/";
    this.exp = 86400000;
};
BasePage.prototype= {
    localStorageSet: function(key,value) {
        var curTime = new Date().getTime();
        localStorage.setItem(key,JSON.stringify(({ data: value, time: curTime })));
    },
    localStorageGet: function(key) {
        var data = localStorage.getItem(key);
        var dataObj = JSON.parse(data);
        if (new Date().getTime() - dataObj.time > exp) {
            localStorage.removeItem(key);
            return null;
        } else {
            var dataObjDataToJson = JSON.parse(dataObj.data);
            return dataObjDataToJson;
        }
    }
}