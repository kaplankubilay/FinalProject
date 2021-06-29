﻿using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    /// <summary>
    /// "invocation" bizim business method larımızdır.
    /// </summary>
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            //metotlardan önce çalıştır.
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                //metot çalışırken hata alırken çalıştır.
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            //metottan sonra çalıştır.
            OnAfter(invocation);
        }
    }
}