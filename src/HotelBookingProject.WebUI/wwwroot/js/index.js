$(document).ready(function () {

    $('.list-group-item[data-city-id="1"]').addClass('initial-selected-item');
});

function selectElement(cityId) {
    console.log("Selected city with ID:", cityId);

    $('.list-group-item').removeClass('selected-item');
    $('.list-group-item').removeClass('initial-selected-item');

    $(`.list-group-item[data-city-id='${cityId}']`).addClass('selected-item');

    $.ajax({
        url: hotelUrl,
        type: 'GET',
        data: { cityId: cityId },
        success: function (data) {
            $('.content').html(data);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching hotels:", error);
        }
    });
}