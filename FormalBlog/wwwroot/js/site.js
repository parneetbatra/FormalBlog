if ($('.form-signin').length > 0) {

    $('.form-signin .message').hide();
    $('.form-signin button').click(function () {
        $.ajax({
            url: "/Login",
            type: "POST",
            cache: false,
            data: $('.form-signin form').serialize(),
            success: function (res) {
                if (res.status === 'Success') {
                    window.location.url = window.location.replace(window.location.origin + '/Dashboard');
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

if ($('.form-subscribe').length > 0) {
    $('.form-subscribe .message').hide();

    $('.form-subscribe button').click(function () {
        $.ajax({
            url: "/Subscribe/Create",
            type: "POST",
            cache: false,
            data: $('.form-subscribe form').serialize(),
            success: function (res) {
                $('.form-subscribe .message').show();
                $('.form-subscribe .message').text(res.message);
            },
            error: function (e) {
                if (typeof e.responseText !== "undefined") {
                    var modelStateErrors = JSON.parse(e.responseText);

                    $('.form-subscribe input').removeClass('is-invalid');
                    $('.form-subscribe textarea').removeClass('is-invalid');

                    for (var i = 0; i < modelStateErrors.length; i++) {
                        $('.form-subscribe [name=' + modelStateErrors[i].key + ']').addClass('is-invalid');
                    }
                }
            }
        });

    });
}