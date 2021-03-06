var isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry/i.test(navigator.userAgent) ? true : false;

function mobileTap() {
    function escondeMenuLateral() {
        $("body").removeClass("mini-navbar");
    }
    $("div.wrapper-content").bind("tap", escondeMenuLateral);
    $("div.page-heading").bind("tap", escondeMenuLateral);
}
jQuery(document).ready(function ($) {
    if (isMobile) {
        mobileTap();
    }
});

function localStorageSupport() {
    return "localStorage" in window && null !== window.localStorage
}

function animationHover(e, a) {
    e = $(e), e.hover(function () {
        e.addClass("animated " + a)
    }, function () {
        window.setTimeout(function () {
            e.removeClass("animated " + a)
        }, 2e3)
    })
}

function SmoothlyMenu() {
    !$("body").hasClass("mini-navbar") || $("body").hasClass("body-small") ? (setTimeout(function () {
        $("#side-menu").fadeIn(500)
    }, 300)) : $("body").hasClass("fixed-sidebar") ? (setTimeout(function () {
        $("#side-menu").fadeIn(500)
    }, 300)) : $("#side-menu").removeAttr("style")
}

function reSetExpandEvents() {
    $(".collapse-link").unbind("click");
    $(".collapse-link").on('click', function () {
        var e = $(this).closest("div.ibox"),
            a = $(this).find("i"),
            o = e.find("div.ibox-content");
        o.slideToggle(200), e.toggleClass("").toggleClass("border-bottom"), setTimeout(function () {
            e.resize(), e.find("[id^=map-]").resize()
        }, 50)
    });
}

function WinMove() {
    var e = "[class*=col]",
        a = ".ibox-title",
        o = "[class*=col]";
    $(e).sortable({
        handle: a,
        connectWith: o,
        tolerance: "pointer",
        forcePlaceholderSize: !0,
        opacity: .8
    }).disableSelection()
}
$(document).ready(function () {
    function e() {
        var e = $("body > #wrapper").height() - 61;
        $(".sidebard-panel").css("min-height", e + "px");
        var a = $("nav.navbar-default").height(),
            o = $("#page-wrapper").height();
        a > o && $("#page-wrapper").css("min-height", a + "px"), o > a && $("#page-wrapper").css("min-height", $(window).height() + "px"), $("body").hasClass("fixed-nav") && $("#page-wrapper").css("min-height", $(window).height() - 60 + "px")
    }
    $(this).width() < 769 ? $("body").addClass("body-small") : $("body").removeClass("body-small"), $("#side-menu").metisMenu(), $(".collapse-link").on('click',function () {
        var e = $(this).closest("div.ibox"),
            a = $(this).find("i"),
            o = e.find("div.ibox-content");
        o.slideToggle(200), e.toggleClass("").toggleClass("border-bottom"), setTimeout(function () {
            e.resize(), e.find("[id^=map-]").resize()
        }, 50)
    }), $(".close-link").click(function () {
        var e = $(this).closest("div.ibox");
        e.remove()
    }), $(".close-canvas-menu").click(function () {
        $("body").toggleClass("mini-navbar"), SmoothlyMenu()
    }), $(".right-sidebar-toggle").click(function () {
        $("#right-sidebar").toggleClass("sidebar-open")
    }), $(".sidebar-container").slimScroll({
        height: "100%",
        railOpacity: .4,
        wheelStep: 10
    }), $(".open-small-chat").click(function () {
        $(this).children().toggleClass("fa-comments").toggleClass("fa-remove"), $(".small-chat-box").toggleClass("active")
    }), $(".small-chat-box .content").slimScroll({
        height: "234px",
        railOpacity: .4
    }), $(".check-link").click(function () {
        var e = $(this).find("i"),
            a = $(this).next("span");
        return e.toggleClass("fa-check-square").toggleClass("fa-square-o"), a.toggleClass("todo-completed"), !1
    }), $(".navbar-minimalize").click(function () {
        $("body").toggleClass("mini-navbar"), SmoothlyMenu()
    }), $(".tooltip-demo").tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    }), $(".modal").appendTo("body"), e(), $(window).bind("load", function () {
        $("body").hasClass("fixed-sidebar") && $(".sidebar-collapse").slimScroll({
            height: "100%",
            railOpacity: .9
        })
    }), $(window).scroll(function () {
        $(window).scrollTop() > 0 && !$("body").hasClass("fixed-nav") ? $("#right-sidebar").addClass("sidebar-top") : $("#right-sidebar").removeClass("sidebar-top")
    }), $(document).bind("load resize scroll", function () {
        $("body").hasClass("body-small") || e()
    }), $("[data-toggle=popover]").popover(), $(".full-height-scroll").slimscroll({
        height: "100%"
    })
}), $(window).bind("resize", function () {
    $(this).width() < 769 ? $("body").addClass("body-small") : $("body").removeClass("body-small")
}), $(document).ready(function () {
    if (localStorageSupport) {
        var e = localStorage.getItem("collapse_menu"),
            a = localStorage.getItem("fixedsidebar"),
            o = localStorage.getItem("fixednavbar"),
            i = localStorage.getItem("boxedlayout"),
            s = localStorage.getItem("fixedfooter"),
            l = $("body");
        "on" == a && (l.addClass("fixed-sidebar"), $(".sidebar-collapse").slimScroll({
            height: "100%",
            railOpacity: .9
        })), "on" == e && (l.hasClass("fixed-sidebar") ? l.hasClass("body-small") || l.addClass("mini-navbar") : l.hasClass("body-small") || l.addClass("mini-navbar")), "on" == o && ($(".navbar-static-top").removeClass("navbar-static-top").addClass("navbar-fixed-top"), l.addClass("fixed-nav")), "on" == i && l.addClass("boxed-layout"), "on" == s && $(".footer").addClass("fixed")
    }
});
$('.link-short a').text(function (index, oldText) {
    if (oldText.length > 15) {
        return oldText.substring(0, 15) + '...';
    }
    return oldText;
});

