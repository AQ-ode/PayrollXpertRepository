$(document).ready(function () {
    loadDataTable();
    $('#ProfileImage').change(function (event) {
        const input = event.target;
        const profileImagePreview = $('#profileImagePreview');
        profileImagePreview.attr('src', '').hide();
        if (input.files && input.files[0]) {
            const reader = new FileReader();
            reader.onload = function (e) {
                profileImagePreview.attr('src', e.target.result).show();
            };
            reader.readAsDataURL(input.files[0]);
        }
    });
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: 'https://localhost:7230/api/Employee',
            dataSrc: ''
        },
        columns: [

            {
                data: "profileImagePath",
                render: function (data) {
                    const baseUrl = 'https://localhost:7230/UploadedFiles/profile/';
                    return '<img src="' + baseUrl + data + '" class="card-img-top rounded" style="width: 50px; height: 50px; object-fit: cover;" />';
                }

            },

            { data: 'employeeNumber', width: '15%' },
            { data: 'firstName', width: '15%' },
            { data: 'lastName', width: '15%' },
            { data: 'gender', width: '10%' },
            { data: 'nationalId', width: '15%' },
            {
                data: 'dateOfBirth',
                width: '15%',
                render: function (data) {
                    let date = new Date(data);
                    return date.toLocaleDateString();
                }
            },
            { data: 'maritalStatus', width: '10%' },
            { data: 'contact', width: '15%' },
            {
                data: 'employeeId',
                render: function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="javascript:void(0)" onclick="editEmployee(${data})" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a href="javascript:void(0)" onclick="Delete('https://localhost:7230/api/Employee/${data}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>`;
                },
                width: '15%'
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    $('#tblData').DataTable().ajax.reload();
                    toastr.error("Employee Deleted Succesfully");
                }
            });
        }
    });
}
function prefillEmployeeForm(data) {
    $('#EmployeeNumber').val(data.employeeNumber);
    $('#FirstName').val(data.firstName);
    $('#LastName').val(data.lastName);
    $('#PersonType').val(data.personType).change();
    $('#Gender').val(data.gender).change();
    $('#NationalId').val(data.nationalId);
    $('#StartDate').val(data.startDate.split('T')[0]);
    $('#EndDate').val(data.endDate ? data.endDate.split('T')[0] : '');
    $('#DateOfBirth').val(data.dateOfBirth.split('T')[0]);
    $('#Country').val(data.country).change();
    $('#Province').val(data.province).change();
    $('#City').val(data.city).change();
    $('#Nationality').val(data.nationality).change();
    $('#Religion').val(data.religion).change();
    $('#FatherOrHusbandName').val(data.fatherOrHusbandName);
    $('#MotherName').val(data.motherName);
    $('#MaritalStatus').val(data.maritalStatus).change();
    $('#SpouseName').val(data.spouseName);
    $('#Contact').val(data.contact);
    $('#EmergencyContact').val(data.emergencyContact);
    if (data.shiftInformation) {
        $('#ShiftName').val(data.shiftInformation.shiftName).change();
        $('#StartTime').val(data.shiftInformation.startTime);
        $('#EndTime').val(data.shiftInformation.endTime);
    }

    if (data.qualification) {
        $('#QualificationType').val(data.qualification.qualificationType).change();
        $('#DegreeTitle').val(data.qualification.degreeTitle).change();
        $('#MajorSubject').val(data.qualification.majorSubject).change();
        $('#MarksOrCGPA').val(data.qualification.marksOrCGPA);
        $('#QualificationStartDate').val(data.qualification.startDate.split('T')[0]);
        $('#QualificationEndDate').val(data.qualification.endDate.split('T')[0]);
        $('#Institute').val(data.qualification.institute).change();
    }
    $('#OldProfileImagePath').val(data.profileImagePath);
    if (data.profileImagePath) {
        const baseUrl = 'https://localhost:7230/UploadedFiles/profile/';
        $('#profileImagePreview').attr('src', baseUrl + data.profileImagePath).show();
        existingImageAvailable = true;
    } else {
        $('#profileImagePreview').attr('src', '').hide();
        existingImageAvailable = false;
    }
}
function editEmployee(employeeId) {
    $.ajax({
        url: `https://localhost:7230/api/employee/upsert/${employeeId}`,
        type: 'GET',
        success: function (data) {

            prefillEmployeeForm(data);


            window.location.assign(`Employee/Upsert?id=${employeeId}`);
        },
        error: function (xhr, status, error) {
            console.log("Error fetching employee data:", error);
        }
    });
}
$('#send').click(function (event) {
    event.preventDefault();

    let startTime = $('#StartTime').val();
    let endTime = $('#EndTime').val();

    let convertToTimeSpan = (timeString) => {
        let [hours, minutes] = timeString.split(':').map(num => parseInt(num, 10));
        return `${hours}:${minutes}:00`;
    };

    let formData = new FormData();

    formData.append('Employee.EmployeeId', employeeId ? parseInt(employeeId, 10) : 0);

    console.log(employeeId);
    formData.append('Employee.EmployeeNumber', parseInt($('#EmployeeNumber').val(), 10));
    formData.append('Employee.FirstName', $('#FirstName').val());
    formData.append('Employee.LastName', $('#LastName').val());
    formData.append('Employee.PersonType', $('#PersonType').val());
    formData.append('Employee.Gender', $('#Gender').val());
    formData.append('Employee.NationalId', $('#NationalId').val());
    formData.append('Employee.StartDate', $('#StartDate').val());
    formData.append('Employee.EndDate', $('#EndDate').val());
    formData.append('Employee.DateOfBirth', $('#DateOfBirth').val());
    formData.append('Employee.Country', $('#Country').val());
    formData.append('Employee.Province', $('#Province').val());
    formData.append('Employee.City', $('#City').val());
    formData.append('Employee.Nationality', $('#Nationality').val());
    formData.append('Employee.Religion', $('#Religion').val());
    formData.append('Employee.FatherOrHusbandName', $('#FatherOrHusbandName').val());
    formData.append('Employee.MotherName', $('#MotherName').val());
    formData.append('Employee.MaritalStatus', $('#MaritalStatus').val());
    formData.append('Employee.SpouseName', $('#SpouseName').val());
    formData.append('Employee.Contact', $('#Contact').val());
    formData.append('Employee.EmergencyContact', $('#EmergencyContact').val());


    formData.append('Employee.ShiftInformation.ShiftName', $('#ShiftName').val());
    formData.append('Employee.ShiftInformation.StartTime', convertToTimeSpan(startTime));
    formData.append('Employee.ShiftInformation.EndTime', convertToTimeSpan(endTime));


    formData.append('Employee.Qualification.QualificationType', $('#QualificationType').val());
    formData.append('Employee.Qualification.DegreeTitle', $('#DegreeTitle').val());
    formData.append('Employee.Qualification.MajorSubject', $('#MajorSubject').val());
    formData.append('Employee.Qualification.MarksOrCGPA', parseInt($('#MarksOrCGPA').val(), 10));
    formData.append('Employee.Qualification.StartDate', $('#QualificationStartDate').val());
    formData.append('Employee.Qualification.EndDate', $('#QualificationEndDate').val());
    formData.append('Employee.Qualification.Institute', $('#Institute').val());

    let profileImage = $('#ProfileImage')[0].files[0];
    if (profileImage) {
        formData.append('ProfileImage', profileImage);
    }

    $.ajax({
        url: 'https://localhost:7230/api/Employee/upsert',
        type: 'POST',
        processData: false,
        contentType: false,
        data: formData,
        success: function (response) {
            Command: toastr["success"]("Employee Added Successfully.");
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
            };
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

$(document).ready(function () {
    $('#NationalId').inputmask('99999-9999999-9');
    $('#Contact').inputmask('9999-9999999');
    $('#EmergencyContact').inputmask('9999-9999999');


});
let employeeId = null;
$(document).ready(function () {
    const urlParams = new URLSearchParams(window.location.search);
    employeeId = urlParams.get('id');

    if (employeeId) {
        $.ajax({
            url: `https://localhost:7230/api/employee/upsert/${employeeId}`,
            type: 'GET',
            success: function (data) {
                prefillEmployeeForm(data);
                $('#send').text('Update');
            },
            error: function (xhr, status, error) {
                console.log("Error fetching employee data:", error);
            }
        });
    } else {
        $('#send').text('Create');
    }
});
