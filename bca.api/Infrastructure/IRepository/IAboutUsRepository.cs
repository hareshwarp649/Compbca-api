using bca.api.Data.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NPOI.SS.Formula.Functions;
using System.Linq.Expressions;

namespace bca.api.Infrastructure.IRepository
{
    public interface IAboutUsRepository : IGenericRepository<AboutUs>
    {
        Task<AboutUs?> GetAboutUsPageAsync(int id);
       
    }
}
