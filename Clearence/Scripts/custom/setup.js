$.ajaxSetup({
    //cache: false,
    beforeSend: function () {
        // TODO: show your spinner
        $.LoadingOverlay("show");
    },
    complete: function () {
        // TODO: hide your spinner
        $.LoadingOverlay("hide");
    },
    error: function () {
        var data = {
            Status: false,
            Message: "An error occured while processing your request."
        };
        LobiAlert(data);
    }
});
$.LoadingOverlaySetup({
    background: "rgba(0, 0, 0, 0.1)",
    image: "/Content/images/loading.gif"
});
function ButtonRedirect($this) {
    redirectUrl = $this.attr('value');
    window.location.replace(redirectUrl);
}
var urlOpt = {
    create: '',
    update: '',
    details: ''
};
var lobiopt = {
    msg: '',
    size: 'mini',
    pauseDelayOnHover: true,
    continueDelayOnInactiveTab: false,
    delay: false,
    delayIndicator: false,
    sound: false,
    position: 'center top', //or 'center bottom',
};
function LobiAlert(data) {
    lobiopt.msg = data.Message;
    if (data.Status === true) {
        lobiopt.position = 'center top';
        lobiopt.delay = 5000;
        lobiopt.delayIndicator = false;
        Lobibox.notify('success', lobiopt);
    }
    else {
        lobiopt.position = 'center bottom';
        Lobibox.notify('error', lobiopt);
    }
}
var bootboxOpt = {
    title: '',
    submitButtonLbl: '',
    size: '' //'small', 'sm' | 'large', 'lg' | 'extra-large', 'xl'
};
function ShowBootboxDialog(viewUrl, bootboxOpt) {
    $.ajax({
        type: 'GET',
        url: viewUrl,
        success: function (data) {
            bootbox.dialog({
                message: data,
                title: bootboxOpt.title,
                size: bootboxOpt.size,
                buttons: {
                    submit: {
                        label: bootboxOpt.submitButtonLbl,
                        className: "btn-info koko",
                        callback: function () {
                            $("#History").submit();
                            return false;
                        }
                    },
                    close: {
                        label: "Close",
                        className: "btn-danger closeBtn"
                    }
                }
            });
        }
    });
}
function ShowBootboxDialogWithConfirm(viewUrl, bootboxOpt) {
    $.ajax({
        type: 'GET',
        url: viewUrl,
        success: function (data) {
            bootbox.dialog({
                message: data,
                title: bootboxOpt.title,
                size: bootboxOpt.size,
                buttons: {
                    submit: {
                        label: bootboxOpt.submitButtonLbl,
                        className: "btn-info koko",
                        callback: function () {
                            if ($('#History').valid()) {
                                $.confirm({
                                    icon: 'fa fa-warning',
                                    title: 'Please Confirm!',
                                    content: 'Are you sure you want to submit this action?',
                                    type: 'red',
                                    animateFromElement: false,
                                    autoClose: 'Cancel|12000',
                                    buttons: {
                                        Continue: {
                                            btnClass: 'btn-danger',
                                            action: function () {
                                                $.confirm({
                                                    title: 'Are you sure?',
                                                    icon: 'fa fa-warning',
                                                    content: 'Once submitted, there is no turning back.',
                                                    type: 'orange',
                                                    animateFromElement: false,
                                                    buttons: {
                                                        Yes: {
                                                            text: 'Yes Sure',
                                                            btnClass: 'btn-warning',
                                                            action: function () {
                                                                $("#History").submit();
                                                            }
                                                        },
                                                        Cancel: {
                                                            text: 'No, Wait',
                                                            btnClass: 'btn-info'
                                                        }
                                                    }
                                                });
                                            }
                                        },
                                        Cancel: function () { }
                                    }
                                });
                            }
                            return false;
                        }
                    },
                    close: {
                        label: "Close",
                        className: "btn-danger closeBtn"
                    }
                }
            });
        }
    });
}
function ShowBootboxDialogWithSingleConfirm(viewUrl, bootboxOpt) {
    $.ajax({
        type: 'GET',
        url: viewUrl,
        success: function (data) {
            bootbox.dialog({
                message: data,
                title: bootboxOpt.title,
                size: bootboxOpt.size,
                buttons: {
                    submit: {
                        label: bootboxOpt.submitButtonLbl,
                        className: "btn-info koko",
                        callback: function () {
                            if ($('#History').valid()) {
                                $.confirm({
                                    icon: 'fa fa-warning',
                                    title: 'Please Confirm!',
                                    content: 'Are you sure you want to submit this action?',
                                    type: 'red',
                                    animateFromElement: false,
                                    //autoClose: 'Cancel|12000',
                                    buttons: {
                                        Yes: {
                                            text: 'Yes Sure',
                                            btnClass: 'btn-warning',
                                            action: function () {
                                                $("#History").submit();
                                                //$.LoadingOverlay("show");
                                            }
                                        },
                                        Cancel: function () { }
                                    }
                                });
                            }
                            return false;
                        }
                    },
                    close: {
                        label: "Close",
                        className: "btn-danger closeBtn"
                    }
                }
            });
        }
    });
}
var deleteOpt = {
    title: '',
    viewUrl: '',
    redirectUrl: ''
}
function AjaxDelete(opt) {
    $.confirm({
        icon: 'fa fa-warning',
        title: 'Please Confirm!',
        content: 'Are you sure you want to delete ' + opt.title + '?',
        type: 'red',
        animateFromElement: false,
        autoClose: 'Cancel|12000',
        buttons: {
            Yes: {
                text: 'Yes Sure',
                btnClass: 'btn-danger',
                action: function () {
                    $.ajax({
                        type: 'POST',
                        url: opt.viewUrl,
                        data: { id: linkObj.attr('value') },
                        success: function () {
                            window.location.replace(opt.redirectUrl);
                        }
                    });
                }
            },
            Cancel: function () { }
        }
    });
}