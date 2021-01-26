/*-------------------------------------------------------------------------
 * 作者：WuTian
 * 版本号：v1.0
 * 本类主要用途描述及食用方式：
 * 实现动态lambda表达式
 *  -------------------------------------------------------------------------*/
using System;
using System.Linq.Expressions;

namespace EasyCore.Unity
{

    public static class ExpressionExtension
    {
        public static Expression<Func<TSource, bool>> And<TSource>(this Expression<Func<TSource, bool>> a, Expression<Func<TSource, bool>> b)
        {
            ParameterExpression replaceWith = Expression.Parameter(typeof(TSource), "root");
            return Expression.Lambda<Func<TSource, bool>>(Expression.And(ParameterExpressionReplacer.Replace(a.Body, replaceWith), ParameterExpressionReplacer.Replace(b.Body, replaceWith)), new ParameterExpression[] { replaceWith });
        }

    }

    public class ParameterExpressionReplacer : ExpressionVisitor
    {
        // Fields
        private readonly ParameterExpression replaceWith;
        private ParameterExpressionReplacer(ParameterExpression _replaceWith)
        {
            replaceWith = _replaceWith;
        }

        // Methods
        public static Expression Replace(Expression expression, ParameterExpression replaceWith) =>
            new ParameterExpressionReplacer(replaceWith).Visit(expression);

        protected override Expression VisitParameter(ParameterExpression node) =>
            replaceWith;

    }


}
