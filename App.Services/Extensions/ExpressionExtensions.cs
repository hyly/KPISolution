using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Extensions
{
    /// <summary>
    /// A class which contains extension methods for <see cref="Expression"/> and <see cref="Expression{TDelegate}"/> instances.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Remaps all property access from type <typeparamref name="TSource"/> to <typeparamref name="TDestination"/> in <paramref name="expression"/>.
        /// </summary>
        /// <typeparam name="TSource">The type of the source element.</typeparam>
        /// <typeparam name="TDestination">The type of the destination element.</typeparam>
        /// <typeparam name="TResult">The type of the result from the lambda expression.</typeparam>
        /// <param name="expression">The <see cref="Expression{TDelegate}"/> to remap the property access in.</param>
        /// <returns>An <see cref="Expression{TDelegate}"/> equivalent to <paramref name="expression"/>, but applying to elements of type <typeparamref name="TDestination"/> instead of <typeparamref name="TSource"/>.</returns>
        public static Expression<Func<TDestination, TResult>> RemapForType<TSource, TDestination, TResult>(this Expression<Func<TSource, TResult>> expression)
        {

            var newParameter = Expression.Parameter(typeof(TDestination));

            var visitor = new AutoMapVisitor<TSource, TDestination>(newParameter);
            var remappedBody = visitor.Visit(expression.Body);
            if (remappedBody == null)
                throw new InvalidOperationException("Unable to remap expression");
            return Expression.Lambda<Func<TDestination, TResult>>(remappedBody, newParameter);
        }
    }
    /// <summary>
    /// An <see cref="ExpressionVisitor"/> implementation which uses <see href="http://automapper.org">AutoMapper</see> to remap property access from elements of type <typeparamref name="TSource"/> to elements of type <typeparamref name="TDestination"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the source element.</typeparam>
    /// <typeparam name="TDestination">The type of the destination element.</typeparam>
    public class AutoMapVisitor<TSource, TDestination> : ExpressionVisitor
    {
        private readonly ParameterExpression _newParameter;
        private readonly TypeMap _typeMap = Mapper.FindTypeMapFor<TSource, TDestination>();

        /// <summary>
        /// Initialises a new instance of the <see cref="AutoMapVisitor{TSource, TDestination}"/> class.
        /// </summary>
        /// <param name="newParameter">The new <see cref="ParameterExpression"/> to access.</param>
        public AutoMapVisitor(ParameterExpression newParameter)
        {

            _newParameter = newParameter;
        }

        /// <summary>
        /// Visits the children of the <see cref="T:System.Linq.Expressions.MemberExpression"/>.
        /// </summary>
        /// <returns>
        /// The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.
        /// </returns>
        /// <param name="node">The expression to visit.</param>
        protected override Expression VisitMember(MemberExpression node)
        {
            var propertyMaps = _typeMap.GetPropertyMaps();

            // Find any mapping for this member
            var propertyMap = propertyMaps.SingleOrDefault(map => map.SourceMember == node.Member);
            if (propertyMap == null)
                return base.VisitMember(node);

            var destinationProperty = propertyMap.DestinationProperty;

            var destinationMember = destinationProperty.MemberInfo;


            // Check the new member is a property too
            var property = destinationMember as PropertyInfo;
            if (property == null)
                return base.VisitMember(node);

            // Access the new property
            var newPropertyAccess = Expression.Property(_newParameter, property);
            return base.VisitMember(newPropertyAccess);
        }
    }
}
