// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function f() {

    let $submitAddForm = $("#add-submit-form");
    let $title = $("#title");
    let $description = $("#description ");
    let $date = $("#date");
    let $tag = $("#tag");

    $submitAddForm.on("submit", (e) => {
        e.preventDefault();

        //$.ajax({
        //    url: `/NotePad/AddItem?title=${$title.val()}&description=${$description.val()}&date=${$date.val()}&tag=${$tag.val()}`,
        //    error: (response) => {
        //        alert("Error while inserting data");
        //    },
        //    success: (response) => {
        //        alert("Success while inserting data");
        //    },
        //    complete: (response) => {
        //        alert("Complete while inserting data");
        //    }
        //});

        $.post(`/NotePad/AddItem?title=${$title.val()}&description=${$description.val()}&date=${$date.val()}&tag=${$tag.val()}`, data => {
            console.log(data);
            alert("Data was added!");

            $title.val('');
            $description.val('');
            $tag.val('');
            $date.val(new Date().toJSON().slice(0, 19));
        });
    });
});
