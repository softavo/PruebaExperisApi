namespace Entrevistas.BusinessLogic
{
    using Microsoft.EntityFrameworkCore;
    using Entrevistas.BusinessLogic.Interfaces;
    using Entrevistas.DataAccess.Contexts;
    using Entrevistas.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EntrevistaCrud : IEntrevistaCrud
    {
        private readonly ApplicationDbContext _context;

        public EntrevistaCrud(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entrevista>> GetEntrevistas()
        {
            var entrevistas = await _context.Entrevistas.ToListAsync();

            return entrevistas;
        }

    }
}
