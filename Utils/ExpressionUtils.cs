using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace EBoxClient.Utils
{
    public class ExpressionUtils
    {
        public static string GetPropertyName(Expression<Func<object>> propertyexpression)
        {
            var expression = propertyexpression.Body as System.Linq.Expressions.MemberExpression;
            return expression.Member.Name;
        }
        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyexpression)
        {
            var expression = propertyexpression.Body as MemberExpression;
            if (expression==null 
                &&propertyexpression.Body is UnaryExpression 
                && propertyexpression.Body.NodeType == ExpressionType.Convert)
            {
               var  exp = propertyexpression.Body as UnaryExpression;
               return (exp.Operand as MemberExpression).Member.Name;
            }
            return expression.Member.Name;
        }
    }
}
