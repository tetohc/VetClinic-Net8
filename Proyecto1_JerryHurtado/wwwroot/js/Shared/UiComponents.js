// Modal para confirmar eliminacion
function showDeleteModal({ title, message, onConfirm }) {
    $('#confirmDeleteLabel').text(title || '¿Estás seguro?');
    $('#confirmDeleteText').text(message || 'Este cambio no se puede deshacer.');

    const modal = new bootstrap.Modal(document.getElementById('confirmDeleteModal'));
    modal.show();

    $('#confirmDeleteBtn').off('click').on('click', function () {
        modal.hide();
        if (typeof onConfirm === 'function') {
            onConfirm();
        }
    });
}

// Modal para mostrar mensajes de exito o error
function showFeedbackModal({ title = "", message = "", type = "", onClose = null }) {
    const modalHtml = `
        <div class="modal fade" id="feedbackModal" tabindex="-1">
          <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content border-${type}">
              <div class="modal-header bg-${type} text-white">
                <h5 class="modal-title">${title}</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
              </div>
              <div class="modal-body">
                <p>${message}</p>
              </div>
            </div>
          </div>
        </div>
    `;
    $('body').append(modalHtml);
    const modal = new bootstrap.Modal(document.getElementById('feedbackModal'));
    modal.show();

    $('#feedbackModal').on('hidden.bs.modal', function () {
        $('#feedbackModal').remove();
        if (typeof onClose === 'function') onClose();
    });
}

// Componente subheader reutilizable
function createSubheader({ title, breadcrumbItems, buttonText, buttonAction, buttonTooltip, showSearchButton = false }) {
    if (!Array.isArray(breadcrumbItems) || breadcrumbItems.length < 2 || breadcrumbItems.length > 3) {
        throw new Error('breadcrumbItems debe tener entre 2 y 3 elementos.');
    }

    const container = document.createElement('div');
    container.className = 'subheader py-6 py-lg-8 subheader-transparent container-header gutter-b';

    const breadcrumbHTML = breadcrumbItems.map((item, index) => {
        const isLast = index === breadcrumbItems.length - 1;

        if (isLast && typeof item === 'string') {
            return `<li class="breadcrumb-item active" aria-current="page">${item}</li>`;
        }

        if (typeof item === 'object' && item.label && item.url) {
            return `<li class="breadcrumb-item"><a href="${item.url}" class="text-decoration-none breadcrumb-link">${item.label}</a></li>`;
        }

        throw new Error(`breadcrumbItems[${index}] debe ser un objeto con label y url, o un string si es el último.`);
    }).join('');

    const buttons = [];

    if (showSearchButton) {
        buttons.push(`
            <a class="btn btn-secondary d-flex align-items-center gap-2" data-bs-toggle="tooltip" data-bs-placement="top" title="Buscar en todos los registros" href="/Search/Index">
                <img src="/icons/search-black.svg" alt="Search icon" width="16" height="16"> Búsqueda avanzada
            </a>
        `);
    }

    if (buttonText && buttonAction && buttonTooltip) {
        buttons.push(`
            <a class="btn btn-primary d-flex align-items-center gap-2" data-bs-toggle="tooltip" data-bs-placement="top" title="${buttonTooltip}" href="${buttonAction}">
                <img src="/icons/plus-circle.svg" alt="Add icon" width="16" height="16"> ${buttonText}
            </a>
        `);
    }

    const buttonHTML = buttons.length > 0
        ? `<div class="d-flex justify-content-end gap-2 mb-2">${buttons.join('')}</div>`
        : '';

    container.innerHTML = `
        <div class="container d-flex align-items-center justify-content-between flex-wrap flex-sm-nowrap">
            <div class="d-flex align-items-center flex-wrap me-1">
                <div class="d-flex align-items-baseline flex-wrap me-5 font-monospace fs-5">
                    <h2 class="my-1 me-5 text-primary">${title}</h2>
                    <nav style="--bs-breadcrumb-divider: '>';" aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            ${breadcrumbHTML}
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
        ${buttonHTML}
    `;

    return container;
}


// Redirecciona a una ruta especifica
function redirectTo({ route = "" }) {
    window.location.href = route;
}

// Mascara para campo de cedula
$(function () {
    document.querySelectorAll('input[data-mask="IDcard"]').forEach(input => {
        input.addEventListener('input', function (e) {
            let value = e.target.value.replace(/\D/g, '');

            if (value.length > 1) {
                value = value.slice(0, 1) + '-' + value.slice(1);
            }
            if (value.length > 6) {
                value = value.slice(0, 6) + '-' + value.slice(6);
            }

            value = value.slice(0, 11);
            e.target.value = value;

            input.addEventListener('blur', function (e) {
                const regex = /^\d{1}-\d{4}-\d{4}$/;
                if (!regex.test(e.target.value)) {
                    e.target.classList.add('is-invalid');
                } else {
                    e.target.classList.remove('is-invalid');
                }
            });
        });
    });
});

// Mascara para campo de numero telefonico
$(function () {
    document.querySelectorAll('input[data-mask="phoneNumber"]').forEach(input => {
        input.addEventListener('input', function (e) {
            let value = e.target.value.replace(/\D/g, '');

            if (value.length > 4) {
                value = value.slice(0, 4) + '-' + value.slice(4);
            }

            value = value.slice(0, 9);
            e.target.value = value;
        });

        input.addEventListener('blur', function (e) {
            const regex = /^\d{4}-\d{4}$/;
            if (!regex.test(e.target.value)) {
                e.target.classList.add('is-invalid');
            } else {
                e.target.classList.remove('is-invalid');
            }
        });
    });
});