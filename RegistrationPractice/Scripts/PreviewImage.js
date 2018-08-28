$(function () {

    $("#FoundDate").datepicker();

    $('[file-upload]').change(function () {
        var File = this.files;

        if (File && File[0]) {
            ReadImage(File[0]);
        }
    });







});

var ReadImage = function (file) {

    var s = document.getElementById('UpdatedActionsFileUpload');
    s.value = 'ReverseDelete';


    var reader = new FileReader;
    var image = new Image;

    image.addEventListener('error', imagenotfound);
    var imagenotfound = function () {
        alert("imagenotfound");
    };

    reader.readAsDataURL(file);
    reader.onload = function (_file) {
        image.src = _file.target.result;
        image.onload = function () {
            //var height = this.height;
            //var width = this.width;
            //var type = file.type;
            //var size = ~~(file.size / 1024) + "KB";

            $('[target-img]').attr('src', _file.target.result);
            //$('[img-description]').text("Size: " + size + ", Height:" + height
            //    + ", Width:" + width);
            $('[img-preview]').show();
        }
    };
};

var ClearPreview = function () {
    $('[file-upload]').val('');
    $('[img-description]').text('');

    $('#img-preview').css({ "visibility": "visible" });

    $('[img-preview]').hide();
    var s = document.getElementById('UpdatedActionsFileUpload');
    s.value = 'Delete';


};