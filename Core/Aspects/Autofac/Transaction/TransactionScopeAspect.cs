using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
{
    /// <summary>
    /// Transection işleminin genelleştirilmiş AOP ile yapılmış hali.
    /// </summary>
    public class TransactionScopeAspect : MethodInterception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="invocation">Parametre olarak verilen metod Adı</param>
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
