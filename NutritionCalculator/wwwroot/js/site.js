// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    // details click - to load popup on catalogue
    $("a.btn-outline-dark").on("click", (e) => {
        $("#results").text("");
        let id = e.target.dataset.id;
        let data = JSON.parse(e.target.dataset.details); // it's a string need an object
        CopyToModal(id, data);
    });
});
// populate the modal fields
const CopyToModal = (id, data) => {
    $("#qty").val("0");
    $("#Calories").text(data.Calories);
    $("#Carbohydrate").text(data.Carbohydrate);
    $("#Cholesterol").text(data.Cholesterol);
    $("#Fat").text(data.Fat);
    $("#Fibre").text(data.Fibre);
    $("#Protein").text(data.Protein);
    $("#Sodium").text(data.Sodium);
    $("#Description").text(data.Description);
    $("#detailsGraphic").attr("src", "https://github.com/youngmin-chung/capture/blob/master/hamburger.png?raw=true");
    $("#selectedId").val(id);
}