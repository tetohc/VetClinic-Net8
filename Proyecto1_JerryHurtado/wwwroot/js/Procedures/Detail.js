$(function () {
    const subheader = createSubheader({
        title: 'Detalle',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Procedimientos', url: '/Procedures' },
            'Detalle del procedimiento'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});