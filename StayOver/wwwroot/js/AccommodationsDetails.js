
    console.log("radi script");

    $("#test-btn").click(function (event) {
        console.log("radi metoda");
        event.preventDefault();
        var id = $(this).attr("value");
        console.log(id);

        var element = $(this);

        $.ajax({
            url: "/Reviews/DeleteReview/",
            type: 'POST',
            data: JSON.stringify(id),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                element.parents('.review-div').remove();
            },
            error: function (error) {
                console.error(error.responseText);
            }
        });
    });