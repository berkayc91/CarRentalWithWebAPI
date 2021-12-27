using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) // type la veriyoruz attrlarda.


        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //newleme işi çalışma anında reflc. product validatorun instance ını oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // çalışma tipini bull.çalıştığı veri tipini bul.base ini(asbtvalidator) bul generic çalıştığı tipi bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// onun parametrelerini bul yani ilgili methodun ilgili parametrelerini aslında productla çalışırken .
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);// validation toolu kullanarak validate et.
            }
        }
    }
}
