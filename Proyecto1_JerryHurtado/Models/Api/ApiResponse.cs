namespace Proyecto1_JerryHurtado.Models.Api
{
    /// <summary>
    /// Estructura estándar para respuestas HTTP de la API.
    /// </summary>
    /// <typeparam name="T">Tipo de dato devuelto en la propiedad Data.</typeparam>
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; } = default;
    }
}