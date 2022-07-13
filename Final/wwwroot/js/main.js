$(function () {
AOS.init();
updateNav();
updateScroller();

let skip = 6;
let productCount = $("#prodCount").val();

    $(document).on("change", "#filter", function () {
        $("#search-results").html("");
        let query = $("#filter").val();
            $.ajax({
                url: "/Category/Filter?orderBy=" + query,
                type: "get",
                success: function (result) {
                    $("#search-results").append(result);
                }
            })
    });

$(document).on("keyup", "#search", function () {
    $("#search-results").html("");
    let query = $("#search").val();
    if (query.length > 1) {
        $.ajax({
            url: "/Category/SearchProduct?query=" + query,
            type: "get",
            success: function (result) {
                $("#search-results").append(result);
                console.log(result);
            }
        })
    }
});

$(document).on("click", "#load-more-button", function (e) {
    e.preventDefault();
    $.ajax({
        url: "/Category/LoadProductsAsView?skip=" + skip,
        type: "get",
        success: function (res) {
            skip += 6;
            $(".product-container").append(res);
            if (skip >= productCount) {
                $("#load-more-button").remove();
            }
        }
    })
})

$("#plant-link").on("click", function () {
    $(".plant-carousel").removeClass("d-none");
    $(".flower-carousel").addClass("d-none");
});

$("#flower-link").on("click", function () {
    $(".plant-carousel").addClass("d-none");
    $(".flower-carousel").removeClass("d-none");
});

if ($("#messageToUser").val()) {
    swal({
        title: "Thank you!",
        text: $("#messageToUser").val(),
        icon: "success",
        button: "OK",
    });
}

$(window).scroll(function () {
  updateNav();
  updateScroller();
});

function updateNav() {
  if ($(window).scrollTop() > 30) {
    $(".navbar").addClass("scrolled");
    $(".upper").removeClass("d-none");
  } else {
    $(".navbar").removeClass("scrolled");
    $(".upper").addClass("d-none");
  }
}

function updateScroller() {
  if ($(window).scrollTop() > 100) {
    $(".scroll-top").fadeIn(200);
  } else {
    $(".scroll-top").fadeOut(200);
  }
}

$(document).on("click", ".scroll-top", function () {
  $(window).scrollTop(0);
});

$(document).on("click", ".scroll-top", function () {
  $(window).scrollTop(0);
});

$(document).on("click", ".upper", function () {
  $(window).scrollTop(0);
});
});