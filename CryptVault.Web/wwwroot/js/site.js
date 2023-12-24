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

    // Spinner
    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner();


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
    var lock = new PatternLock("#lock", {
        onPattern: function (pattern) {
            // Context is the pattern lock instance
            console.log(pattern)
        }
    });
    $(document).ready(function () {
        // Your jQuery code here
        $("#lock").on('touchstart mousedown', function (e) {
            var lock = new PatternLock("#lock", {
                onPattern: function (pattern) {
                    console.log(pattern);
                }
            });
            
        });
        $('#submitBtn').on('click', function () {
            var pattern = lock.getPattern(); // Get the current pattern
            // Perform submission logic here (e.g., send pattern to server)
            console.log("Submitted pattern: " + pattern);
            lock.success(123);
            // Clear the pattern after submission
            lock.clear();
        });
    });
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    })

})(jQuery);


// Write your JavaScript code.
