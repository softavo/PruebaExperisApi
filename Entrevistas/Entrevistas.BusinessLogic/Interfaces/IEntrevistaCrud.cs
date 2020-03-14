namespace Entrevistas.BusinessLogic.Interfaces
{
    using Entrevistas.DataAccess.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEntrevistaCrud
    {
        Task<IEnumerable<Entrevista>> GetEntrevistas();

    }
}
