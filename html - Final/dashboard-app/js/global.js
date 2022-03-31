// JavaScript Document
jQuery = jQuery.noConflict();


var ESI = {
    lastScrollTop: 0,
    didScroll: true,
    windowHeight: window.innerHeight,
    windowWidth: document.body.clientWidth,

    /*
     Function Name : init
     script to functions call on page load
     @version: 2018-11-05 updated
    */
    init: function() {

        ESI.loadResize();
        ESI.menuOpen();
        // ESI.rightPadding('.testimonials-section .col-md-4 .testi-text-wrapper');
        // ESI.leftPadding('.home-blog-section .read-block-text');
        // ESI.leftPadding('.about-section .about-text');

        //Function call for showing the search results
        //Function for Back to top
        ESI.goTop();

    },


    /*
     Function Name : loadResize
     script to functions call on page load and window resize
     @version: 2018-11-05 updated
     */
    loadResize: function() {
        //load resize script starts
        //script to get windows height and width
        ESI.windowHeight = window.innerHeight;
        ESI.windowWidth = document.body.clientWidth;

        //Function call for menu height resize for mobile
        // ESI.equalHeight('.mainequalheight');


        if (ESI.windowWidth < 768) {


        } else {

        }

        // Script for Ipad, check if width of window is less than 768
        if (ESI.windowWidth >= 768) {


        }
        // Condition for the device width less then and equal to 768(mobile devices)
        else {

        }

        // script for Desktop device
        if (ESI.windowWidth >= 992) {


        } else {

        }
        if (ESI.windowWidth >= 1200) {


        } else {



        }
    },

    // Script for check mobile, Ipad and desktop device
    windowIs: {
        mobileSmall: function() {
            ESI.windowWidth = document.body.clientWidth;
            return ESI.windowWidth <= 610;
        },
        mobile: function() {
            ESI.windowWidth = document.body.clientWidth;
            return ESI.windowWidth <= 767;
        },
        tablet: function() {
            return ESI.windowWidth <= 991 && ESI.windowWidth >= 767;

        },
        ipad: function() {
            ESI.windowWidth = document.body.clientWidth;
            return ESI.windowWidth > 992;
        },
        ipadToDesktop: function() {
            ESI.windowWidth = document.body.clientWidth;
            return ESI.windowWidth >= 768;
        },
        ipadToMobile: function() {
            ESI.windowWidth = document.body.clientWidth;
            return ESI.windowWidth <= 1200;
        },
        desktop: function() {
            return ESI.windowWidth >= 1200;
        },
    },




    menuOpen: function() {
        jQuery(".menuIcon a").click(function() {
            jQuery(this).toggleClass("active");
            jQuery(this).parents().find('.mainMenuWrapper').toggleClass('open-menu');
            jQuery(this).parents().find('.mainMenuWrapper').siblings('.contentPart').toggleClass('open-menu-content');
        });
    },



    leftPadding: function(classname) {
        var leftpadding = (jQuery(window).width() - jQuery('.container').width()) / 2;
        jQuery(classname).css('padding-left', leftpadding);
    },

    rightPadding: function(classname) {
        var rightpadding = (jQuery(window).width() - jQuery('.container').width()) / 2;
        jQuery(classname).css('padding-right', rightpadding);
    },


    /*
           Function Name : goTop
           script for Blog equal height
           @version: 2018-19-07 updated
       */
    goTop: function() {
        jQuery(window).scroll(function() {
            // Scroll on main div 
                // var topDistance = jQuery(".service-slider-section").offset().top;
                if (jQuery(window).scrollTop() >500) {
                    jQuery('.go-top').addClass('show-top');
                } else {
                    jQuery('.go-top').removeClass('show-top');
                }
                // scroll to the top of menu 
        });
        jQuery('.go-top').on('click', function() {
            jQuery("html, body").animate({
                scrollTop: 0
            }, 800);
            return false;
        });


    },

    /*
        Function Name : equalHeight
        script for Blog listing equal height
        @version: 2018-09-07 updated
    */
    equalHeight: function(container) {
        var currentTallest = 0,
            currentRowStart = 0,
            rowDivs = new Array(),
            $el,
            topPosition = 0;
        jQuery(container).each(function() {

            $el = jQuery(this);
            jQuery($el).height('auto')
            topPostion = $el.position().top;

            if (currentRowStart != topPostion) {
                for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
                    rowDivs[currentDiv].height(currentTallest);
                }
                rowDivs.length = 0; // empty the array
                currentRowStart = topPostion;
                currentTallest = $el.height();
                rowDivs.push($el);
            } else {
                rowDivs.push($el);
                currentTallest = (currentTallest < $el.height()) ? ($el.height()) : (currentTallest);
            }
            for (currentDiv = 0; currentDiv < rowDivs.length; currentDiv++) {
                rowDivs[currentDiv].height(currentTallest);
            }
        });
    },

};

// when the page is ready, initialize everything
jQuery(document).ready(function() {
    // iphone touchevent
    var mobileHover = function() {
        jQuery('*').on('touchstart', function() {
            jQuery(this).trigger('hover');
        }).on('touchend', function() {
            jQuery(this).trigger('hover');
        });
    };
    mobileHover();
    ESI.init();
     // WOW Animation
        if (jQuery(window).width() > 767) {
           // new WOW().init();
        }

    function getWysiwygValue(id) {
        var value = tinyMCE.get(id).getContent();
        value = value.replace(/<\/?g[^>]*>/g, "");
        return value;
    }
});

jQuery(window).resize(function() {
    ESI.loadResize();
    // ESI.rightPadding('.testimonials-section .col-md-4 .testi-text-wrapper');
    // ESI.leftPadding('.home-blog-section .read-block-text');
    // ESI.leftPadding('.about-section .about-text');
});