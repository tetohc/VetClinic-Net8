$(function () {
    const subheader = createSubheader({
        title: 'Detalle',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Clientes', url: '/Customers' },
            'Detalle del cliente'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});