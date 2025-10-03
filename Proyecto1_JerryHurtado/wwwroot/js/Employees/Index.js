// Inicializa componentes al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Empleados',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            'Empleados'
        ],
        buttonText: 'Agregar Empleado',
        buttonAction: '/Employees/Create',
        buttonTooltip: 'Registra un nuevo empleado.',
        showSearchButton: true
    });
    document.querySelector('#subheader-container').appendChild(subheader);
    loadEmployees();
});

// Obtener la lista de empleados
function loadEmployees() {
    $.ajax({
        url: '/Employees/GetEmployees',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            const tbody = $('#employeesTable tbody');
            tbody.empty();

            if (response.data.length === 0) {
                const emptyRow = `
                                    <tr>
                                        <td colspan="5" class="text-center text-muted">
                                            No hay empleados registrados.
                                        </td>
                                    </tr>
                                `;
                tbody.append(emptyRow);
                return;
            } else {
                response.data.forEach(employees => {
                    const row = `
                                <tr>
                                    <td>${employees.personalIdNumber}</td>
                                    <td>${employees.hireDateDisplay}</td>
                                    <td>₡${employees.dailySalary}</td>
                                    <td>${employees.typeDisplay}</td>
                                    <td class="text-center">
                                        <div class="dropdown">
                                            <button class="btn btn-action dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Opciones">
                                                <img src="/icons/three-dots-vertical.svg" alt="Opciones" width="16" height="16">
                                            </button>
                                            <ul class="dropdown-menu dropdown-menu-custom">
                                                <li>
                                                    <a class="dropdown-item" href="/Employees/Detail/${employees.id}">
                                                        <img src="/icons/see-detail.svg" alt="Detalle" width="16" height="16"> Ver Detalle
                                                    </a>
                                                </li>
                                                <li>
                                                    <a class="dropdown-item" href="/Employees/Edit/${employees.id}">
                                                        <img src="/icons/edit.svg" alt="Editar" width="16" height="16"> Editar
                                                    </a>
                                                </li>
                                                <li>
                                                    <a class="dropdown-item" href="#" onclick="Delete('${employees.id}')">
                                                        <img src="/icons/delete.svg" alt="Eliminar" width="16" height="16"> Eliminar
                                                    </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
                            `;
                    tbody.append(row);
                });
            }
        },
        error: function () {
            showFeedbackModal({ title: '¡Error!', message: 'No se pudieron cargar los empleados.', type: 'danger' });
        }
    });
}

// Función para eliminar un empleado
function Delete(id) {
    handleCrudDelete({
        id: id,
        url: '/Employees/Delete',
        modalTitle: '¿Confirmas que deseas eliminar este registro de empleado?',
        modalMessage: 'Esta acción es permanente y no se puede deshacer.',
        onSuccess: loadEmployees
    });
}