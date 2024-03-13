document.addEventListener('DOMContentLoaded', function () {
    $('#startDate').change(function () {
        let startDate = $(this).val();
        $('#endDate').attr('min', startDate);
    });

    $('.book-room-btn').click(function () {
        let roomId = $(this).data('room-id');
        $('#room-id').val(roomId);
        $('#bookingModal').modal('show');
    });

    $('#bookingForm').submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: bookingActionUrl, 
            type: 'POST',
            data: $(this).serialize(),
            success: function (response) {
                if (response.success) {
                    window.location.href = homeUrl; 
                } else {
                    $("#errorMessageStartDate").empty();
                    $("#errorMessageEndDate").empty();

                    if (response.errors && response.errors.length > 0) {
                        $("#errorMessageStartDate").append($('<span/>').text("Please, input correct data"));
                        $("#errorMessageEndDate").append($('<span/>').text("Please, input correct data"));
                    }
                }
            },
            error: function (xhr, status, error) {
                console.error("Error:", error);
            }
        });
    });
});