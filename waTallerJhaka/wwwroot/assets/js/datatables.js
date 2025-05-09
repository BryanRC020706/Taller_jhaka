document.addEventListener("DOMContentLoaded", function () {
    const rowsPerPageSelect = document.getElementById("rowsPerPage");
    const rows = document.querySelectorAll("#tabla tbody tr");
    const pagination = document.getElementById("pagination");
    let rowsPerPage = parseInt(rowsPerPageSelect.value);
    let currentPage = 1;

    // Funci�n para mostrar las filas de la tabla seg�n la p�gina
    function displayRows() {
        const start = (currentPage - 1) * rowsPerPage;
        const end = start + rowsPerPage;

        rows.forEach((row, index) => {
            row.style.display = (index >= start && index < end) ? "" : "none";
        });
    }

    // Funci�n para configurar los botones de paginaci�n
    function setupPagination() {
        pagination.innerHTML = "";
        const totalPages = Math.ceil(rows.length / rowsPerPage);

        for (let i = 1; i <= totalPages; i++) {
            const btn = document.createElement("button");
            btn.textContent = i;
            btn.className = "btn btn-sm mx-1 " + (i === currentPage ? "btn-primary" : "btn-outline-primary");
            btn.addEventListener("click", function () {
                currentPage = i;
                displayRows();
                setupPagination();
            });
            pagination.appendChild(btn);
        }
    }

    // Evento para cambiar la cantidad de filas por p�gina
    rowsPerPageSelect.addEventListener("change", function () {
        rowsPerPage = parseInt(this.value);
        currentPage = 1; // Reseteamos a la primera p�gina
        displayRows();
        setupPagination();
    });

    // Inicializaci�n de la paginaci�n
    displayRows();
    setupPagination();
});
