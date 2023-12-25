// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

(function ($) {
    "use strict";
     setInterval(() => {
            const userLocale =
                navigator.languages && navigator.languages.length
                    ? navigator.languages[0]
                    : navigator.language;
            $("#clock").text(new Date().toLocaleTimeString(userLocale, { hour: "2-digit", minute: "2-digit", second: "2-digit", hour12: false }));
     }, 1000);

    // Back to top button
    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $('.back-to-top').fadeIn('slow');
        } else {
            $('.back-to-top').fadeOut('slow');
        }
    });

    $('.back-to-top').click(function () {
        $('html, body').animate({ scrollTop: 0 }, 1500, 'easeInOutExpo');
        return false;
    });

    // Sidebar Toggler
    $('.sidebar-toggler').click(function () {
        $('.sidebar, .content').toggleClass("open");
        return false;
    });

    //Modal toggler
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    })

    //Pattern validation
    let lock = new PatternLock("#lock", {
        onPattern: function (pattern) {
            console.log(pattern);
            error();
        }
    });

    // Add event listener to the Submit button
    $("#submitBtn").on("click", function () {
        let pattern = lock.getPattern();
        console.log(pattern);
        // Clear the pattern after submission
        lock.clear();
        error();
        clearActiveIndicators()
    });
    function clearActiveIndicators() {
        $(".lock-actives circle").text = '';
    }
})(jQuery);


// Write your JavaScript code.
