$(function f() {

    let $submitRemoveForm = $("#remove-submit-form");
    let $index = $("#index");

    $submitRemoveForm.on("submit", (e) => {
        e.preventDefault();

        $.post(`/NotePad/RemoveItem?index=${$index.val()}`, data => {
            console.log(data);
            alert("Data was removed!");

            $index.val('');
        });
    });
});
