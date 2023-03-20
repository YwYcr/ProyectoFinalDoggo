var slideIndex = 0;
var slides = document.getElementById("slideshow").getElementsByTagName("img");

function showSlide() {
    // hide all slides
    for (var i = 0; i < slides.length; i++) {
        slides[i].classList.remove("active");
    }

    // show the current slide
    slides[slideIndex].classList.add("active");

    // increment the slide index
    slideIndex++;
    if (slideIndex >= slides.length) {
        slideIndex = 0;
    }

    // schedule the next slide
    setTimeout(showSlide, 5000); // adjust the delay as needed
}

showSlide(); // start the slideshow
