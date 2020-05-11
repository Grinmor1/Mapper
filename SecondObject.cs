using System;
using System.Collections.Generic;
using System.Text;

namespace Mapper
{
   public class SecondObject
    {
        public int Int { get; set; }
        public string FirstString { get; set; }
        public bool Bool { get; set; }
        public double Double { get; set; }
        public int SecondString { get; set; }
        public double Decimal { get; set; }
        public float Float { get; set; }
        public Struct Struct { get; set; }
        public Struct2 Struct2 { get; set; }
        public NestedType NestedType { get; set; }
        public List<NestedType> ListNestedTypes { get; set; }
        public IDictionary<string, int> Dictionary { get; set; } 
        public IList<int> IntArray { get; set; }
        public List<string> StringList { get; set; }
        public IEnumerable<double> EnumerableDoubles { get; set; }
    }
}

