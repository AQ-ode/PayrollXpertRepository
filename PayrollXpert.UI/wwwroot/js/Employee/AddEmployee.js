$(document).ready(function () {
    $('#send').click(function (event) {
        event.preventDefault();
        var formData = {
            FullName: $('#fullName').val(),
            Gender: $('#gender').val(),
            DateOfBirth: $('#dob').val(),
            NationalId: $('#cnic').val(),
            JobTitle: $('#designation').val(),
            Department: {
                Name: $('#department').val()
            },
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

        $.ajax({
            url: 'https://localhost:7230/api/Employee',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
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
});
