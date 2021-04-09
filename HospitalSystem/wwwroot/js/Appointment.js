flagInitDate = 1;
var dDate;

var objAppointment = {
    AddEvent: function () {
        $('#sectionCreate').show();
        $('#sectionView').hide();
        $("#btnSaveAppointment").show();
        $('#btnDeleteAppointment').hide();
        this.ClearModalInfo();
        $("#commnet").prop("disabled", false);
        //console.log(data);
        $("#largeModalLabel").text("Agregar Cita - " + dDate.toString());
        this.ListPatients();
        $('#largeModal').modal('show');
    },

    SaveAppointment: function () {

        var urlEnvio = "Appointment/SaveAppointment";    

        var request = {
            idPatient: $("#selectPatients").val(),
            scomment: $("#commnet").val(),
            sidsHours: $("#selectHours").val().join(','),
            date: dDate
        };

        $.ajax({
            url: urlEnvio,
            method: 'POST',
            contentType: 'application/x-www-form-urlencoded',
            data: request,
            success: function (data) {
                if (data.data.result.resultado != 0) {
                    setTimeout(function () {
                        swal({
                            title: "Cita Registrada",
                            text: "La cita fue creada satisfactoriamente",
                            type: "success"
                        }, function () {
                                $('#largeModal').modal('hide');
                                objAppointment.ListAppointments();
                        });
                    }, 1000);
                } else {
                    swal({
                        title: "Resultado",
                        text: "Ocurrio un error al registrar la cita",
                        type: "error"
                    });
                }
            },
            error: function (a, b, c) {
                console.log('%cError: The information could not be obtained.', 'color:red');
            },
            complete: function (data) {
                $('body').removeClass('busy');
            }
        });

    },

    ListPatients: function () {
        var urlEnvio = "Appointment/GetPatients";        
        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            success: function (data) {
                data.lista.forEach(res => {
                    $('#selectPatients').append("<option value='" + res.nidpatient + "' >" + res.scompletename + "</option>")
                });
                $("#selectPatients").selectpicker("refresh");
            },
            error: function (a, b, c) {
                console.log('%cError: The information could not be obtained.', 'color:red');
            },
            complete: function (data) {
                $('body').removeClass('busy');
            }
        });
    },
    ListHours: function () {
        var urlEnvio = "Appointment/GetHours";
        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { idPatient: $("#selectPatients").val(), date: dDate },
            success: function (data) {

                data.lista.forEach(res => {
                    var isDisabled = res.ndisabled == 1 ? 'disabled' : '';
                    $('#selectHours').append("<option value='" + res.nidconfighora + "' " + isDisabled + ">" + res.shora + "</option>")
                });
                $("#selectHours").selectpicker("refresh");
                $('#largeModal').modal('show');
            },
            error: function (a, b, c) {
                console.log('%cError: The information could not be obtained.', 'color:red');
            },
            complete: function (data) {
                $('body').removeClass('busy');
            }
        });
    },

    ListAppointments: function () {
        var urlEnvio = "Appointment/GetAppointments";
        $("#addEvent").html("");
        $("#addEvent").append('<i class="zmdi zmdi-plus"></i> Añadit Evento - ' + dDate);

        $('#listaAppointments').html("");
        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { date: dDate },
            success: function (data) {
                if (data.lista != null) {
                    data.lista.forEach(res => {
                        //var objDiv = '<div class="event-name b-greensea"> XEVENT <a class="text-muted event-remove"><i class="zmdi zmdi-delete"></i></a> </div>';
                        var objDiv = '<div class="event-name b-greensea" style="cursor: pointer" onclick="objAppointment.ViewAppointment(' + res.nidappointment + ')"> XEVENT </div>';
                        objDiv = objDiv.replace("XEVENT", res.spatientname + " - " + res.sinitappointment);
                        $('#listaAppointments').append(objDiv);
                    });
                }                
            },
            error: function (a, b, c) {
                console.log('%cError: The information could not be obtained.', 'color:red');
            },
            complete: function (data) {
                $('body').removeClass('busy');
            }
        });
    },

    ClearModalInfo: function () {
        $("#selectPatients").empty();
        $("#selectPatients").selectpicker("refresh");
        $("#selectHours").empty();
        $("#selectHours").selectpicker("refresh");
        $("#commnet").val("");
    },

    SetDate: function () {
        var data = sessionStorage.getItem('diaAppointment');
        var dateObject = new Date(data);
        var dateJunior = moment(data).format('DD/MM/YYYY');
        let day = dateObject.getDate() + (flagInitDate == 1 ? 0 : 1);
        let month = dateObject.getMonth() + 1;
        let year = dateObject.getFullYear();
        //flagInitDate = 0;
        let date = (day.toString().length == 1 ? "0" + day : day) + "/" + (month.toString().length == 1 ? "0" + month : month) + "/" + year;
        dDate = date;
    },

    ViewAppointment: function (idAppointment) {

        $('#sectionCreate').hide();
        $('#sectionView').show();
        $("#btnSaveAppointment").hide();
        $('#btnDeleteAppointment').show();

        $("#largeModalLabel").text("Cita - " + dDate.toString());
        $("#listHoursView").html("");

        var urlEnvio = "Appointment/GetAppointmentById";
        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { idAppointment: idAppointment },
            success: function (data) {

                $("#labelName").text(data[0].snamepatient);
                $("#commnet").val(data[0].scoment);
                $("#commnet").prop("disabled", true);

                data.forEach(res => {
                    $("#listHoursView").append('<li class="list-group-item">' + res.svalueini + ' - ' + res.svaluefin + '</li>');
                });

                $("#btnDeleteAppointment").unbind();
                $("#btnDeleteAppointment").click(() => {
                    objAppointment.DeleteAppointment(data[0].nidappointment);
                });

                $('#largeModal').modal('show');
            },
            error: function (a, b, c) {
                console.log('%cError: The information could not be obtained.', 'color:red');
            },
            complete: function (data) {
                $('body').removeClass('busy');
            }
        });
    },

    DeleteAppointment: function (idAppointment) {

        var urlEnvio = "Appointment/DeleteAppointment";

        swal({
            title: "Eliminar Cita",
            text: "¿Esta seguro que desea eliminar la Cita?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Eliminar",
            cancelButtonText: "Cancelar",
            closeOnConfirm: false,
            closeOnCancel: false
        }, function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    url: urlEnvio,
                    contentType: 'application/x-www-form-urlencoded',
                    type: 'DELETE',
                    data: { nidAppointment: idAppointment },
                    success: function (data) {
                        if (data.resultado == 0) {
                            setTimeout(function () {
                                swal({
                                    title: "Eliminado!",
                                    text: data.mensaje,
                                    type: "success"
                                }, function () {
                                        $('#largeModal').modal('hide');
                                        objAppointment.ListAppointments();
                                });
                            }, 1000);
                        }
                        else swal("Error", "Ocurrion un error al eliminar el registro", "error");
                    },
                    error: function (a, b, c) {
                        console.log('%cError: The information could not be obtained.', 'color:red');
                    },
                    complete: function (data) {
                        $('body').removeClass('busy');
                    }
                });
            } else {
                swal("Cancelado", "Se ha cancelado la eliminación de la Cita", "error");
            }
        });   

    }
}



$(document).ready(function () {
    $('#selectHours').selectpicker();

    $("#btnSaveAppointment").click(() => {
        objAppointment.SaveAppointment();
    });
    

    sessionStorage.setItem('diaAppointment', new Date());
    objAppointment.SetDate();
    flagInitDate = 0;
    objAppointment.ListAppointments();
});