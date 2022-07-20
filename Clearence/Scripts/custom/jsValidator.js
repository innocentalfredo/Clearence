function jsValidate(elementID) {
    // validation
    var $form = $("#" + elementID);

    // Unbind existing validation
    $form.unbind();

    $form.data("validator", null);

    // Check document for changes
    $.validator.unobtrusive.parse(document);

    // Re add validation with changes
    $form.validate($form.data("unobtrusiveValidation").options);
}
$(document).ready(function () {
    jsValidate('History')
});