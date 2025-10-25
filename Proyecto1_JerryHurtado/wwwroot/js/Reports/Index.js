// Inicilialización del subheader
$(function () {
    const subheader = createSubheader({
        title: 'Reportes',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            'Reportes'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
    loadPets();
});