using Models;
using System.Linq.Expressions;

namespace Data
{
    public interface IMongoRepository<TDocument> where TDocument : IDatabaseObject
    {
        IQueryable<TDocument> AsQueryable();

        IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression);

        IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression);

        TDocument FindById(string id);

        Task InsertOneAsync(TDocument document);

        Task DeleteByIdAsync(string id);

    }
}
