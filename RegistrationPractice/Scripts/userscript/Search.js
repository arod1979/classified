$(document).ready(function () {

    $("#citysearch").keyup(function () {
        citysearch();
    });

    $("#countryname").change(function () {
        citysearch();
    });

    function citysearch() {

        var country = $("#countryname").val();
        var searchvalue = $("#citysearch").val();
        $.ajax({
            type: "post",
            contentType: "html",
            url: "/Items/LoadCities?countryname=" + country + "&searchquery=" + searchvalue,
            success: function (result) {
                $("#flexresults").html("");
                $.each(result, function (index, value) {
                    var city2 = value.city.replace(", ", "-");
                    var city3 = city2.replace(/ /g, "-");

                    $("#flexresults").append('<div class="p-2 my-flex-item">' + "<a href=" + "/items/" + encodeURI(value.country) + "/" +
                        value.regionabbreviation + "/" + "cityindex/" + city3 + ">" + value.city + "</a></div");
                });
            },
            error: function fail(data, status) {
                console.log('Request failed.  Returned status of',
                    status);
            }
        });
    }
});