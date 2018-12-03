var Login = new BasePage();
$.extend(Login, {
    submit: function () {
        Loading();
        var userId = $("#u1272_input").val();
        var passWord = $("#u1268_input").val();
        $.ajax({
            url: Login.baseUrl + "Account/LoginOn",
            data: {
                userName: userId,
                passWord: passWord,
                timestamp: new Date().getTime()
            },
            beforeSend: function (xhr) {
                //xhr.setRequestHeader('content-type', 'application/x-www-form-urlencoded');
            },
            dataType: 'json',
            async: false,
            type: 'get',
            success: function (data) {
                LoadEnd();
                if (data.StatusCode === 200) {
                    Login.localStorageSet('authid', data.Data);
                } else {
                    layer.alert(data.Data);
                }
                console.log(data);
            },
            error: function (req) {
                layer.alert(data.Data);
                LoadEnd();
            }
        });
    }
})