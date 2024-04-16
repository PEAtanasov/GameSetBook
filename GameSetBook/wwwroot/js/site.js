document.addEventListener('DOMContentLoaded', function () {
    var selectElements = document.querySelectorAll('#filterForm select');

    selectElements.forEach(function (select) {
        select.addEventListener('change', function () {
            document.getElementById('filterForm').submit();
        });
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var datepickerElements = document.querySelectorAll('#filterForm input[type="date"]');

    datepickerElements.forEach(function (input) {
        input.addEventListener('change', function () {
            document.getElementById('filterForm').submit();
        });
    });
});