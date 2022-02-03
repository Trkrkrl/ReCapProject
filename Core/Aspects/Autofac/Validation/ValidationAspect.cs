using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil veya yanlış doğrulama tipi");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//validator tipinin(car,products vs) bir instance sini oluşturur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];// o validatorun çalışma yani base type ını bul, generic argümanını bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//validatorun type ıına eşit olan parametreleri bul diyor
            foreach (var entity in entities)//foreach ile bunları gez ve validation tool kullanarak validate et
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
