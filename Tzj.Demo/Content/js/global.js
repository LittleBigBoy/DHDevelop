var _loadobj;
var Loading = function () {
    _loadobj = layer.load(0, { shade: [0.5, '#f9f9f9'] });
}
var LoadEnd = function () {
    layer.close(_loadobj);
}