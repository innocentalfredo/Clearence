$('#pagesizelist').on('change', function (event) {
            var form = $(event.target).parents('form');
            form.submit();
        });

        //DATE PICKER
        $(document).ready(function () {
            $(".DatePicker").datepicker({
                dateFormat: 'dd M yy',
                changeMonth: true,
                changeYear: true,
            });
        });

        //function LastDayOfMonth(Year, Month) {
        //    return (new Date((new Date(Year, Month + 1, 1)) - 1)).getDate();
        //}

        ////DATE PICKER
        //$('#selector').datepicker({
        //    beforeShowDay: function (date) {
        //        //getDate() returns the day (0-31)
        //        if (date.getDate() == LastDayOfMonth(date.getFullYear(), date.getMonth())) {
        //            return [true, ''];
        //        }
        //        return [false, ''];
        //    }
        //});

        //Hide Columns ready for Printing
        $(function () {
            var Col = "Col2";
            if ($('input:checkbox').prop('checked', true)) {
                $('#Col3').hide();
                $("td[id='" + Col + "']").hide();
            } else {
                $('#Col3').show();
                $("td[id='" + Col + "']").show();
            }
        });


//Dialog Forms
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
$(function () {
    //$(".assignlink").button();
    //$(".assignlink1").button();
    //$(".assignlink4").button();
    //$(".returnlink").button();


    $("#createReturn").dialog({
        autoOpen: false,
        width: 800,
        resizable: true,
        modal: true,
        show: "clip",
        hide: "fade",
        title: "Vehicle Return"
    });

    $(".returnlink").click(function () {
        //change the title of the dialog
        linkObj = $(this);
        var dialogDiv = $('#createReturn');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);

            //validation
            var $form = $("#ReturnForm");

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


    $("#assignVehicle").dialog({
        autoOpen: false,
        width: 800,
        resizable: true,
        modal: true,
        show: "clip",
        hide: "fade",
    });

    $(".assignlink").click(function () {
        //change the title of the dialog
        linkObj = $(this);
        var dialogDiv = $('#assignVehicle');
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

    $("#reportAccident").dialog({
        autoOpen: false,
        width: 800,
        resizable: true,
        modal: true,
        show: "clip",
        hide: "fade",
    });

    $(".assignlink1").click(function () {
        $("#reportAccident").dialog({ title: "Report Vehicle Accident for ::" })
        //change the title of the dialog
        linkObj = $(this);
        var dialogDiv = $('#reportAccident');
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

    $("#requestVehicle").dialog({
        autoOpen: false,
        width: 700,
        resizable: true,
        modal: true,
        show: "clip",
        hide: "fade",
        title: "Request Vehicle"
    });

    $(".assignlink4").click(function () {
        //$("#requestVehicle").dialog({ title: "Request Vehicle" })
        //change the title of the dialog
        linkObj = $(this);
        var dialogDiv = $('#requestVehicle');
        var viewUrl = linkObj.attr('href');
        $.get(viewUrl, function (data) {
            dialogDiv.html(data);

            //validation
            var $form = $("#updateCarForm4");

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

}); // End Dialogs


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


////Cascading dropdowns -- Regions + Districts
//function myPartialView_Load() {
//    $('#Region').change(function () {
//        $.getJSON('/Vehicle/DistrictList/' + $('#Region').val(), function (data) {
//            var items = "<option value = '' >--Select a District--</option>";

//            $.each(data, function (i, district) {
//                items += "<option value='" + district.Value + "'>" + district.Text + "</option>";
//            });

//            $('#District').html(items);
//        });
//    });
//};

//function myPartialView_Load1() {
//    $('#Region1').change(function () {
//        $.getJSON('/Staff/DistrictList/' + $('#Region1').val(), function (data) {
//            var items = "<option value = '' >--Select a District--</option>";

//            $.each(data, function (i, district) {
//                items += "<option value='" + district.Value + "'>" + district.Text + "</option>";
//            });

//            $('#District1').html(items);
//        });
//    });
//};

////DatePicker Code
$(document).ready(function () {
    $(document).on('focus', '#datefield', function () {
        $(this).datepicker({ changeYear: true, yearRange: 'c-65:c+10' });
    });
});
