var _Layout = {
    LoadInfoData: function (username) {

        var urlEnvio = "Login/GetUserInfo";

        $.ajax({
            url: urlEnvio,
            //contentType: 'application/json',
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { username: username },
            //async: false,
            //dataType: 'JSON',
            success: function (data) {

                if (data == null) {
                    window.location = "Login";
                }
                //~/assets/images/random-avatar7.jpg
                $("#imgProfile").attr("src", "data:image/png;base64," + data.base64image);
                $("#nameUser").text(data.sfirstname + ' ' + data.slastname);
                $("#patients").html(data.npatients + '<i>Pacientes</i>');
                $("#pendings").html(data.pendings + '<i>Pendientes</i>');
                $("#visits").html(data.nvisits + '<i>Visitas</i>');
            },
            error: function (a, b, c) {
                console.log('%cError: The information could not be obtained.', 'color:red');
            },
            complete: function (data) {
                $('body').removeClass('busy');
            }
        });   

    }
}