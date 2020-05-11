using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
    public class FirstObject
    {
        public int Int { get; set; } = 10;
        public string String { get; set; } = "String";
        public int Bool { get; set; } = 0;
        public double Double { get; set; } = 0.4;
        public string StringIntoInt { get; set; } = "5";
        public decimal Decimal { get; set; } = new decimal(0.3);
        public float Float { get; set; } = 0.3f;
        public int IntIntoString { get; set; } = 3;
        public decimal DecimalIntoInt { get; set; } = new decimal(1.3);
        public double DoubleIntoDecimal { get; set; } = 2.3;

        public int[] IntArray { get; set; } = new[] {4, 5, 3, 1, 5, 67, 6, 1};

        public NestedType NestedType { get; set; } = new NestedType() {Int = 4, String = "String"};

        public Struct Struct { get; set; } = new Struct()
        {
            Int = 4,
            String = "String"
        };

        public Struct Struct2 { get; set; } = new Struct()
        {
            Int = 4,
            String = "String"
        };

        public IList<int> ListIntoArray { get; set; }= new List<int>()
        {
            1,3,5,6
        };
        public string[] ArrayIntoList { get; set; } = new string[]
        {
            "string1",
            "string2",
            "string3",
            "string4",
            "string5",
        };

        public IDictionary<string, int> Dictionary { get; set; } = new Dictionary<string, int>()
        {
            {"string1", 1},
            {"string2", 2},
            {"string3", 3},
        };

        public IList<NestedType> ListNestedTypes { get; set; } = new List<NestedType>()
        {
            new NestedType()
            {String = "5",
                Int = 3
            },
            new NestedType()
            {String = "3",
                Int = 5
            }
        };

        public IEnumerable<double> EnumerableDoubles { get; set; } = new double[]
        {
            0.4, 0.3, 1.5
        };


    }

    public class NestedType
    {
        public int Int { get; set; }
        public string String { get; set; }

    }

    public class Class1
    {
        public int Int { get; set; }
        public string String { get; set; }
    }
    public struct Struct
    {
        public int Int { get; set; }
        public string String { get; set; }
    }

    public struct Struct2
    {
        public int Int { get; set; }
        public string String { get; set; }
    }
}
