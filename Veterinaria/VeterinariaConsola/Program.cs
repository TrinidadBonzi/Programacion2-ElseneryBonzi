using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpClientSample
{
    public class Duenio
    {
        public int idDuenio { get; set; }
        public string dniDuenio { get; set; }
        public string nombreDuenio { get; set; }
        public string apellidoDuenio { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowDuenio(Duenio duenio)
        {
            Console.WriteLine($"ID: {duenio.idDuenio}\tDNI: {duenio.dniDuenio}\tNombre: {duenio.nombreDuenio}\tApellido: {duenio.apellidoDuenio}");
        }

        static async Task<Uri> CreateDuenioAsync(Duenio duenio)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/duenios", duenio);
            response.EnsureSuccessStatusCode();

            // Devuelve la URI del recurso creado.
            return response.Headers.Location;
        }

        static async Task<Duenio> GetDuenioAsync(string path)
        {
            Duenio duenio = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                duenio = await response.Content.ReadAsAsync<Duenio>();
            }
            return duenio;
        }

        static async Task<Duenio> UpdateDuenioAsync(Duenio duenio)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/duenios/{duenio.idDuenio}", duenio);
            response.EnsureSuccessStatusCode();

            duenio = await response.Content.ReadAsAsync<Duenio>();
            return duenio;
        }

        static async Task<HttpStatusCode> DeleteDuenioAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/duenios/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:5083/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Crear un nuevo dueño
                Duenio duenio = new Duenio
                {
                    dniDuenio = "12345678",
                    nombreDuenio = "Carlos",
                    apellidoDuenio = "Pérez"
                };

                var url = await CreateDuenioAsync(duenio);
                Console.WriteLine($"Dueño creado en {url}");

                // Obtener el dueño
                duenio = await GetDuenioAsync(url.PathAndQuery);
                if (duenio != null)
                {
                    ShowDuenio(duenio);
                }
                else
                {
                    Console.WriteLine("No se pudo obtener el dueño.");
                    return;
                }

                // Actualizar el dueño
                Console.WriteLine("Actualizando apellido...");
                duenio.apellidoDuenio = "Gómez";
                await UpdateDuenioAsync(duenio);

                // Obtener el dueño actualizado
                duenio = await GetDuenioAsync(url.PathAndQuery);
                if (duenio != null)
                {
                    ShowDuenio(duenio);
                }
                else
                {
                    Console.WriteLine("No se pudo obtener el dueño actualizado.");
                    return;
                }

                // Eliminar el dueño
                var statusCode = await DeleteDuenioAsync(duenio.idDuenio);
                Console.WriteLine($"Dueño eliminado (HTTP Status = {(int)statusCode})");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ocurrió un error: {e.Message}");
            }

            Console.ReadLine();
        }
    }
}
