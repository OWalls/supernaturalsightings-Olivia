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


//Results Collapse Function
var coll = document.getElementsByClassName("collapsible");
var i;

for (i = 0; i <= coll.length; i++) {
    coll[i].addEventListener("click", function () {
    this.classList.toggle("active");
    var content = this.nextElementSibling;
    if (content.style.display === "block") {
          content.style.display = "none";
    } else {
    content.style.display = "block";
    }
    });
}
                            