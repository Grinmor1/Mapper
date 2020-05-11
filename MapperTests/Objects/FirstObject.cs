using System.Collections.Generic;
using Mapper;

namespace MapperTests
{
    public class FirstObject
    {
        public int[] IntArray { get; set; }
        public int Int { get; set; }
        public string String { get; set; }
        public bool Bool { get; set; }
        public double Double { get; set; }
        public string StringIntoInt { get; set; }
        public int IntIntoString { get; set; }
        public decimal DecimalIntoInt { get; set; }
        public double DoubleIntoDecimal { get; set; }
        public double Decimal { get; set; }
        public float Float { get; set; }
        public Struct Struct { get; set; }
        public Struct Struct2 { get; set; }
        public List<int> ListIntoArray { get; set; }
        public string[] ArrayIntoList { get; set; }
        public NestedType NestedType { get; set; }
        public List<NestedType> ListNestedTypes { get; set; }
        public IDictionary<string, int> Dictionary { get; set; }
        public IEnumerable<double> EnumerableDoubles { get; set; }
    }
}
