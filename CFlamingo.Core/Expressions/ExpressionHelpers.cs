using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CFlamingo.Core
{
    /// <summary>
    /// Helper for Expression
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compile the expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">Type of return value</typeparam>
        /// <param name="lambda">Expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Set the underlying value to the given value, from an expresssion that contains property
        /// </summary>
        /// <typeparam name="T">Type of value to set</typeparam>
        /// <param name="lambda">The expression</param>
        /// <param name="value">Value to set to property</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //Comverts a lambda () => some.property to some.property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            //Get the property information as we set it
            var propertytInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            //Set the property value
            propertytInfo.SetValue(target, value);
        }
    }
}
