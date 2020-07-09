using JESUS_ESTEVEZ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JESUS_ESTEVEZ.Services
{
    public class DBService
    {

        private readonly ApplicationDBContext DB;

        public DBService(ApplicationDBContext _DB)
        {
            DB = _DB;
        }

        public async Task<List<Departamento>> GetDepartments()
        {
            var departamentos = await DB.Departamentos.ToListAsync();
            return departamentos;
        }

        public bool AddUser(Usuario user)
        {
            try
            {
                DB.Usuarios.Add(user);
                DB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
