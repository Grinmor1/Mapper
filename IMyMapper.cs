using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
    public interface IMyMapper
    {
        TDestination Map<TDestination>(object sourceObject);
        object Map(object sourceObject, Type destinationType);
    }
}
