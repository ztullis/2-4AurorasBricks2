/*!
* Start Bootstrap - Business Casual v7.0.9 (https://startbootstrap.com/theme/business-casual)
* Copyright 2013-2023 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-business-casual/blob/master/LICENSE)
*/
// Highlights current date on contact page
window.addEventListener('DOMContentLoaded', event => {
    const listHoursArray = document.body.querySelectorAll('.list-hours li');
    listHoursArray[new Date().getDay()].classList.add(('today'));
})

function toggleDescription(button) {
    var description = button.parentElement;
    var fullDescription = description.querySelector('.full');

    if (fullDescription.style.display === 'none' || fullDescription.style.display === '') {
        fullDescription.style.display = 'inline';
        button.innerText = 'Less...';
    } else {
        fullDescription.style.display = 'none';
        button.innerText = 'More...';
    }
}


$(document).ready(function () {
    // Show overlay when delete button is clicked
    $("#show-overlay-button").click(function () {
        $("#confirmation-overlay").show();
    });

    // Hide overlay when cancel button or outside the overlay is clicked
    $("#cancel-button, .overlay").click(function () {
        $("#confirmation-overlay").hide();
    });
});



// Toggle buttons on the main page to go through each item that is being recommended
document.addEventListener('DOMContentLoaded', function () {
    var cards = document.querySelectorAll('.card');
    var currentCardIndex = 0; // Start with the first card

    cards.forEach(function (card, index) {
        if (index !== 0) {
            card.style.display = 'none';
        }
    });

    function showNextCard() {
        cards[currentCardIndex].style.display = 'none';
        currentCardIndex = (currentCardIndex + 1) % cards.length;
        cards[currentCardIndex].style.display = 'block';
    }

    function showPrevCard() {
        cards[currentCardIndex].style.display = 'none';
        currentCardIndex = (currentCardIndex - 1 + cards.length) % cards.length;
        cards[currentCardIndex].style.display = 'block';
    }

    document.querySelectorAll('.nextButton').forEach(function (button) {
        button.addEventListener('click', showNextCard);
    });

    document.querySelectorAll('.prevButton').forEach(function (button) {
        button.addEventListener('click', showPrevCard);
    });
});











