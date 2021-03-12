// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.'
function multiplyActivityLevel(activityLevel, baseCalorieValue) {
    var defaultActivityLevel = 1.4;
    var remainingCalElement = document.getElementsByClassName("dailyCaldiv")[0];
    remainingCalElement.innerHTML = (baseCalorieValue / defaultActivityLevel * activityLevel).toFixed(2);
}