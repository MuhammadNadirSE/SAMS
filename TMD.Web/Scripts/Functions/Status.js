$(document).ready(function () {
    window.siteURL = $('#siteURL').val();
    $('#checkIn').on('click', function () {
        var url = "/Attendance/CheckIn";
        makeAjaxCall(url);
    });

    $('#checkOut').on('click', function () {
        var url = "/Attendance/CheckOut";
        makeAjaxCall(url);
    });

    $('#away').on('click', function () {
        var url = "/Attendance/Away";
        makeAjaxCall(url);
    });

    $('#available').on('click', function () {
        var url = "/Attendance/Available";
        makeAjaxCall(url);
    });

});

function makeAjaxCall(url) {
    $.blockUI({ css: { backgroundColor: 'black', color: 'white',border:'none' } });
    $.ajax({
        url: window.siteURL + url,
        type: "POST",
        data: {},
        datatype: "json",
        success: function (response) {
            changeStatusIconColor(response);
        },
        complete: function (response) {
            $.unblockUI();
        },
        error: function() {
            toastr.error("Request cannot be completed at the moment","Opps ! Something went wrong.");
        }
    });
}

function changeStatusIconColor(response) {
    debugger
    if (response != 4) {
        var status = "";
        switch (response) {
            case 0:
                status = "Checked in";
                $('#statusBtn').css('background-color', 'greenyellow');

                if (!$('#checkIn').hasClass('notAllowed'))
                    $('#checkIn').addClass('notAllowed');

                if ($('#away').hasClass('notAllowed'))
                    $('#away').removeClass('notAllowed');

                if (!$('#available').hasClass('notAllowed'))
                    $('#available').addClass('notAllowed');

                if ($('#checkOut').hasClass('notAllowed'))
                    $('#checkOut').removeClass('notAllowed');
                break;

            case 1:
                status = "Away";
                $('#statusBtn').css('background-color', 'yellow');

                if (!$('#checkIn').hasClass('notAllowed'))
                    $('#checkIn').addClass('notAllowed');

                if (!$('#away').hasClass('notAllowed'))
                    $('#away').addClass('notAllowed');

                if ($('#available').hasClass('notAllowed'))
                    $('#available').removeClass('notAllowed');

                if ($('#checkOut').hasClass('notAllowed'))
                    $('#checkOut').removeClass('notAllowed');
                break;

            case 2:
                status = "Checked out";
                $('#statusBtn').css('background-color', 'red');

                if (!$('#checkOut').hasClass('notAllowed'))
                    $('#checkOut').addClass('notAllowed');

                if (!$('#away').hasClass('notAllowed'))
                    $('#away').addClass('notAllowed');

                if (!$('#available').hasClass('notAllowed'))
                    $('#available').addClass('notAllowed');
                break;

            case 3:
                status = "Available";
                $('#statusBtn').css('background-color', 'greenyellow');

                if (!$('#checkIn').hasClass('notAllowed'))
                    $('#checkIn').addClass('notAllowed');

                if ($('#away').hasClass('notAllowed'))
                    $('#away').removeClass('notAllowed');

                if (!$('#available').hasClass('notAllowed'))
                    $('#available').addClass('notAllowed');

                if ($('#checkOut').hasClass('notAllowed'))
                    $('#checkOut').removeClass('notAllowed');
                break;

            case 5:
                $('#statusBtn').css('background-color', 'greenyellow');
                if (!$('#away').hasClass('notAllowed'))
                    $('#away').addClass('notAllowed');
                if (!$('#available').hasClass('notAllowed'))
                    $('#available').addClass('notAllowed');
                toastr.warning("You can set your status to away once in a day! Please contact admin");
                return false;
        }
        toastr.success("You have successfully changed status to '" + status + "'");
    }
    else
        toastr.error("You cannot chek in again the same day. Please come tomorrrow to check in again.");

}