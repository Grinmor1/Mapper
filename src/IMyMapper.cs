using System;

namespace Mapper
{
    public interface IMyMapper
    {
        TDestination Map<TDestination>(object sourceObject);
        object Map(object sourceObject, Type destinationType);
    }
}
