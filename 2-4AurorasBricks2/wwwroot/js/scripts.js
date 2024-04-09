/*!
* Start Bootstrap - Business Casual v7.0.9 (https://startbootstrap.com/theme/business-casual)
* Copyright 2013-2023 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-business-casual/blob/master/LICENSE)
*/
// Highlights current date on contact page
window.addEventListener('DOMContentLoaded', event => {
    const listHoursArray = document.body.querySelectorAll('.list-hours li');
    const todayIndex = new Date().getDay();
    // Check if the list has elements and the specific day element exists
    if (listHoursArray.length > 0 && listHoursArray[todayIndex]) {
        listHoursArray[todayIndex].classList.add('today');
    }
});

