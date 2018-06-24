using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Resources;
using DataTransfer.Properties.Resources;
using System.Configuration;

namespace DataTransfer.Core
{
    public static class Check
    {
        public static void NotNullOrWhiteSpace<T>(params Expression<Func<T>>[] expressions)
        {
            foreach (var expression in expressions)
            {
                var value = expression.GetMemberValue() as string;
                if (string.IsNullOrWhiteSpace(value))
                {
                    var paramName = expression.GetMemberName();
                    var message = Strings.ArgumentNullExceptionMessage(paramName);
                    throw new ArgumentNullException(paramName, message);
                }
            }
        }

        public static void NotNullOrEmpty<T>(params Expression<Func<T>>[] expressions)
        {
            foreach (var expression in expressions)
	        {
                var value = expression.GetMemberValue() as string;
                if (string.IsNullOrEmpty(value))
                {
                    var paramName = expression.GetMemberName();
                    var message = Strings.ArgumentNullExceptionMessage(paramName);
                    throw new ArgumentNullException(paramName, message);
                }
            }
        }

        public static void NotNull<T>(params Expression<Func<T>>[] expressions)
        {
            foreach (var expression in expressions)
	        {
                var value = expression.GetMemberValue();
                if (value == null)
                {
                    var paramName = expression.GetMemberName();
                    var message = Strings.ArgumentNullExceptionMessage(paramName);
                    throw new ArgumentNullException(paramName, message);
                }
            }
        }

        public static void NotExtension<T>(params Expression<Func<T>>[] expressions)
        {
            foreach (var expression in expressions)
            {
                var value = expression.GetMemberValue();
                if (value == null)
                {
                    var paramName = expression.GetMemberName();
                    var message = Strings.ArgumentNullExceptionMessage(paramName);
                    throw new InvalidOperationException(message);
                }
            }
        }
    }
}