using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Globalization;
using DataTransfer.Properties.Resources;

namespace DataTransfer.Core
{
    public static class Extensions
    {
        public static string PureText(this string text)
        {
            Check.NotNullOrWhiteSpace(() => text);

            StringBuilder pureText = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    pureText.Append(letter);
            }

            return pureText.ToString();
        }

        public static string GetMemberName<T>(
            this T instance,
            Expression<Func<T, object>> expression
        )
        {
            return GetMemberName(expression);
        }

        public static string GetMemberName<T>(
            Expression<Func<T, object>> expression
        )
        {
            ValidateParameter(expression, "expression");

            return GetMemberName(expression.Body);
        }

        public static string GetMemberName<T>(
            this T instance,
            Expression<Action<T>> expression
        )
        {
            return GetMemberName(expression);
        }

        public static string GetMemberName<T>(
            Expression<Action<T>> expression
        )
        {
            ValidateParameter(expression, "expression");

            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(
            Expression expression
        )
        {
            ValidateParameter(expression, "expression");

            if (expression is MemberExpression)
            {
                // Reference type property or field
                var memberExpression =
                    (MemberExpression)expression;
                return memberExpression.Member.Name;
            }

            if (expression is MethodCallExpression)
            {
                // Reference type method
                var methodCallExpression =
                    (MethodCallExpression)expression;
                return methodCallExpression.Method.Name;
            }

            if (expression is UnaryExpression)
            {
                // Property, field of method returning value type
                var unaryExpression = (UnaryExpression)expression;
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException("Invalid expression");
        }

        private static string GetMemberName(
            UnaryExpression unaryExpression
        )
        {
            if (unaryExpression.Operand is MethodCallExpression)
            {
                var methodExpression =
                    (MethodCallExpression)unaryExpression.Operand;
                return methodExpression.Method.Name;
            }

            return ((MemberExpression)unaryExpression.Operand)
                .Member.Name;
        }


        //Other reference
        public static string GetMemberName<T>(
            this T instance,
            Expression<Func<T>> expression
        )
        {
            ValidateParameter(expression, "expression");

            MemberExpression expressionBody = (MemberExpression)expression.Body;
            return expressionBody.Member.Name;
        }

        public static string GetMemberName<T>(
            this Expression<Func<T>> expression
        )
        {
            ValidateParameter(expression, "expression");

            MemberExpression expressionBody = (MemberExpression)expression.Body;
            return expressionBody.Member.Name;
        }

        public static T GetMemberValue<T>(
            this Expression<Func<T>> expression
        )
        {
            ValidateParameter(expression, expression.GetMemberName());

            var compiled = expression.Compile();
            return compiled();
        }

        private static void ValidateParameter(object obj, string paramName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(Strings.ArgumentNullExceptionMessage(paramName));
            }
        }
    }
}