

$(document).ready(function () {


    $(".submit-button").click(function () {
        var postid = $(this).closest('.post-id').attr('id').slice(1);
        var pid = $(this).siblings('.pid').val();
        var bid = $(this).siblings('.bid').val();
        var emailbody = $(this).siblings('.message').val();
        var fromaddress = $(this).siblings('.email').val();
        var Email = {};
        Email.postid = postid;
        Email.pid = pid;
        Email.bid = bid;
        Email.emailbody = emailbody;
        Email.fromaddress = fromaddress;
        $.ajax({
            beforeSend: function (request) {
                request.setRequestHeader("__RequestVerificationToken", AddAntiForgeryToken({ id: parseInt($(this).attr("title")) }));
            },
            url: '/api/Emails/',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(Email),
            success: function (data, textStatus, xhr) {
                alert("ok");
            },
            error: function (xhr, textStatus, errorThrown) {
                console.log('Error in Operation');
            }
        });
    });
    AddAntiForgeryToken = function (data) {
        data = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
        return data;
    };
}); (jQuery);





