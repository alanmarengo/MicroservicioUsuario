using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_USUARIO
{
    public class baseTEST_AUTH
    {
        Context db = null;
        protected Context ConstruirContexto()
        {
            if (db == null)
            {
                var opciones = new DbContextOptionsBuilder<Context>().UseSqlServer("Server=DESKTOP-NBSBBH9;Database=DatabaseUsers;Trusted_Connection=true;",
                options => { }).Options;
                db = new Context(opciones);
                return db;
            }
            return db;
        }
    }
}
