/// <reference path="../Scripts/jquery/jquery-3.2.1.min.js" />
/// <reference path="../Scripts/underscore-min.js" />
/// <reference path="../Scripts/dropzone.js" />

Dropzone.options.imageUpload = {
    paramName: 'files',
    dictDefaultMessage: 'Drop files here or Click to Upload',
    addRemoveLinks: true,
    init: function() {
        var myDropzone = this;
        myDropzone.on('success',
            function(file) {
                console.log('Success');
                myDropzone.removeFile(file);
                fileUploaded = true;
                $('#divUploadSucess').show();
            });

        myDropzone.on('error',
            function(errorMessage) {
                alert(errorMessage.status);
                $('#divUploadSucess').hide();
            });
    }
};

var fileUploaded = false;


$(document).ready(function() {

    setInterval(function() {
            if (fileUploaded) {
                fetchImageLinks();
                fileUploaded = false;
            }
        },
        30000);

    $('#btnRefresh').on('click',
        function() {
            fetchImageLinks();
        });

    function fetchImageLinks() {
        
        $.get('api/Image/GetThumbnails',
            function(fetchedImageLinks) {
                console.log(fetchedImageLinks);

                if (!fetchedImageLinks) {
                    console.log('empty fetched');

                } else {
                    window.blueimp.Gallery(
                        fetchedImageLinks,
                        {
                            container: '#blueimp-gallery-carousel',
                            carousel: true
                        }
                    );
                }

            });
    }

    fetchImageLinks();
});