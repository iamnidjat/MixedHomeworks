$(function f() {

    let $submitEditForm = $("#edit-submit-form");
    let $index = $("#indexEdit");
    let $title = $("#titleEdit");
    let $description = $("#descriptionEdit");
    let $date = $("#dateEdit");
    let $tag = $("#tagEdit");

    $submitEditForm.on("submit", (e) => {
        e.preventDefault();

        $.post(`/NotePad/EditItem?index=${$index.val()}&title=${$title.val()}&description=${$description.val()}&date=${$date.val()}&tag=${$tag.val()}`, data => {
            console.log(data);
            alert("Data was edited!");

            $index.val('');
            $title.val('');
            $description.val('');
            $tag.val('');
            $date.val(new Date().toJSON().slice(0, 19));
        });
    });
});
