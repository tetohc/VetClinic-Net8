// Inicialización del subheader al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Actualizar Empleado',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Empleados', url: '/Employees/Index' },
            'Actualizar empleado'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón de actualizar
$("#btn-update").on("click", function (e) {
    e.preventDefault();
    handleCrudSubmit({
        formSelector: "#formEditEmployee",
        url: "/Employees/Edit",
        redirectRoute: "/Employees/Index",
        buttonSelector: "#btn-update"
    });
});