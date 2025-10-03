$(function () {
    const subheader = createSubheader({
        title: 'Detalle',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            { label: 'Empleados', url: '/Employees' },
            'Detalle de empleado'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});