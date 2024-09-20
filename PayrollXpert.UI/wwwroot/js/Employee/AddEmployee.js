
$('#send').click(function (event) {
    event.preventDefault();
    let startTime = $('#StartTime').val();
    let endTime = $('#EndTime').val();
    let convertToTimeSpan = (timeString) => {
        let [hours, minutes] = timeString.split(':').map(num => parseInt(num, 10));
        return `${hours}:${minutes}:00`;
    };

    let employee = {

        EmployeeNumber: parseInt($('#EmployeeNumber').val(), 10),
        FirstName: $('#FirstName').val(),
        LastName: $('#LastName').val(),
        PersonType: $('#PersonType').val(),
        Gender: $('#Gender').val(),
        NationalId: $('#NationalId').val(),
        StartDate: $('#StartDate').val(),
        EndDate: $('#EndDate').val(),
        DateOfBirth: $('#DateOfBirth').val(),
        Country: $('#Country').val(),
        Province: $('#Province').val(),
        City: $('#City').val(),
        Nationality: $('#Nationality').val(),
        Religion: $('#Religion').val(),
        FatherOrHusbandName: $('#FatherOrHusbandName').val(),
        MotherName: $('#MotherName').val(),
        MaritalStatus: $('#MaritalStatus').val(),
        SpouseName: $('#SpouseName').val(),
        Contact: $('#Contact').val(),
        EmergencyContact: $('#EmergencyContact').val(),
        ShiftInformation: {
            ShiftName: $('#ShiftName').val(),
            StartTime: convertToTimeSpan(startTime),
            EndTime: convertToTimeSpan(endTime)
        },
        Qualification: {
            QualificationType: $('#QualificationType').val(),
            DegreeTitle: $('#DegreeTitle').val(),
            MajorSubject: $('#MajorSubject').val(),
            MarksOrCGPA: parseInt($('#MarksOrCGPA').val(), 10),
            StartDate: $('#QualificationStartDate').val(),
            EndDate: $('#QualificationEndDate').val(),
            Institute: $('#Institute').val()
        }
    }
    $.ajax({
        url: 'https://localhost:7230/api/Employee',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(employee),
        success: function (response) {
            Command: toastr["success"]("Employee Added Succesfully.")
            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": false,
                "positionClass": "toast-top-right",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
        },
        error: function (xhr, status, error) {
            console.error('Form submission failed:', xhr.responseText, status, error);
            alert('Failed to create employee. ' + xhr.responseText);
        }
    });
});

$(document).ready(function () {
    var currentSectionIndex = 0;
    var totalSections = $('.form-section').length;

    function updateProgressBar() {
        if (currentSectionIndex == 0) {
            progress = 0;
            $('.progress-bar').css('width', progress + '%').text(Math.round(progress) + '%');
        }
        else {
            var progress = ((currentSectionIndex + 1) / totalSections) * 100;
            $('.progress-bar').css('width', progress + '%').text(Math.round(progress) + '%');
        }

    }

    function showSection(index) {
        $('.form-section').removeClass('current').eq(index).addClass('current');
        updateProgressBar();
    }

    $('.next').click(function () {
        if (currentSectionIndex < totalSections - 1) {
            currentSectionIndex++;
            showSection(currentSectionIndex);
        }
    });

    $('.prev').click(function () {
        if (currentSectionIndex > 0) {
            currentSectionIndex--;
            showSection(currentSectionIndex);
        }
    });

    showSection(currentSectionIndex);
});

