// Inicializa el subheader al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Nuevo Procedimiento',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Procedimientos', url: '/Procedures' },
            'Nuevo procedimiento'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón de crear
$("#btn-create").on("click", function (e) {
    e.preventDefault();
    handleCrudSubmit({
        formSelector: "#formCreateProcedure",
        url: "/Procedures/Create",
        redirectRoute: "/Procedures/Index",
        buttonSelector: "#btn-create"
    });
});