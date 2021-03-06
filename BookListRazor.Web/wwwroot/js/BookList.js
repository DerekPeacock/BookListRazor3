﻿var dataTable;
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable()
{
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/Books",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "title", "width": "25%" },
            { "data": "authors", "width": "25%" },
            { "data": "isbn", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center" >
                                <a href="/Books/Edit?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width=100px;' >
                                    Edit
                                </a>
                                <a class='btn btn-danger text-white' style='cursor:pointer; width=100px;' onclick=Delete('api/Books?id='+${data}) >
                                    Delete
                                </a>
                            </div>`;
                }, "width": "25%"
            }
        ],
        "language": {
            "emptyTable": "no data found!"
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}