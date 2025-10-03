/**
 * Maneja el envío de formularios por medio de AJAX para operaciones CRUD tipo POST.
 * Desactiva el botón, muestra spinner, envía los datos y gestiona la respuesta con modales.
 *
 * @param {Object} config - Configuración del envío.
 * @param {string} config.formSelector - Selector del formulario a enviar.
 * @param {string} config.url - URL del endpoint que recibe los datos vía POST.
 * @param {string} config.redirectRoute - Ruta a la que se redirige tras éxito.
 * @param {string} config.buttonSelector - Selector del botón de envío que se desactiva y muestra spinner.
 */
function handleCrudSubmit({ formSelector, url, redirectRoute, buttonSelector }) {
    const $form = $(formSelector);
    const $btn = $(buttonSelector);

    if ($form.valid()) {
        $btn.prop("disabled", true);
        $btn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Guardando...');

        $.ajax({
            url: url,
            type: "POST",
            data: $form.serialize(),
        }).done(function (response) {
            if (response.result) {
                showFeedbackModal({
                    title: "¡Éxito!",
                    message: response.message,
                    type: "success",
                    onClose: () => redirectTo({ route: redirectRoute })
                });
            } else {
                showFeedbackModal({
                    title: "¡Algo salió mal!",
                    message: response.message,
                    type: "danger"
                });
            }
        }).fail(function () {
            showFeedbackModal({
                title: "¡Error!",
                message: "Ocurrió un error al procesar la solicitud.",
                type: "danger"
            });
        }).always(function () {
            $btn.prop("disabled", false);
            $btn.html('<img src="/icons/save.svg" alt="Save icon"> Guardar');
        });
    }
}

/**
 * Maneja una operación DELETE vía AJAX con confirmación previa en modal.
 *
 * @param {Object} config - Configuración de la operación.
 * @param {number|string} config.id - Identificador del recurso a eliminar.
 * @param {string} config.url - URL base del endpoint DELETE (sin el parámetro `id`).
 * @param {string} config.modalTitle - Título del modal de confirmación.
 * @param {string} config.modalMessage - Mensaje del modal de confirmación.
 * @param {function} [config.onSuccess] - Función que se ejecuta después de una eliminación exitosa y cerrar el modal de notificación.
 */
function handleCrudDelete({ id, url, modalTitle, modalMessage, onSuccess }) {
    showDeleteModal({
        title: modalTitle,
        message: modalMessage,
        onConfirm: function () {
            $.ajax({
                url: `${url}?id=${id}`,
                type: 'DELETE',
                success: function (response) {
                    if (response.result) {
                        showFeedbackModal({
                            title: "¡Eliminado!",
                            message: response.message,
                            type: "success",
                            onClose: onSuccess
                        });
                    } else {
                        showFeedbackModal({
                            title: "¡Algo salió mal!",
                            message: response.message,
                            type: "danger"
                        });
                    }
                },
                error: function () {
                    showFeedbackModal({
                        title: "¡Error!",
                        message: "Ocurrió un error al procesar la solicitud.",
                        type: "danger"
                    });
                }
            });
        }
    });
}

/**
 * Carga opciones en un dropdown vía AJAX.
 * @param {Object} config - Configuración de la carga.
 * @param {string} config.url - Ruta del controlador que devuelve los datos.
 * @param {string} config.target - Selector del dropdown que se va a llenar.
 * @param {string} config.defaultText - Texto por defecto en el primer <option>.
 * @param {string} [config.resetTarget] - Selector de otro dropdown que debe reiniciarse.
 */
function loadDropdownOptions({ url, target, defaultText, resetTarget }) {
    $.ajax({
        url: url,
        method: "GET",
        success: function (data) {
            const $target = $(target);
            $target.empty().append(`<option value="" disabled selected>${defaultText}</option>`);
            data.forEach(item => {
                $target.append(`<option value="${item.value}">${item.text}</option>`);
            });

            if (resetTarget) {
                $(resetTarget).empty().append('<option value="" disabled selected>Seleccione una opción</option>');
            }
        },
        error: function () {
            showFeedbackModal({
                title: "¡Error!",
                message: "Ocurrió un error al cargar los datos.",
                type: "danger"
            });
        }
    });
}