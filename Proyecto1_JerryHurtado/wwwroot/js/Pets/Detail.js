$(function () {
    const subheader = createSubheader({
        title: 'Detalle',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Mascotas', url: '/Pets' },
            'Detalle de la mascota'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});