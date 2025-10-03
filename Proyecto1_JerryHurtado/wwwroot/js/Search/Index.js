$(function () {
    const subheader = createSubheader({
        title: 'Búsqueda',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            'Búsqueda general'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón buscar
$("#btn-search").on("click", function (e) {
    e.preventDefault();
    const resultsContainer = $('#searchResults');
    const $btn = $(this);

    if ($("#formSearch").valid()) {
        $btn.prop("disabled", true);
        $btn.html('<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Buscando...');

        $.ajax({
            url: "/Search/Filter",
            type: "GET",
            data: $("#formSearch").serialize(),
        }).done(function (response) {
            resultsContainer.empty();

            if (response.data.length === 0) {
                resultsContainer.html(`
                        <div class="alert alert-warning w-100 text-center">No se encontraron resultados para la búsqueda.</div>
                    `);
                return;
            }

            response.data.forEach(item => {
                const card = `
                                <div class="col">
                                    <div class="card h-100 shadow-sm">
                                        <div class="d-flex justify-content-center align-items-center" style="height: 180px; background-color: var(--color-primary); overflow: hidden;">
                                            <img src="${item.imageUrl}" alt="${item.type} image" style="max-height: 100%; max-width: 100%; object-fit: cover;">
                                        </div>

                                        <div class="card-body">
                                            <h5 class="card-title d-flex justify-content-between align-items-center">
                                                ${item.title}
                                                <span class="badge" style="background-color: #6874ee;">${item.description1}</span>
                                            </h5>
                                            <p class="card-text">
                                                ${item.description2}
                                            </p>

                                            <div class="d-flex justify-content-between align-items-center mt-3">
                                                <div>
                                                    <span class="badge rounded-pill border border-primary text-primary">${item.type}</span>
                                                </div>
                                                <a href="${item.detailUrl}" class="btn btn-primary btn-sm">
                                                    Ver detalle
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            `;

                resultsContainer.append(card);
            });
        }).fail(function () {
            showFeedbackModal({
                title: "¡Error!",
                message: "Ocurrió un error al procesar la solicitud.",
                type: "danger"
            });
        }).always(function () {
            $btn.prop("disabled", false);
            $btn.html('<img src="/icons/search.svg" alt="Search icon"> Buscar');
        });
    }
});

const inputSearch = $("#Query");
const formContainer = $("#formSearch .card-body");

// Diccionario de placeholders por tipo
// Cliente=1, Empleado=2, Mascota=3, Procedimiento=4
const placeholders = {
    "1": "Nombre, cédula y provincia",  
    "2": "Cédula y tipo de empleado",       
    "3": "Especie, raza y color",          
    "4": "Nombre de mascota y estado (En proceso, Facturado, Agendado)" 
};

// Manejo del evento change del dropdown EntityType
// Para cambiar el placeholder del input de búsqueda
$("#EntityType").on("change", function () {
    const selected = $(this).val();
    inputSearch.val(""); 
    inputSearch.attr("placeholder", placeholders[selected] || "Escriba el término de búsqueda...");
});