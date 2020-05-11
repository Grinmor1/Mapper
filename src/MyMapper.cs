using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mapper
{
    public class MyMapper : IMyMapper
    {
        public TDestination Map<TDestination>(object sourceObject)
        {
            var instance = Map(sourceObject, typeof(TDestination));

            return (TDestination)instance;
        }

        public object Map(object sourceObject, Type destinationType)
        {
            var instance = Activator.CreateInstance(destinationType);

            var propertyInfos = sourceObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var type = instance.GetType();

            foreach (var propertyInfo in propertyInfos)
            {
                if (!TryGetProperty(type, propertyInfo.Name, out var targetPropertyInfo)) continue;

                var value = TryMapProperty(propertyInfo.GetValue(sourceObject), targetPropertyInfo.PropertyType);
                targetPropertyInfo.SetValue(instance, value);
            }

            return instance;

        }


        private object TryMapProperty(object sourceObject, Type destinationType)
        {
            try
            {
                object obj = null;

                if (sourceObject == null)
                {
                    return null;
                }

                var sourceOType = sourceObject.GetType();

                //I don't know why decimal is not primitive type, so to filter struct i need to make like this 
                if (destinationType.IsPrimitive || destinationType == typeof(string) || destinationType == typeof(decimal)) 
                {
                    obj = Convert.ChangeType(sourceObject, destinationType);
                }
                else
                {
                    if (destinationType.GetInterfaces().Contains(typeof(IEnumerable)))
                    {
                        if (destinationType.IsArray && sourceOType.IsArray)
                        {
                            obj = Convert.ChangeType(sourceObject, destinationType);
                        }
                        else 
                        {
                            obj = MakeGenericObject(sourceObject, destinationType);
                        }
                    }
                    else
                    {
                        obj = Map(sourceObject, destinationType);
                    }
                }

                return obj;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        private static object MakeGenericObject(object sourceObject, Type destinationType)
        {
            var concreteDestinationType = GetConcreteType(sourceObject, destinationType);

            var instance = Activator.CreateInstance(concreteDestinationType, sourceObject);

            return instance;

        }

        private static Type GetConcreteType(object sourceObject, Type destinationType)
        {
            var typeParameters = destinationType.GetGenericArguments();

            Type genericTypeDefinition;
            if (destinationType.IsInterface)
            {

                genericTypeDefinition = sourceObject.GetType().IsArray ? typeof(List<>) : sourceObject.GetType().GetGenericTypeDefinition();
            }
            else
            {
                genericTypeDefinition =  destinationType.GetGenericTypeDefinition();
            }

            return genericTypeDefinition.MakeGenericType(typeParameters);

        }

        private static bool TryGetProperty(Type type, string propertyName, out PropertyInfo targetPropertyInfo)
        {
            targetPropertyInfo = type.GetProperty(propertyName);

            return targetPropertyInfo != null;
        }
    }
}

