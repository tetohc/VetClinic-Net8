// Inicializa el subheader al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Nuevo Empleado',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Empleados', url: '/Employees' },
            'Nuevo empleado'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón de crear
$("#btn-create").on("click", function (e) {
    e.preventDefault();
    handleCrudSubmit({
        formSelector: "#formCreateEmployee",
        url: "/Employees/Create",
        redirectRoute: "/Employees/Index",
        buttonSelector: "#btn-create"
    });
});