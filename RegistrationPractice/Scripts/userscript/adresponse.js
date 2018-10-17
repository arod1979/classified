
(function ($) {
    $(document).ready(function () {


        $("[name='adresponsesubmit']").click(function () {

            alert('here');

            var pid = $("[name='pid']").val();
            var bid = $("[name='bid']").val();
            var email = $("[name='email']").val();
            var postid = $("[name='postid']").val();
            var lostcheckbox = $("[name='lostcheckbox']").val();
            var foundcheckbox = $("[name='foundcheckbox']").val();
            var stolencheckbox = $("[name='stolencheckbox']").val();
            var anonymoustipcheckbox = $("[name='anonymoustipcheckbox']").val()

            var email = {
                bid: bid, pid: pid, email: email, postid: postid, lostcheckbox: lostcheckbox, foundcheckbox: foundcheckbox,
                stolencheckbox: stolencheckbox, anonymoustipcheckbox: anonymoustipcheckbox
            }

            $.ajax({
                url: '/api/Emails/',
                method: 'POST',
                dataType: 'json',
                contentType: 'application/json; charset=utf-8',
                data: email,
                success: function (data) {
                    alert("Saved successfully");
                },
                fail: function (jqXHR, textStatus) {
                    alert("Request failed: " + textStatus);
                }
            })
            //});
        });
    });
})(jQuery);

