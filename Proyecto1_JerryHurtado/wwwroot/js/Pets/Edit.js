// Inicializa el subheader al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Actualizar Mascota',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Mascotas', url: '/Pets/Index' },
            'Actualizar mascota'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón de actualizar
$("#btn-update").on("click", function (e) {
    e.preventDefault();
    handleCrudSubmit({
        formSelector: "#formEditPet",
        url: "/Pets/Edit",
        redirectRoute: "/Pets/Index",
        buttonSelector: "#btn-update"
    });
});