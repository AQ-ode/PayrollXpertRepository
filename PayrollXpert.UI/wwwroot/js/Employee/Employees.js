﻿$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: 'https://localhost:7230/api/Employee',
            dataSrc: '' 
        },
        columns: [
            { data: 'fullName', width: '20%' },    
            { data: 'salary', width: '15%' },     
            { data: 'jobTitle', width: '15%' },    
            { data: 'nationalId', width: '20%' },  
            { data: 'address', width: '20%' },    
            { data: 'department.name', width: '15%' },  

            {
                data: 'id',
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/employee/upsert?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a href="javascript:void(0)" onclick="Delete('https://localhost:7230/api/Employee/${data}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>`;
                },
                "width": "10%"
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
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            });
        }
    });


}