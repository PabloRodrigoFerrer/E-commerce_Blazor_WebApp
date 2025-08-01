using Entity;
using Entity.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UserService
    {

        public User? ActiveUser { get; private set; } = new();

        private readonly IRepositoryUser<User> _repositoryUser;
        public UserService(IRepositoryUser<User> repository)
        {
            _repositoryUser = repository;
        }

        public async Task<User?> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return null;

            var user = await _repositoryUser.Login(username, password);

            ActiveUser = user?.Id > 0 ? user : null;

            return ActiveUser;
        }


        public void Logout() 
        {
            ActiveUser = null;
        }

        public async Task<User?> RegistrarUserAsyc(string email, string pass) 
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass)) return null;

            var newUser = await _repositoryUser.CreateUserAsync(email.ToLower(), pass);

            if (newUser == null) return null;

            ActiveUser = newUser;

            return ActiveUser;
        }

        public async Task<User> GetActiveUserAsync()
        {
            // simulación de espera si consultás algo externo
            await Task.Delay(5);
            return ActiveUser;
        }
        public async Task Actualizar(User user) 
        {
            var usuario = _repositoryUser.GetByIdAsync(user.Id);
            
            if (usuario == null) return;

            await _repositoryUser.EditAsync(user);
        }

        public async Task<string> GuardarImagenAsync(IBrowserFile archivo, int idUsuario, string webRootPath)
        {
            // Validar que sea una imagen
            if (!archivo.ContentType.StartsWith("image/"))
                throw new InvalidOperationException("El archivo no es una imagen válida.");

            // Crear nombre único
            var nombreArchivo = $"{Guid.NewGuid()}_{archivo.Name}";

            // Carpeta del usuario: wwwroot/images/{IDUSUARIO}
            var rutaCarpeta = Path.Combine(webRootPath, "images", idUsuario.ToString());


            if (Directory.Exists(rutaCarpeta)) 
            {
                var archivos = Directory.GetFiles(rutaCarpeta);
                foreach (var item in archivos)
                {
                    File.Delete(item);
                }
            }


            // Crear carpeta si no existe
            if (!Directory.Exists(rutaCarpeta))
                Directory.CreateDirectory(rutaCarpeta);
                

            // Ruta física completa del archivo
            var rutaFisica = Path.Combine(rutaCarpeta, nombreArchivo);
            
            // Guardar archivo
            using var stream = File.Create(rutaFisica);
            await archivo.OpenReadStream(maxAllowedSize: 10 * 1024 * 1024).CopyToAsync(stream);

            // Ruta relativa para el navegador (para <img str= "...">)
            var rutaRelativa = $"images/{idUsuario}/{nombreArchivo}";

            return rutaRelativa;
        }

        
    }
}
