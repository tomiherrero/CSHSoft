using CSHFSoft.AccesoDatos.Data.Repository;
using CSHSoft.AccesoDatos.Data;
using CSHSoft.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSHFSoft.AccesoDatos.Data
{
   public class AuditoriaRepository : Repository<Auditoria>, IAuditoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public AuditoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
