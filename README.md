# 🧩 Proyecto Académico – Arquitectura MVC Extendida

Este repositorio contiene el desarrollo de una aplicación web académica construida con .NET 8 y C# 12, siguiendo el patrón MVC extendido. El proyecto implementa una arquitectura modular, segura y escalable, respetando las restricciones impuestas en la Fase 1 del curso *Fundamentos de Programación Web*.

---

## 🧱 Arquitectura

La aplicación está basada en el patrón MVC, extendido con capas adicionales para mejorar la claridad, seguridad y mantenibilidad:

- **ViewModels**: usados exclusivamente en la vista y el controlador para validar y presentar datos.
- **Entities (Modelo del dominio)**: encapsulados dentro de los Managers, representan la lógica del sistema y simulan la base de datos.
- **Managers**: manejan la lógica de negocio y el acceso a datos simulados (listas internas).
- **Helpers**: encapsulan lógica transversal como navegación, carga de ubicaciones y acciones CRUD genéricas.
- **Mapper**: transforma datos entre ViewModels y Entities, filtrando propiedades sensibles y adaptando estructuras.

---

## 🎯 Objetivos del proyecto

- Aplicar principios de **SOLID** y **Arquitectura Limpia**.
- Separar responsabilidades para facilitar la escalabilidad.
- Evitar exposición directa de entidades en la vista.
- Simular una base de datos mediante listas internas encapsuladas.
- Implementar una interfaz accesible, responsiva y dinámica usando Razor, Bootstrap 5.1, CSS3, JS (AJAX) y jQuery.

---

## 🚫 Limitaciones impuestas en la Fase 1

Este proyecto respeta las restricciones definidas por el curso en su primera fase:

- ❌ **No se permite el uso de bases de datos reales**: toda la persistencia se simula mediante listas internas.
- ❌ **No se permite el uso de librerías externas o plugins**: toda la lógica JS es escrita manualmente, sin frameworks ni dependencias.
- ❌ **No se permite el uso de componentes de terceros**: todos los íconos, estilos y scripts son internos y personalizados.
- ❌ **No se permite el uso de APIs externas**: toda la lógica de negocio y datos está contenida dentro del proyecto.
- ❌ **No se permite el uso de Entity Framework ni LINQ avanzado**: el acceso a datos es directo y controlado por los Managers.
- ✅ **Bootstrap es una excepción permitida**: se utiliza la versión 5.1 incluida por defecto en el entorno Razor Pages.

---

## 🖼️ Material visual

A continuación se presentan capturas de pantalla que ilustran la arquitectura y el funcionamiento de la aplicación desde la perspectiva del usuario:

---

### 📌 Mapa conceptual – Arquitectura MVC Extendida

Representa la estructura del sistema, incluyendo ViewModels, Entities, Managers, Helpers, Mapper, y su interacción dentro del patrón MVC.

![Mapa Conceptual](https://raw.githubusercontent.com/tetohc/MediaResources/refs/heads/main/images/covers/VetClinic/diagram-architecture-mvc.png)

---

### 🖼️ Vista principal de la aplicación

Pantalla inicial con navegación accesible, diseño responsivo y estructura clara. Construida con Razor y Bootstrap 5.1.

![Vista principal](https://raw.githubusercontent.com/tetohc/MediaResources/refs/heads/main/images/covers/VetClinic/home.png)

---

### 🖼️ Gestión de procedimientos

Ejemplo de vista de gestión con tabla de registros, acciones CRUD integradas (editar, eliminar) y diseño modular.

![Gestión de procedimientos](https://raw.githubusercontent.com/tetohc/MediaResources/refs/heads/main/images/covers/VetClinic/table.png)

---

### 🖼️ Vista de búsqueda

Formulario con campos de texto y dropdowns, con interacción dinámica mediante AJAX.

![Vista de búsqueda](https://raw.githubusercontent.com/tetohc/MediaResources/refs/heads/main/images/covers/VetClinic/search.png)

---

### 🖼️ Validación en tiempo real

Mensajes de error mostrados al enviar un formulario incompleto, utilizando `asp-validation-for`, `ValidationSummary` y atributos `[Required]` en el ViewModel.

![Validación](https://raw.githubusercontent.com/tetohc/MediaResources/refs/heads/main/images/covers/VetClinic/validations.png)

---

### 🖼️ Vista de detalle de procedimiento

Pantalla que muestra la información completa de un procedimiento seleccionado, con diseño limpio y uso de íconos SVG personalizados.

![Detalle de procedimiento](https://raw.githubusercontent.com/tetohc/MediaResources/refs/heads/main/images/covers/VetClinic/detail.png)


