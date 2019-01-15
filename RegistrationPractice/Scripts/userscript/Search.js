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
                //if (typeof result.length === "undefined" || result.length === 0) {
                //    $("#flexresults").html("");
                //}
                //else {
                $("#flexresults").html("");
                $.each(result, function (index, value) {

                    //$("#citieslist").append("<li><a href=/items/" + value.country + "/" +
                    //    value.regionabbreviation + "/" + "cityindex/" + value.city + ">" + value.city + "</a></li>");


                    $("#flexresults").append('<div class="p-2 my-flex-item">' + "<a href=" + "/items/" + encodeURI(value.country) + "/" +
                        value.regionabbreviation + "/" + "cityindex/" + encodeURI(value.city) + ">" + value.city + "</a></div");

                });


                //}

            },
            error: function fail(data, status) {
                console.log('Request failed.  Returned status of',
                    status);
            }
        });

    }



});