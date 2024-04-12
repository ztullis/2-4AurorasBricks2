document.addEventListener("DOMContentLoaded", function () {
    var logoutLink = document.getElementById("logoutLink");
    if (logoutLink) {
        logoutLink.addEventListener("click", function () {
            document.getElementById('logoutForm').submit();
        });
    }
});
