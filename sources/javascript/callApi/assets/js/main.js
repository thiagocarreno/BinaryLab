$(document).ready(function () {
    get = function (url) {
        $.ajax({
            type: "GET",
            url: url,
            dataType: 'json',
            success: function (data, textStatus, xhr) {
                $("#result").text(JSON.stringify(data));
            },
            error: function (xhr, textStatus, error) {
                $("#result").text(error);                
            }
        });
    }

    $("#callApi").click(function (evt) {
        evt.preventDefault();
        var url = $("#apiUrl").val();
        get(url);
    });
});