// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    let selects = $('.form-select-multi')
    for (let i = 0; i < selects.length; i++) {
        $(selects[i]).multiselect({
            // Bootstrap 5 compatibility
            templates: {
                button: '<button type="button" class="multiselect dropdown-toggle btn btn-primary" data-bs-toggle="dropdown" aria-expanded="false"><span class="multiselect-selected-text"></span></button>',
            },
        });
    }
});