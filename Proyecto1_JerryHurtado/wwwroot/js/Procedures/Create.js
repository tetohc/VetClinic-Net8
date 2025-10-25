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

// Manejo del evento change del dropdowns de mascotas - cargar mascotas
$("#CustomerId").on("change", function (e) {
    const customerId = e.target.value;
    loadDropdownOptions({
        url: `/Pets/GetPetByCustomer?customerId=${customerId}`,
        target: "#PetId",
        defaultText: "Seleccione una mascota",
    });
});