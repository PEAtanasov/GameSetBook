document.addEventListener('DOMContentLoaded', function () {
    var selectElements = document.querySelectorAll('#filterForm select');

    selectElements.forEach(function (select) {
        select.addEventListener('change', function () {
            document.getElementById('filterForm').submit();
        });
    });
});