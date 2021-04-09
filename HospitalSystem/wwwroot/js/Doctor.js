
flagEdit = "";
nIdDoctor = 0;
spathDoctor = '';


var doctorObject = {
    ValidateEmail: function (email) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    },

    SaveDoctor: function () {

        //Validar información
        var isCorrect = true;
        var messageError = "";

        if ($("#sfirstName").val() == '') {
            messageError += "- Nombre\n";
            isCorrect = false;
        }
        if ($("#slastName").val() == '') {
            messageError += "- Apellido Paterno\n";
            isCorrect = false;
        }
        if ($("#slastName1").val() == '') {
            messageError += "- Apellido Materno\n";
            isCorrect = false;
        }
        if ($("#dbrithDate").val() == '') {
            messageError += "- Fecha de Nacimiento\n";
            isCorrect = false;
        }
        if ($("#sgender").val() == '') {
            messageError += "- Genero\n";
            isCorrect = false;
        }
        if ($("#sspeciality").val() == '') {
            messageError += "- Especialidad\n";
            isCorrect = false;
        }
        if ($("#semail").val() != '') {
            var resultEmail = this.ValidateEmail($("#semail").val());
            messageError += resultEmail != true ? "- Formato de Correo\n" : "";
            isCorrect = resultEmail;
        }
        if ($("#user").val() == '') {
            messageError += "- Usuario\n";
            isCorrect = false;
        }
        if (($("#password").val() == '' || $("#confirmpassword").val() == '') && flagEdit != "1") {
            messageError += "- Constraseña\n";
            isCorrect = false;
        } else {
            if (($("#password").val() != $("#confirmpassword").val()) && flagEdit != "1") {
                messageError += "- Constraseñas no coinciden\n";
                isCorrect = false;
            }
        }

        if (!isCorrect) {
            swal({
                title: "Resultado",
                text: "Completar la siguiente información:\n" + messageError,
                type: "error"
            });
            return;
        }


        var request = {
            NIDDOCTOR: nIdDoctor,
            SFIRSTNAME: $("#sfirstName").val(),
            SSECONDNAME: $("#sSecondName").val(),
            SLASTNAME: $("#slastName").val(),
            SLASTNAME1: $("#slastName1").val(),
            SBIRTHDATE: $("#dbrithDate").val(),
            SGENDER: $("#sgender").val(),
            SSPECIALITY: $("#sspeciality").val(),
            NPHONE: $("#sphone").val(),
            SEMAIL: $("#semail").val(),
            SWEBSITE: $("#swebSite").val(),
            SPATHIMAGE: spathDoctor,
            SABOUT: $("#resume").val(),
            SUSER: $("#user").val(),
            SPASSWORD: $("#password").val(),
        }

        var urlEnvio = "Doctor/SaveDoctor";

        var formData = new FormData();


        formData.append('json', JSON.stringify(request));
        formData.append('flagEdit', flagEdit);
        Dropzone.forElement("#frmFileUpload").files.forEach((file) => {
            formData.append('File', file);
        });


        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (data) {
                if (data.data.resultado != 0) {
                    setTimeout(function () {
                        swal({
                            title: flagEdit == "" ? "Doctor Registrado!" : "Doctor Actualizado!",
                            text: data.data.mensaje,
                            type: "success"
                        }, function () {
                            window.location = "Doctor";
                        });
                    }, 1000);
                } else {
                    swal({
                        title: "Resultado",
                        text: data.data.mensaje,
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

    AgregarDoctor: function () {
        this.ClearForm();
        $("#user").prop("disabled", false);
        $("#largeModalLabel").text("Agregar Doctor");
        $('#largeModal').modal('show');
    },

    ViewDoctor: function (niddoctor) {
        var urlEnvio = "Doctor/GetDoctorById";
        this.ClearForm();

        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { niddoctor: niddoctor },
            success: function (data) {

                const birthdate = moment(data.doctor.dbirthdate).format("DD/MM/YYYY");
                $("#imageProfileDoctor").attr("src", "data:image/png;base64," + data.doctor.base64Image);
                $("#snameViewDoctor").text(data.doctor.scompletename);
                $("#specialityViewDoctor").text(data.doctor.sspeciality);
                $("#dbirthdateViewDoctor").text(birthdate);
                $("#semailViewDoctor").text(data.doctor.semail);
                $("#sphoneViewDoctor").text(data.doctor.nphone);
                $("#resumeViewDoctor").text(data.doctor.sabout);

                $('#modalView').modal('show');
            },
            error: function (a, b, c) {
                console.log('%cError: The information could not be obtained.', 'color:red');
            },
            complete: function (data) {
                $('body').removeClass('busy');
            }
        });  

    },

    EditDoctor: function (niddoctor) {
        var urlEnvio = "Doctor/GetDoctorById";
        this.ClearForm();
                
        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { niddoctor: niddoctor },
            success: function (data) {
                flagEdit = "1";

                const birthdate = moment(data.doctor.dbirthdate).format("DD/MM/YYYY");

                nIdDoctor = data.doctor.niddoctor;
                spathDoctor = data.doctor.spathimage;
                $("#largeModalLabel").text("Editar Doctor");
                $("#sfirstName").val(data.doctor.sfirstname);
                $("#sSecondName").val(data.doctor.ssecondname);
                $("#slastName").val(data.doctor.slastname);
                $("#slastName1").val(data.doctor.slastnamE1);
                $("#dbrithDate").val(birthdate);
                $("#sgender").val(data.doctor.sgender);
                $("#sspeciality").val(data.doctor.sspeciality);
                $("#sphone").val(data.doctor.nphone);
                $("#semail").val(data.doctor.semail);
                $("#resume").val(data.doctor.sabout),
                $("#swebSite").val(data.doctor.swebsite);
                $("#user").val(data.doctor.suser);
                $("#user").prop("disabled", true);

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

    DeleteDoctor: function (niddoctor) {

        var urlEnvio = "Doctor/Deletedoctor";

        swal({
            title: "Eliminar Registro",
            text: "¿Esta seguro que desea eliminar el Registro?",
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
                    data: { niddoctor: niddoctor },
                    success: function (data) {
                        if (data.data.resultado == 0) {
                            setTimeout(function () {
                                swal({
                                    title: "Eliminado!",
                                    text: data.data.mensaje,
                                    type: "success"
                                }, function () {
                                    window.location = "Doctor";
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
                swal("Cancelado", "Se ha cancelado la eliminación del Registro", "error");
            }
        });                
    },

    ClearForm: function () {
        $("#sfirstName").val('');
        $("#sSecondName").val('');
        $("#slastName").val('');
        $("#slastName1").val('');
        $("#dbrithDate").val('');
        $("#sgender").val('');
        $("#sspeciality").val('');
        $("#sphone").val('');
        $("#semail").val('');
        $("#swebSite").val('');
        $("#resume").val('');
        $("#user").val('');
        $("#password").val('');
        $("#confirmpassword").val('');
        flagEdit = "";
        nIdDoctor = 0;
        spathDoctor = '';

    }
}

$(document).ready(function () {

    $('#dbrithDate').bootstrapMaterialDatePicker({
        lang: 'es',
        cancelText: 'Cancelar',
        format: 'DD/MM/YYYY',
        time: false
    });

    $("#btnSaveDoctor").click(() => {
        doctorObject.SaveDoctor();
    });
});

