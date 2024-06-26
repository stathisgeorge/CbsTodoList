﻿$('.deleteBtn').click(function () {
    var taskId = $(this).data('id');
    var url = $(this).data('url');

    if (confirm('Are you sure you want to delete this item;')) {
        $.ajax({
            type: "DELETE",
            url: url,
            data: { id: taskId },
            success: function (data) {
                $('#successMessage').fadeIn().delay(3000).fadeOut();
                window.location.href = data.redirectToUrl;

            },
            error: function (error) {
                console.log('error', error);
            }
        });
    }
});

//Δημιουργία νέου Task
function add() {
    var taskModalForm = new bootstrap.Modal(document.getElementById('taskModalForm'));
    document.getElementById('modal-Title').innerText = "Save Task";
    $('#taskModalForm').modal('show');
}

$('.editStatusCheckbox').change(function () {
    var taskId = $(this).data('id');
    var url = $(this).data('url');
    console.log(url);
    $.ajax({
        type: "PUT",
        url: url,
        data: { id: taskId },
        success: function (data) {
            if (data.redirectToUrl) {
                window.location.href = data.redirectToUrl;
            }
            console.log('success');
        },
        error: function (error) {
            console.log('error', error);
        }
    });
});
 