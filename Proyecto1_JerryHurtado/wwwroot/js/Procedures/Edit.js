// Inicializa el subheader al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Actualizar Procedimiento',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Procedimientos', url: '/Procedures/Index' },
            'Actualizar procedimiento'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón de actualizar
$("#btn-update").on("click", function (e) {
    e.preventDefault();
    handleCrudSubmit({
        formSelector: "#formEditProcedure",
        url: "/Procedures/Edit",
        redirectRoute: "/Procedures/Index",
        buttonSelector: "#btn-update"
    });
});