
$(document).ready(function () {

    $('#grid').on('click', '.page-link', function (event) {

        var pageid = event.target.id;

        var lastChar = pageid.substr(pageid.length - 1);

        $("#paging").val(lastChar);

        $("#pagingform").trigger('submit');
    });

    $(".search-button").click(function () {
        $("#paging").val("1");
    }
    );

}); (jQuery);

function success(data, textStatus, jqxhr) {
    alert("here");
}

