using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Mapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MapperTests
{
    [TestFixture]
    public class MyMapperTests
    {
        private MyMapper _myMapper;

        [SetUp]
        public void SetUp()
        {
            _myMapper = new MyMapper();
        }

        [Test]
        public void Map_TestWithPrimitives()
        {
            // Arrange
            var arrange = new EmptyObject()
            {
                Bool = true,
                Decimal = 0.5,
                Float = 0.7f,
                Double = 4.3,
                Int = 4,
                String = "String",
            };

            var expected = new SecondObject()
            {
                Bool = true,
                Decimal = 0.5,
                Float = 0.7f,
                Double = 4.3,
                Int = 4,
                String = "String"
            };

            // Act
            var actual = (SecondObject)_myMapper.Map(arrange, typeof(SecondObject));

            // Assert
            Assert.AreEqual(expected.Int, actual.Int);
            Assert.AreEqual(expected.Bool, actual.Bool);
            Assert.AreEqual(expected.Decimal, actual.Decimal);
            Assert.AreEqual(expected.Float, actual.Float);
            Assert.AreEqual(expected.String, actual.String);

        }

        [Test]
        public void Map_TestWithNestedTypes()
        {
            // Arrange
            var arrange = new EmptyObject()
            {
                NestedType = new NestedType()
                {
                    String = "String",
                    Int = 5
                },
                Struct = new Struct()
                {
                    String = "String",
                    Int = 4
                }

            };

            var expected = new SecondObject()
            {
                NestedType = new NestedType()
                {
                    String = "String",
                    Int = 5
                },
                Struct = new Struct()
                {
                    String = "String",
                    Int = 4
                }
            };

            // Act
            var actual = (SecondObject)_myMapper.Map(arrange, typeof(SecondObject));

            // Assert
            Assert.AreEqual(expected.NestedType.String, actual.NestedType.String);
            Assert.AreEqual(expected.NestedType.Int, actual.NestedType.Int);
            
            Assert.AreEqual(expected.Struct.String, actual.Struct.String);
            Assert.AreEqual(expected.Struct.Int, actual.Struct.Int);

        }


        [Test]
        public void Map_TestWithPrimitivesConverting()
        {
            // Arrange
            var arrange = new EmptyObject()
            {
               Struct2 =  new Struct()
               {
                   String = "String",
                   Int = 5
               },
               StringIntoInt = "5",
               DoubleIntoDecimal = 5.2,
               DecimalIntoInt = new decimal(2.4),
               IntIntoString = 13,
               
            };

            var expected = new SecondObject()
            {
                Struct2 = new Struct2()
                {
                    String = "String",
                    Int = 5
                },
                StringIntoInt = 5,
                DoubleIntoDecimal = new decimal(5.2),
                DecimalIntoInt = 2,
                IntIntoString = "13",
            };

            // Act
            var actual = (SecondObject)_myMapper.Map(arrange, typeof(SecondObject));

            // Assert
            Assert.AreEqual(expected.Struct2.String, actual.Struct2.String);
            Assert.AreEqual(expected.Struct2.Int, actual.Struct2.Int);

            Assert.AreEqual(expected.StringIntoInt, actual.StringIntoInt);
            Assert.AreEqual(expected.DoubleIntoDecimal, actual.DoubleIntoDecimal);
            Assert.AreEqual(expected.IntIntoString, actual.IntIntoString);
            Assert.AreEqual(expected.DecimalIntoInt, actual.DecimalIntoInt);

        }

        [Test]
        public void Map_TestWithCollections()
        {
            // Arrange
            var arrange = new EmptyObject()
            {
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
                ListNestedTypes = new List<NestedType>()
                {
                    new NestedType()
                    {String = "5",
                        Int = 3
                    },
                    new NestedType()
                    {String = "3",
                        Int = 5
                    }
                }

            };

            var expected = new SecondObject()
            {
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

                ListNestedTypes = new List<NestedType>()
                {
                    new NestedType()
                    {String = "5",
                        Int = 3
                    },
                    new NestedType()
                    {String = "3",
                        Int = 5
                    }
                }
            };

            // Act
            var actual = (SecondObject)_myMapper.Map(arrange, typeof(SecondObject));

            // Assert
            Assert.AreEqual(expected.ListNestedTypes[0].String, actual.ListNestedTypes[0].String);
            Assert.AreEqual(expected.ListNestedTypes[0].Int, actual.ListNestedTypes[0].Int);
            Assert.AreEqual(expected.ListNestedTypes[1].String, actual.ListNestedTypes[1].String);
            Assert.AreEqual(expected.ListNestedTypes[1].Int, actual.ListNestedTypes[1].Int);

            Assert.AreEqual(expected.IntArray, actual.IntArray);
            Assert.AreEqual(expected.Dictionary, actual.Dictionary);
            Assert.AreEqual(expected.EnumerableDoubles, actual.EnumerableDoubles);

        }


        [Test]
        public void Map_TestWithConvertingCollections()
        {
            // Arrange
            var arrange = new EmptyObject()
            {
                ArrayIntoList = new []
                {
                    "String1",
                    "String2",
                    "String3",
                    "String4",
                    "String5",
                },
                ListIntoArray =new List<int>
                {
                   2,4,5,1
                }

            };

            var expected = new SecondObject()
            {
               
                ArrayIntoList = new List<string>()
                {
                    "String1",
                    "String2",
                    "String3",
                    "String4",
                    "String5",
                },
                ListIntoArray = new int[]
                {
                    2,4,5,1
                }

            };

            // Act
            var actual = (SecondObject)_myMapper.Map(arrange, typeof(SecondObject));

            // Assert
            Assert.AreEqual(expected.ArrayIntoList, actual.ArrayIntoList);
            Assert.AreEqual(expected.ListIntoArray, actual.ListIntoArray);

        }

    }
}