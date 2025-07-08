using bca.api.Data.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NPOI.SS.Formula.Functions;
using System.Linq.Expressions;

namespace bca.api.Infrastructure.IRepository
{
    public interface IHomeMasterRepository : IGenericRepository<HomeMaster>
    {
        Task<HomeMaster?> GetFullHomePageAsync(int id);
       
    }
}
