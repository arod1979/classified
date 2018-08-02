(function ($) {
    $(document).ready(function () {

    
        navigator.geolocation.getCurrentPosition(showPosition, positionError);

        function showPosition(position) {
            var coordinates = position.coords;
            alert(coordinates.latitude + " " +coordinates.longitude);
        }

        function positionError(position) {
            alert("ooops! Error: " + position.code);
        }

    });
})(jQuery);