using System;
using System.Collections.Generic;
using Mapper;
using MapperTests;


namespace StartUp
{
    class Program
    {
        static void Main(string[] args)
        {
            IMyMapper mapper = new MyMapper();

            var obj = new FirstObject()
            {
                Bool = true,
                Decimal = 0.5,
                Float = 0.7f,
                Double = 4.3,
                Int = 4,
                String = "String",
                NestedType = new NestedType()
                {
                    String = "String",
                    Int = 5
                },
                Struct2 = new Struct()
                {
                    String = "String",
                    Int = 5
                },
                StringIntoInt = "5",
                DoubleIntoDecimal = 5.2,
                DecimalIntoInt = new decimal(2.4),
                IntIntoString = 13,
                IntArray = new[] { 4, 3, 6, 2 },
                EnumerableDoubles = new List<double>()
                {
                    4.4,
                    5.3
                },
                Dictionary = new Dictionary<string, int>()
                {
                    {"String1", 1 },
                    {"String2", 2 },
                    {"String3", 3 },
                    {"String4", 4 },
                },
                ArrayIntoList = new[]
                {
                    "String1",
                    "String2",
                    "String3",
                    "String4",
                    "String5",
                },
                ListIntoArray = new List<int>
                {
                    2,4,5,1
                },
                ListNestedTypes = new List<NestedType>()
                {
                new NestedType() {
                    String = "5",
                    Int = 3}, 
                new NestedType() {
                    String = "3", 
                    Int = 5}
            }
            };

            var secondObject = mapper.Map<SecondObject>(obj);
        }
    }
}
