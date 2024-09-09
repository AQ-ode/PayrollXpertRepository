$(document).ready(function () {
    $('#send').click(function (event) {
        event.preventDefault();
        var formData = {
            FullName: $('#fullName').val(),
            Gender: $('#gender').val(),
            DateOfBirth: $('#dob').val(),
            NationalId: $('#cnic').val(),
            JobTitle: $('#designation').val(),
            DepartmentId: $('#department').val(), 
            DateOfJoining: $('#joiningDate').val(),
            EmploymentType: $('#employmentType').val(),
            Salary: $('#salary').val(),
            PayFrequency: $('#payFrequency').val(),
            BankAccountNumber: $('#bankAccount').val(),
            BankName: $('#bankName').val(),
            TaxId: $('#taxId').val(),
            PhoneNumber: $('#phoneNumber').val(),
            Email: $('#email').val(),
            Address: $('#address').val(),
            EmergencyContactName: $('#emergencyContactName').val(),
            EmergencyContactPhone: $('#emergencyContactPhone').val(),
            EmergencyContactRelationship: $('#emergencyContactRelationship').val()
        };
        console.log(formData);
        $.ajax({
            url: 'https://localhost:7230/api/Employee',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                alert("Employee Created Succesfully");
            },
            error: function (xhr, status, error) {
                console.error('Form submission failed:', status, error);
                var response = JSON.parse(xhr.responseText);
                for (var key in response.errors) {
                    var errorMessages = response.errors[key];
                    if (errorMessages.length > 0) {
                        $('#error' + key).text(errorMessages.join(', '));
                    }
                }
            }
        });
    });

    function loadDepartments() {
        $.ajax({
            url: 'https://localhost:7230/api/Department',
            type: 'GET',
            success: function (departments) {
                var $departmentSelect = $('#department');
                $departmentSelect.empty();
                $departmentSelect.append('<option value="" disabled selected>Select Department</option>');

                $.each(departments, function (index, department) {
                    $departmentSelect.append(
                        $('<option></option>').val(department.id).text(department.name)
                    );
                });
            },
            error: function (xhr, status, error) {
                console.error('Failed to load departments:', status, error);
            }
        });
    }

    loadDepartments();
});
