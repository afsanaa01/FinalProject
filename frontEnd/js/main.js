AOS.init();
updateNav();
updateScroller();

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

$(function () {
  $('.owl-carousel').owlCarousel({
    nav: true,
    navText: ["<div class='nav-button owl-prev'>‹</div>", "<div class='nav-button owl-next'>›</div>"],
    responsive: {
      0: {
        items: 3
      },
      600: {
        items: 6
      },
      1000: {
        items: 3
      }
    }
  });
});

function openModal() {
  document.getElementById("myModal").style.display = "block";
}

function closeModal() {
  document.getElementById("myModal").style.display = "none";
}

var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
  showSlides((slideIndex += n));
}

function currentSlide(n) {
  showSlides((slideIndex = n));
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("demo");
  var captionText = document.getElementById("caption");
  if (n > slides.length) {
    slideIndex = 1;
  }
  if (n < 1) {
    slideIndex = slides.length;
  }
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex - 1].style.display = "block";
  dots[slideIndex - 1].className += " active";
  captionText.innerHTML = dots[slideIndex - 1].alt;
}

$('.leaveComment').on("click", function () {
  $('.comment-part').addClass('.toshow');
});