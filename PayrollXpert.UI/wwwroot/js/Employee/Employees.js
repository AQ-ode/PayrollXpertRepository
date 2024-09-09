$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        
        columns: [
            { data: 'name', "width": "20%" },
            { data: 'salary', "width": "15%" },
            { data: 'designation', "width": "15%" },
            { data: 'cnic', "width": "20%" },
            { data: 'address', "width": "20%" },
            {
                data: 'id',
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/employee/upsert?id=${data}" class="btn btn-primary mx-2">
                                <i class="bi bi-pencil-square"></i> Edit
                            </a>
                            <a href="javascript:void(0)" onclick="Delete('/admin/employee/delete/${data}')" class="btn btn-danger mx-2">
                                <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>`;
                },
                "width": "10%"
            }
        ]
    });
}
