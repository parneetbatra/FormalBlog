if ($('.form-signin').length > 0) {

    $('.form-signin button').click(function () {
        $('.form-signin .message').hide();
        $.ajax({
            url: "/Login",
            type: "POST",
            cache: false,
            data: $('.form-signin form').serialize(),
            success: function (res) {
                if (res.status === 'Success') {
                    window.location.url = '/Dashboard';
                } else {
                    $('.form-signin .message').show();
                    $('.form-signin .message').text(res.message);
                }
            },
            error: function (e) {
                if (typeof e.responseText !== "undefined") {
                    var modelStateErrors = JSON.parse(e.responseText);

                    $('input').removeClass('is-invalid');
                    $('textarea').removeClass('is-invalid');

                    for (var i = 0; i < modelStateErrors.length; i++) {
                        $('[name=' + modelStateErrors[i].key + ']').addClass('is-invalid');
                    }
                }
            }
        });

    });

}