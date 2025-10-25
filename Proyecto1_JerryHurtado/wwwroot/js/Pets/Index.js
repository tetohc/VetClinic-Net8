// Inicilialización del subheader y carga de mascotas
$(function () {
    const subheader = createSubheader({
        title: 'Mascotas',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            'Mascotas'
        ],
        buttonText: 'Agregar Mascota',
        buttonAction: '/Pets/Create',
        buttonTooltip: 'Registra una nueva mascota.',
        showSearchButton: true
    });
    document.querySelector('#subheader-container').appendChild(subheader);
    loadPets();
});

// Obtener la lista de mascotas
function loadPets() {
    $.ajax({
        url: '/Pets/GetPets',
        type: 'GET',
        dataType: 'json',
        success: function (response) {
            const tbody = $('#petsTable tbody');
            tbody.empty();

            if (response.data.length === 0) {
                const emptyRow = `
                                    <tr>
                                        <td colspan="5" class="text-center text-muted">
                                            No hay mascotas registradas.
                                        </td>
                                    </tr>
                                `;
                tbody.append(emptyRow);
                return;
            } else {
                response.data.forEach(data => {
                    const row = `
                                <tr>
                                    <td>${data.name}</td>
                                    <td>${data.petSpeciesDisplay}</td>
                                    <td>${data.race}</td>
                                    <td>${data.lastVisitDateDisplay}</td>
                                    <td class="text-center">
                                        <div class="dropdown">
                                            <button class="btn btn-action dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false" title="Opciones">
                                                <img src="/icons/three-dots-vertical.svg" alt="Opciones" width="16" height="16">
                                            </button>
                                            <ul class="dropdown-menu dropdown-menu-custom">
                                                <li>
                                                    <a class="dropdown-item" href="/Pets/Detail/${data.id}">
                                                        <img src="/icons/see-detail.svg" alt="Detalle" width="16" height="16"> Ver Detalle
                                                    </a>
                                                </li>
                                                <li>
                                                    <a class="dropdown-item" href="/Pets/Edit/${data.id}">
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
            showFeedbackModal({ title: '¡Error!', message: 'No se pudieron cargar las mascotas.', type: 'danger' });
        }
    });
}

// Función para eliminar una mascota
function Delete(id) {
    handleCrudDelete({
        id: id,
        url: '/Pets/Delete',
        modalTitle: '¿Confirmas que deseas eliminar este registro de mascota?',
        modalMessage: 'Esta acción es permanente y no se puede deshacer.',
        onSuccess: loadPets
    });
}