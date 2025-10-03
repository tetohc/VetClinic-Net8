$(function () {
    const subheader = createSubheader({
        title: 'Veterinaria',
        breadcrumbItems: [
            { label: 'Inicio', url: '/Home/Index' },
            'Inicio'
        ]
    });
    document.querySelector('#subheader-container').appendChild(subheader);
});