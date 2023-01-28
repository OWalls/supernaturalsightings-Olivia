// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function changeRemoveButton(id){
    document.getElementById("filter_btn_" + id).value = "Sighting Removed!";
    document.getElementById("filter_btn_" + id).style.backgroundColor = 'red';
    document.getElementById("filter_btn_" + id).style.color = 'white';
}

function changeAddFavoritesButton(id) {
    document.getElementById("filter_btn_" + id).value = "Added to List!";
    document.getElementById("filter_btn_" + id).style.backgroundColor = 'dodgerblue';
    document.getElementById("filter_btn_" + id).style.color = 'white';
}
