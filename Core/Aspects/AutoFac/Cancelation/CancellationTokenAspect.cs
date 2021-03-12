using Castle.DynamicProxy;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Interceptors;

namespace Core.Aspects.AutoFac.Cancelation
{
    public class CancellationTokenAspect : MethotInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            var token = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>().HttpContext.RequestAborted;
            Task.Run(() =>
            {
                invocation.Proceed();
            }, token).Wait(token);
        }
    }
}
