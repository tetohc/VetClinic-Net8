// Inicilialización del subheader y carga de clientes
$(function () {
    const subheader = createSubheader({
        title: 'Clientes',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            'Clientes'
        ],
        buttonText: 'Agregar Cliente',
        buttonAction: '/Customers/Create',
        buttonTooltip: 'Registra un nuevo cliente.',
        showSearchButton: true
    });
    document.querySelector('#subheader-container').appendChild(subheader);
    loadProcedures();
});

// Obtener la lista de clientes
function loadProcedures() {
    $.ajax({
        url: '/Customers/GetCustomers',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            const tbody = $('#customersTable tbody');
            tbody.empty();

            if (response.data.length === 0) {
                const emptyRow = `
                                    <tr>
                                        <td colspan="5" class="text-center text-muted">
                                            No hay clientes registrados.
                                        </td>
                                    </tr>
                                `;
                tbody.append(emptyRow);
                return;
            } else {
                response.data.forEach(data => {
                    const row = `
                                <tr>
                                    <td>${data.personalIdNumber}</td>
                                    <td>${data.fullName}</td>
                                    <td>${data.province}</td>
                                    <td>${data.contactPreferenceDisplay}</td>
                                    <td class="text-center">
                                        <div class="dropdown">
                                            <button class="btn btn-action dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Opciones">
                                                <img src="/icons/three-dots-vertical.svg" alt="Opciones" width="16" height="16">
                                            </button>
                                            <ul class="dropdown-menu dropdown-menu-custom">
                                                <li>
                                                    <a class="dropdown-item" href="/Customers/Detail/${data.id}">
                                                        <img src="/icons/see-detail.svg" alt="Detalle" width="16" height="16"> Ver Detalle
                                                    </a>
                                                </li>
                                                <li>
                                                    <a class="dropdown-item" href="/Customers/Edit/${data.id}">
                                                        <img src="/icons/edit.svg" alt="Editar" width="16" height="16"> Editar
                                                    </a>
                                                </li>
                                                <li>
                                                    <a class="dropdown-item" href="#" onclick="Delete('${data.id}')">
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
            showFeedbackModal({ title: '¡Error!', message: 'No se pudieron cargar los clientes.', type: 'danger' });
        }
    });
}

// Función para eliminar un cliente
function Delete(id) {
    handleCrudDelete({
        id: id,
        url: '/Customers/Delete',
        modalTitle: '¿Confirmas que deseas eliminar este registro de cliente?',
        modalMessage: 'Esta acción es permanente y no se puede deshacer.',
        onSuccess: loadProcedures
    });
}