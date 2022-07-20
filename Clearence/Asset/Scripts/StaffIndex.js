
    $(function () {
        //$(".assignlink").button();
        $(".assignlink6").button();

        $("#assignDepartment").dialog({
            autoOpen: false,
            width: 750,            
            resizable: true,
            modal: true,
            //autoOpen: true,
            show: "clip",
            hide: "fade",            
        });
             

        $(".assignlink").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#assignDepartment');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateCarForm");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });



        $("#assignEducation").dialog({
            autoOpen: false,
            width: 600,
            resizable: true,
            modal: true,
            show: "clip",
            hide: "fade",
        });

        $(".assignlink1").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#assignEducation');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateCarForm1");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });


        $("#staffrequest").dialog({
            autoOpen: false,
            width: 600,
            resizable: true,
            modal: true,
            show: "clip",
            hide: "fade",
        });

        $(".assignlink2").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#staffrequest');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updateCarForm2");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });

        $("#addPF_No").dialog({
            autoOpen: false,
            width: 600,
            resizable: true,
            modal: true,
            show: "clip",
            hide: "fade",
        });

        $(".addPF_No").click(function () {
            //change the title of the dialog
            linkObj = $(this);
            var dialogDiv = $('#addPF_No');
            var viewUrl = linkObj.attr('href');
            $.get(viewUrl, function (data) {
                dialogDiv.html(data);
                //validation
                var $form = $("#updatePFNo");
                // Unbind existing validation
                $form.unbind();
                $form.data("validator", null);
                // Check document for changes
                $.validator.unobtrusive.parse(document);
                // Re add validation with changes
                $form.validate($form.data("unobtrusiveValidation").options);
                //open dialog
                dialogDiv.dialog('open');
            });
            return false;
        });

    });

////DatePicker Code
$(document).ready(function () {
    $(document).on('focus', '.datefield', function () {
        $(this).datepicker({ changeYear: true, yearRange: 'c-65:c+10' });
    });
});
