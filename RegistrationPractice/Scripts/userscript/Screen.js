
AddAntiForgeryToken = function (data) {
    data = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
    return data;
};


$.ajax({
    beforeSend: function (request) {
        request.setRequestHeader("__RequestVerificationToken", AddAntiForgeryToken());
    },
    url: '/api/Settings/',
    type: 'POST',


    contentType: 'application/json; charset=utf-8',
    data: JSON.stringify(screen.width),
    success: function (data, textStatus, xhr) {

    },
    error: function (xhr, textStatus, errorThrown) {
        console.log("could not acquire device width");
    }
});


