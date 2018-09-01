

$(document).ready(function () {

    $(".submit-button").click(function () {

        var postid = $(this).closest('.post-id').attr('id');
        var pid = $(this).siblings('.pid').val();
        var bid = $(this).siblings('.bid').val();
        var message = $(this).siblings('.message').val();
        alert(pid + message + bid);
    })
});


