$(function () {
    let $deleteButton = $(".Delete");

    $deleteButton.on("click", (e) => {
        $.ajax({
            url: `/Session/Delete`,
            contentType: "application/json",
            type: "POST",
            data:
                JSON.stringify({
                    Id: $(e.target).attr("data-id")
                }),
            success: (data) => {
                alert("Session was deleted");
                $(e.target).closest("tr").remove();
            }
        });
    });
})