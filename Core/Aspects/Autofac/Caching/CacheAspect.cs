using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.IoC;
using System;
using Microsoft.Extensions.DependencyInjection;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;  
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);//cachede var database e gitme demek
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
        /*Cache aspecte süre vermezsen default 60min
        Cachemanager olarak service tool kullanarak hangi cache manageri kullandığını berlirt:ICache manager—
        (ki bu interface di burada hangisine bağlarsan Microsoft veya redis onu kkullanır)
        Bu yüzden bu sayfada kod değiştirmeyiz  eğer redise geçersek sadece coremodule de o iş

         * 
         * git bak bakalım bellekte böyle bir cache anahtarrı key varmı
        Varsa  =sen methodu hiç çalıştırmadan şimdi geri dön-cachede var ordan al diyor
        Else
        Git invocationu devam ettir methodu devam ettir
        Veritabanına gidecek
        Cache eklenecek
        Anahtar,return value ve duration ekleniş olacak

         * 
         */
    }
}
