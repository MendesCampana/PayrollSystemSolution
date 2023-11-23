// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function compchange(e) {
    $("#cdp").load("/Company/_cdetailpartial/" + e.value);
}
function empChange(e) {
    $("#empId").load("/Employee/_EmployeeDetailPartial/" + e.value);
}