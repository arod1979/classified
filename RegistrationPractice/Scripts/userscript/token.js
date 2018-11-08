

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
        var posttype = $("[name='posttype']").val();
        var posttypesentencecase = posttype[0].toUpperCase() + posttype.slice(1);
        var itemdescription = posttypesentencecase + " Item |" + $(this).closest('.card').find('.card-title').html() + " Description: " + $(this).closest('.card').find('.card-text').html();



        var Email = {};
        Email.itemdescription = itemdescription;
        Email.lostcheckbox = lostcheckbox === "on";
        Email.foundcheckbox = foundcheckbox === "on";
        Email.stolencheckbox = stolencheckbox === "on";
        Email.anonymoustipcheckbox = anonymoustipcheckbox === "on";
        Email.IdItem = itemid;
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





