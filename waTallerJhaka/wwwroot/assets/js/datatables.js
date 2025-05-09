document.addEventListener("DOMContentLoaded", function () {
    const rowsPerPageSelect = document.getElementById("rowsPerPage");
    const rows = document.querySelectorAll("#tabla tbody tr");
    const pagination = document.getElementById("pagination");
    let rowsPerPage = parseInt(rowsPerPageSelect.value);
    let currentPage = 1;

    // Función para mostrar las filas de la tabla según la página
    function displayRows() {
        const start = (currentPage - 1) * rowsPerPage;
        const end = start + rowsPerPage;

        rows.forEach((row, index) => {
            row.style.display = (index >= start && index < end) ? "" : "none";
        });
    }

    // Función para configurar los botones de paginación
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

    // Evento para cambiar la cantidad de filas por página
    rowsPerPageSelect.addEventListener("change", function () {
        rowsPerPage = parseInt(this.value);
        currentPage = 1; // Reseteamos a la primera página
        displayRows();
        setupPagination();
    });

    // Inicialización de la paginación
    displayRows();
    setupPagination();
});
