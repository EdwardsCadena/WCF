using CoreWCFService.Core.Entities;
using CoreWCFService.Core.Interfaces;
using CoreWCFService.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.XEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWCFService.Infrastructure.Repositorie
{
    public class UsuarioRepository : IUsuarioRepository
    {
        
        private readonly WcfContext _context;

        public UsuarioRepository(WcfContext context)
        {
            _context = context;
        }
        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FromSqlRaw($"getUsuario @IdUsuario", id).FirstOrDefaultAsync();
        }

        public async Task AddUsuarioAsync(Usuario Usuario)
        {
            
            await _context.Usuarios.FromSqlRaw($"AddUsuario @nombre, @Fecha, @TipoSexo", Usuario.Nombre, Usuario.Fecha, Usuario.TipoSexo).LoadAsync();
        }

        public async Task UpdateUsuarioAsync(Usuario Usuario)
        {
            await _context.Usuarios.FromSqlRaw($"updateUsuario @nombre, @Fecha, @TipoSexo",
                                               Usuario.Nombre,
                                               Usuario.Fecha,
                                               Usuario.TipoSexo).LoadAsync();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            
            await _context.Usuarios.FromSqlRaw($"DeleteUsuario @IdUsuario", id).LoadAsync();

        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}
