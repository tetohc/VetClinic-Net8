// Inicializar el subheader al cargar la página
$(function () {
    const subheader = createSubheader({
        title: 'Nueva Mascota',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Mascotas', url: '/Pets' },
            'Nueva mascota'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});

// Manejo del evento click del botón de crear
$("#btn-create").on("click", function (e) {
    e.preventDefault();
    handleCrudSubmit({
        formSelector: "#formCreatePet",
        url: "/Pets/Create",
        redirectRoute: "/Pets/Index",
        buttonSelector: "#btn-create"
    });
});