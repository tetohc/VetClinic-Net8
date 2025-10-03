// Inicializa el subheader al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Actualizar Cliente',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Clientes', url: '/Customers/Index' },
            'Actualizar cliente'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón de actualizar
$("#btn-update").on("click", function (e) {
    e.preventDefault();
    handleCrudSubmit({
        formSelector: "#formEditCustomer",
        url: "/Customers/Edit",
        redirectRoute: "/Customers/Index",
        buttonSelector: "#btn-update"
    });
});

// Manejo del evento change de lo dropdowns para provincia - cargar cantones
$("#ProvinceId").on("change", function (e) {
    const provinceId = e.target.value;
    loadDropdownOptions({
        url: `/Locations/GetCantons?provinceId=${provinceId}`,
        target: "#CantonId",
        defaultText: "Seleccione un cantón",
        resetTarget: "#DistrictId"
    });
});

// Manejo del evento change del dropdown para cantón - cargar distritos
$("#CantonId").on("change", function (e) {
    const cantonId = e.target.value;
    loadDropdownOptions({
        url: `/Locations/GetDistricts?cantonId=${cantonId}`,
        target: "#DistrictId",
        defaultText: "Seleccione un distrito"
    });
});