using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureExamplesTest
{
    [TestClass]
    public class ExpressionTreeTest
    {
        [TestMethod]
        public void Should_Expression_Tree_1()
        {
            Expression<Func<int, int, int>> expression = (a, b) => a*b + 2;
            var compile = expression.Compile();
            var invoke = compile.Invoke(1, 2);
            Console.Out.WriteLine(invoke);
        }

        [TestMethod]
        public void Should_Expression_Tree_2()
        {
            var paraLeft = Expression.Parameter(typeof (int), "a");
            var paraRight = Expression.Parameter(typeof (int), "b");

            var binaryLeft = Expression.Multiply(paraLeft, paraRight);
            var conRight = Expression.Constant(2, typeof (int));

            var binaryBody = Expression.Add(binaryLeft, conRight);

            LambdaExpression lambda =
                Expression.Lambda<Func<int, int, int>>(binaryBody, paraLeft, paraRight);
            Console.WriteLine(lambda.ToString());
//            foreach (var parameter in lambda.Parameters)
//            {
//                Console.Out.WriteLine(parameter);
//            }

//            var compile = lambda.Compile();
//            var dynamicInvoke = compile.DynamicInvoke(1, 2);
//            Console.Out.WriteLine(dynamicInvoke);
        }

        [TestMethod]
        public void Should_Expression_Tree_3()
        {
            //companies.Where(company => (company.ToLower() == "coho winery" || company.Length > 16)).OrderBy(company => company)

            string[] companies = {
                                     "Consolidated Messenger", "Alpine Ski House", "Southridge Video",
                                     "City Power & Light",
                                     "Coho Winery", "Wide World Importers", "Graphic Design Institute",
                                     "Adventure Works",
                                     "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                                     "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                                     "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee"
                                 };

            // Compose the expression tree that represents the parameter to the predicate.
            ParameterExpression pe = Expression.Parameter(typeof (string), "company");

            // ***** Where(company => (company.ToLower() == "coho winery" || company.Length > 16)) *****
            // Create an expression tree that represents the expression 'company.ToLower() == "coho winery"'.
            Expression left = Expression.Call(pe, typeof (string).GetMethod("ToLower", Type.EmptyTypes));
            Expression right = Expression.Constant("coho winery");
            Expression e1 = Expression.Equal(left, right);

            // Create an expression tree that represents the expression 'company.Length > 16'.
            left = Expression.Property(pe, typeof (string).GetProperty("Length"));
            right = Expression.Constant(16, typeof (int));
            Expression e2 = Expression.GreaterThan(left, right);

            // Combine the expression trees to create an expression tree that represents the
            // expression '(company.ToLower() == "coho winery" || company.Length > 16)'.
            Expression predicateBody = Expression.OrElse(e1, e2);

            // The IQueryable data to query.
            IQueryable<String> queryableData = companies.AsQueryable();

            // Create an expression tree that represents the expression
            // 'queryableData.Where(company => (company.ToLower() == "coho winery" || company.Length > 16))'
            MethodCallExpression whereCallExpression = Expression.Call(
                typeof (Queryable),
                "Where",
                new Type[] {queryableData.ElementType},
                queryableData.Expression,
                Expression.Lambda<Func<string, bool>>(predicateBody, new ParameterExpression[] {pe}));
            // ***** End Where *****

            // ***** OrderBy(company => company) *****
            // Create an expression tree that represents the expression
            // 'whereCallExpression.OrderBy(company => company)'
            MethodCallExpression orderByCallExpression = Expression.Call(
                typeof (Queryable),
                "OrderBy",
                new Type[] {queryableData.ElementType, queryableData.ElementType},
                whereCallExpression,
                Expression.Lambda<Func<string, string>>(pe, new ParameterExpression[] {pe}));
            // ***** End OrderBy *****

            // Create an executable query from the expression tree.
            IQueryable<string> results = queryableData.Provider.CreateQuery<string>(orderByCallExpression);
            Console.Out.WriteLine(results.ToString());
            // Enumerate the results.
            foreach (string company in results)
                Console.WriteLine(company);

            /*  This code produces the following output:

                Blue Yonder Airlines
                City Power & Light
                Coho Winery
                Consolidated Messenger
                Graphic Design Institute
                Humongous Insurance
                Lucerne Publishing
                Northwind Traders
                The Phone Company
                Wide World Importers
            */
        }

        [TestMethod]
        public void Should_Expression_Tree_4()
        {
            var paraLeft = Expression.Constant(0, typeof (int));
            var paraRight = Expression.Parameter(typeof(int), "a");
            var expressionBody = Expression.Subtract(paraLeft, paraRight);

            LambdaExpression lambda =
                Expression.Lambda<Func<int, int>>(expressionBody, paraRight);
            Console.Out.WriteLine(lambda.ToString());
        }
    }
}