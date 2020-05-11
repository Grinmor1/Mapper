using System;

namespace Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyMapper mapper = new MyMapper();

            var obj = new FirstObject();

           // mapper.Map(5.5, typeof(Type));

           var s =  mapper.Map<SecondObject>(obj);
        }
    }
}
