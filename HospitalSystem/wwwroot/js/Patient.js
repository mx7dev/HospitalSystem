
flagEdit = "";
nIdPatient = 0;
spathPatient = '';

var patientObject = {
    ValidateEmail: function (email) {
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    },

    AgregarPatient: function () {
        this.ClearForm();
        $("#largeModalLabel").text("Agregar Paciente");
        $('#largeModal').modal('show');
    },

    EditPatient: function (nidpatient) {
        var urlEnvio = "Patient/GetPatientById";
        this.ClearForm();

        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { nidpatient: nidpatient },
            success: function (data) {
                flagEdit = "1";

                const birthdate = moment(data.patient.dbirthdate).format("DD/MM/YYYY");

                nIdPatient = data.patient.nidpatient;
                spathPatient = data.patient.spathimage;
                $("#largeModalLabel").text("Editar Paciente");
                $("#sfirstName").val(data.patient.sfirstname);
                $("#sSecondName").val(data.patient.ssecondname);
                $("#slastName").val(data.patient.slastname);
                $("#slastName1").val(data.patient.slastnamE1);
                $("#dbrithDate").val(birthdate);
                $("#sgender").val(data.patient.sgender);
                $("#sphone").val(data.patient.nphone);
                $("#semail").val(data.patient.semail);
                $("#resume").val(data.patient.sdescription),

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

    ViewPatient: function (nidpatient) {
        var urlEnvio = "Patient/GetPatientById";
        $.ajax({
            url: urlEnvio,
            contentType: 'application/x-www-form-urlencoded',
            type: 'GET',
            data: { nidpatient: nidpatient },
            success: function (data) {

                const birthdate = moment(data.patient.dbirthdate).format("DD/MM/YYYY");

                $("#imageProfilePatient").attr("src", "data:image/png;base64," + data.patient.base64Image);
                $("#snameViewPatient").text(data.patient.scompletename);
                $("#specialityViewPatient").text(data.patient.sspeciality);
                $("#dbirthdateViewPatient").text(birthdate);
                $("#semailViewPatient").text(data.patient.semail);
                $("#sphoneViewPatient").text(data.patient.nphone);
                $("#resumeViewPatient").text(data.patient.sdescription);

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

    SavePatient: function () {
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
        if ($("#semail").val() != '') {
            var resultEmail = this.ValidateEmail($("#semail").val());
            messageError += resultEmail != true ? "- Formato de Correo\n" : "";
            isCorrect = resultEmail;
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
            NIDPATIENT: nIdPatient,
            SFIRSTNAME: $("#sfirstName").val(),
            SSECONDNAME: $("#sSecondName").val(),
            SLASTNAME: $("#slastName").val(),
            SLASTNAME1: $("#slastName1").val(),
            SBIRTHDATE: $("#dbrithDate").val(),
            SGENDER: $("#sgender").val(),
            NPHONE: $("#sphone").val(),
            SEMAIL: $("#semail").val(),
            SPATHIMAGE: spathPatient,
            SDESCRIPTION: $("#resume").val()
        }


        var urlEnvio = "Patient/SavePatient";
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
                            title: flagEdit == "" ? "Paciente Registrado" : "Paciente Actualizado!",
                            text: data.data.mensaje,
                            type: "success"
                        }, function () {
                            window.location = "Patient";
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

    DeletePatient: function (nidPatient) {
        var urlEnvio = "Patient/DeletePatient";

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
                    data: { nidpatient: nidPatient },
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
        $("#sphone").val('');
        $("#semail").val('');
        $("#resume").val('');
        flagEdit = "";
        nIdPatient = 0;
        spathPatient = '';
    }
}

$(document).ready(function () {

    $('#dbrithDate').bootstrapMaterialDatePicker({
        lang: 'es',
        cancelText: 'Cancelar',
        format: 'DD/MM/YYYY',
        time: false
    });

    $("#btnSavePatient").click(() => {
        patientObject.SavePatient();
    });
});
