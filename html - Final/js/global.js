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

        // ESI.menuOpen();
        // ESI.homeBanner();
        ESI.mobileMenu();
        ESI.pricingListSlider();
        ESI.testimonialSlider();
        ESI.playVideo();
        // ESI.rightPadding('.testimonials-section .col-md-4 .testi-text-wrapper');
        // ESI.leftPadding('.home-blog-section .read-block-text');
        // ESI.leftPadding('.about-section .about-text');
        // ESI.homeBlogSlider();
        // ESI.latestBlogSlider();
        // ESI.blogInnerStickybar();
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
        // ESI.equalHeight('.program-block');


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





    pricingListSlider: function() {
        if (jQuery(".pricingListSlider").length) {
            jQuery('.pricingListSlider.owl-carousel').owlCarousel({
                
                nav: false,
                items: 3,
                // autoplay:1000,
                autoplay: false,
                autoplayHoverPause: true,
                smartSpeed: 1000,
                margin:30,
                stagePadding:10,
                responsive: {
                    0: {
                        items: 1,
                        loop: true,
                        mouseDrag:true,
                        stagePadding:0,
                    },
                    450: {
                        items: 1,
                        loop: true,
                        stagePadding:0,
                    },
                    650: {
                        items: 2,
                        loop: true,
                    },
                    992: {
                        items: 3,
                        loop: false,
                        mouseDrag:false
                    }
                }
            });
        }
    },


        testimonialSlider: function() {
        if (jQuery(".testimonialSlider").length) {
            jQuery('.testimonialSlider.owl-carousel').owlCarousel({
                loop: true,
                nav: true,
                dots:true,
                items: 3,
                // autoplay:1000,
                autoplay: false,
                autoplayHoverPause: true,
                smartSpeed: 1000,
                margin:30,
                stagePadding:10,
                responsive: {
                    0: {
                        items: 1,
                        center: false,
                        stagePadding:0,
                    },
                    576: {
                        items: 1,
                        stagePadding:0,
                    },
                    768: {
                        items: 2,
                        
                    },
                    1000: {
                        items: 3,
                        center: true,
                    }
                }
            });
        }
    },
        playVideo: function() {
            if (jQuery(".videoBanner").length) {
        var videoPlayButton,
    videoWrapper = document.getElementsByClassName('video-wrapper')[0],
    video = document.getElementsByTagName('video')[0],
    videoMethods = {
        renderVideoPlayButton: function() {
            if (videoWrapper.contains(video)) {
                this.formatVideoPlayButton()
                video.classList.add('has-media-controls-hidden')
                videoPlayButton = document.getElementsByClassName('video-overlay-play-button')[0]
                videoPlayButton.addEventListener('click', this.hideVideoPlayButton)
            }
        },

        formatVideoPlayButton: function() {
            videoWrapper.insertAdjacentHTML('beforeend', '\
                <img  src="images/video-btn.png" class="video-overlay-play-button">\
            ')
        },

        hideVideoPlayButton: function() {
            video.play()
            videoPlayButton.classList.add('is-hidden')
            video.classList.remove('has-media-controls-hidden')
            video.setAttribute('controls', 'controls')
        }
    }

videoMethods.renderVideoPlayButton()
}
    },

     mobileMenu: function () {
        // On window resize unbind the click event from mobile menu button           
        jQuery(".mobile-button").click(function (e) {

            jQuery("body").toggleClass("mobilemenu-open");

            e.stopImmediatePropagation();
            // If menu is opened then remove the open class and add close class in button
            if (jQuery(".mobile-button").hasClass("mobile-button-open")) {
                // Adding  mobile button close class
                jQuery(".mobile-button").addClass("mobile-close-button");
                // Removing mobile button open class
                jQuery(".mobile-button").removeClass("mobile-button-open");
                // Slide down the menu items section
                jQuery(".menuBtn .menuList").slideDown(200);
                // script to get menu container height for mobile and iPad
                // Height of ul where Current menu item exists

                var currentUlHeight = jQuery(".show-children ul.open").height();
                // Height of back parent link
                var currentAHeight = jQuery(".show-children > a").height();
                // if current active ul and parent of current item link heights greater than 0
                if ((currentUlHeight > 0) && (currentAHeight > 0)) {
                    // After calculating the total height set into menu container
                    jQuery("..menuBtn .menuList").css({
                        "height": (currentUlHeight + currentAHeight)
                    });
                }
                // Function call for calculating the menu container height on resize
                CIPL.resetMenuContainerHeightInMobile();

            } else {
                // When close the menu in mobile, removing the open and active classes of menu, and slide up the menu items section
                jQuery(".mobile-button").addClass("mobile-button-open");
                jQuery(".mobile-button").removeClass("mobile-close-button");
                jQuery(".menuBtn .menuList").slideUp(200);
            }
            //fix mobile menu 

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
        // jQuery(window).scroll(function() {
        //     // Scroll on main div 
        //         // var topDistance = jQuery(".service-slider-section").offset().top;
        //         if (jQuery(window).scrollTop() >500) {
        //             jQuery('.go-top').addClass('show-top');
        //         } else {
        //             jQuery('.go-top').removeClass('show-top');
        //         }
        //         // scroll to the top of menu 
        // });
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
           new WOW().init();
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