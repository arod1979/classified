

$(document).ready(function () {


    $("[name='adresponsesubmit']").click(function () {
        var itemid = $(this).closest('.post-id').attr('id').slice(1);
        var pid = $(this).siblings('.pid').val();
        var bid = $(this).siblings('.bid').val();
        var emailbody = $(this).siblings('.message').val();
        var fromaddress = $(this).siblings('.email').val();
        var lostcheckbox = $(this).siblings('.input-group').find('.lostcheckbox').val();
        var foundcheckbox = $(this).siblings('.input-group').find('.foundcheckbox').val();
        var stolencheckbox = $(this).siblings('.input-group').find('.stolencheckbox').val();
        var anonymoustipcheckbox = $(this).siblings('.input-group').find('.anonymoustipcheckbox').val();
        alert($(this).closest('.card-title').val() + $(this).closest('.card-text').val());



        var Email = {};
        Email.lostcheckbox = lostcheckbox === "on";
        Email.foundcheckbox = foundcheckbox === "on";
        Email.stolencheckbox = stolencheckbox === "on";
        Email.anonymoustipcheckbox = anonymoustipcheckbox === "on";
        Email.Item_Id = itemid;
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





