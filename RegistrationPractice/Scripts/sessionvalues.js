(function ($) {
    $(document).ready(function () {

        function ipLookUp() {
            $.ajax('http://ip-api.com/json')
                .then(
                    function success(response) {
                        console.log('User\'s Location Data is ', response);
                        console.log('User\'s Country', response.country);
                        window.location.href = "/Items/CountryIndex/?countryname=" + response.country;
                    },

                    function fail(data, status) {
                        console.log('Request failed.  Returned status of',
                            status);
                        window.location.href = "/Items/CountryIndex/?countryname=canada";
                    }
                );
        }
        ipLookUp();



        //------------------------------------------------------------

        //navigator.geolocation.getCurrentPosition(successCallback,
        //    errorCallback
        //);


        function successCallback(position) {
            alert(document.cookie);
            var coordinates = position.coords;
            setCookie("latitude", coordinates.latitude);
            setCookie("longitude", coordinates.longitude);

        }

        function errorCallback(error) {
            if (error.code === error.PERMISSION_DENIED) {
                // pop up dialog asking for location
                alert("ooops! Error: " + position.code);
            }
        }

        function setCookie(cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
            var expires = "expires=" + d.toUTCString();
            document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
        }

        function getCookie(name) {
            var dc = document.cookie;
            var prefix = name + "=";
            var begin = dc.indexOf("; " + prefix);
            if (begin === -1) {
                begin = dc.indexOf(prefix);
                if (begin !== 0) return null;
            }
            else {
                begin += 2;
                var end = document.cookie.indexOf(";", begin);
                if (end === -1) {
                    end = dc.length;
                }
            }
            return unescape(dc.substring(begin + prefix.length, end));
        }





    });
})(jQuery);