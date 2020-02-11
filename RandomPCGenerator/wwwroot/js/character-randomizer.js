$(document).ready(function () {

    $("#appear").click(function () {
        $("#text").html("Button Clicked at least");
        $.getJSON("data/ChrClass.json", function (data) {
            var txt = JSON.stringify(data);
            $("#text").html(txt);
        });
    });

    $("#disappear").click(function () {
        $("#text").hide();
    });

});
