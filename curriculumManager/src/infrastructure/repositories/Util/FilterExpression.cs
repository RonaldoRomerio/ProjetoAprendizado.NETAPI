using System.Linq.Expressions;
using System.Reflection;
using curriculumManager.src.application.interfaces;
using curriculumManager.src.infrastructure.database.config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace curriculumManager.src.infrastructure.repositories.Util
{
    public class FilterExpression<TEntity> where TEntity : class
    {
        public Expression<Func<TEntity, bool>> createFilterExpressiona(IFilter filter)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, filter.NameProperty);
            var Value = Expression.Constant(filter.Value, property.Type);
            var MethodInfo = typeof(Expression).GetMethod(filter.FilterOperator.ToString(), [typeof(Expression), typeof(Expression)]);
            
            if (MethodInfo == null) return null;

            var BooleanExpression = (BinaryExpression?)MethodInfo.Invoke(null, new object[] { property, Value });


            return Expression.Lambda<Func<TEntity, bool>>(BooleanExpression, parameter);
        }
        public List<Expression<Func<TEntity, bool>>> ListToExpression(List<IFilter> filters)
        {
            List<Expression<Func<TEntity, bool>>> filterExpresssionCompleted = new List<Expression<Func<TEntity, bool>>>();

            foreach (IFilter filter in filters)
            {
                filterExpresssionCompleted.Add(createFilterExpressiona(filter));
            }
            return filterExpresssionCompleted;
        }
        public IQueryable<TEntity> insertWhereConditional(IQueryable<TEntity> query, List<IFilter> filters)
        {
            var WhereExpression = ListToExpression(filters);
            foreach(var expression in WhereExpression){
                query = query.Where(expression);
            }
            return query;
        }
    }
}
