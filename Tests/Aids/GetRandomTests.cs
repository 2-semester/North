﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Abc.Aids.Random;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;

namespace North.Tests.Aids
{

    [TestClass]
    public class GetRandomTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(GetRandom);

        [TestMethod]
        public void BoolTest()
        {
            var b = GetRandom.Bool();
            Assert.IsInstanceOfType(b, typeof(bool));

            while (true)
                if (GetRandom.Bool() == !b)
                    return;
        }

        [TestMethod]
        public void CharTest()
        {
            doTests(GetRandom.Char, 'a', 'z');
            doTests(GetRandom.Char, 'A', 'Z');
            doTests(GetRandom.Char, char.MinValue, char.MaxValue);
            doTests(GetRandom.Char, char.MinValue, (char)(char.MinValue + 100));
            doTests(GetRandom.Char, (char)(char.MaxValue - 100), char.MaxValue);
        }

        [TestMethod] public void ColorTest() => doTests(GetRandom.Color);


        [TestMethod]
        public void DateTimeTest()
        {
            var now = DateTime.Now;
            var min = DateTime.MinValue;
            var max = DateTime.MaxValue;
            doTests((x, y) => GetRandom.DateTime(x, y), now.AddYears(-5), now.AddYears(5));
            doTests((x, y) => GetRandom.DateTime(x, y), min, min.AddYears(10));
            doTests((x, y) => GetRandom.DateTime(x, y), max.AddYears(-10), max);
            doTests((x, y) => GetRandom.DateTime(x, y), min, max);
        }

        [TestMethod]
        public void DecimalTest()
        {
            var d = 10M;
            doTests(GetRandom.Decimal, 100M, 200M);
            doTests(GetRandom.Decimal, -200M, 100M);
            doTests(GetRandom.Decimal, -400M, -200M);
            doTests(GetRandom.Decimal, decimal.MinValue, decimal.MaxValue);
            doTests(GetRandom.Decimal, decimal.MinValue, decimal.MinValue / d);
            doTests(GetRandom.Decimal, decimal.MaxValue / d, decimal.MaxValue);
        }

        [TestMethod]
        public void DoubleTest()
        {
            var d = 100000;
            doTests(GetRandom.Double, (double)10, 110);
            doTests(GetRandom.Double, (double)-110, -10);
            doTests(GetRandom.Double, (double)-50, 50);
            doTests(GetRandom.Double, double.MinValue, double.MaxValue);
            doTests(GetRandom.Double, double.MaxValue / d, double.MaxValue);
            doTests(GetRandom.Double, double.MinValue, double.MinValue / d);
        }

        [TestMethod]
        public void EnumTest()
        {
            var e = GetRandom.Enum<IsoGender>();
            Assert.IsInstanceOfType(e, typeof(IsoGender));

            while (true)
                if (GetRandom.Enum<IsoGender>() != e)
                    return;
        }

        [TestMethod]
        public void FloatTest()
        {
            var d = 10F;
            doTests(GetRandom.Float, 10F, 110F);
            doTests(GetRandom.Float, -110F, -10F);
            doTests(GetRandom.Float, -50F, 50F);
            doTests(GetRandom.Float, float.MinValue, float.MaxValue);
            doTests(GetRandom.Float, float.MaxValue / d, float.MaxValue);
            doTests(GetRandom.Float, float.MinValue, float.MinValue / d);
        }

        [TestMethod]
        public void Int8Test()
        {
            doTests(GetRandom.Int8, (sbyte)10, (sbyte)110);
            doTests(GetRandom.Int8, (sbyte)-110, (sbyte)-10);
            doTests(GetRandom.Int8, (sbyte)-50, (sbyte)50);
            doTests(GetRandom.Int8, sbyte.MinValue, (sbyte)(sbyte.MinValue + 100));
            doTests(GetRandom.Int8, (sbyte)(sbyte.MaxValue - 100), sbyte.MaxValue);
            doTests(GetRandom.Int8, sbyte.MinValue, sbyte.MaxValue);
        }

        [TestMethod]
        public void Int16Test()
        {
            doTests(GetRandom.Int16, (short)100, (short)200);
            doTests(GetRandom.Int16, (short)-200, (short)100);
            doTests(GetRandom.Int16, (short)-400, (short)-200);
            doTests(GetRandom.Int16, short.MinValue, (short)(short.MinValue + 200));
            doTests(GetRandom.Int16, (short)(short.MaxValue - 100), short.MaxValue);
            doTests(GetRandom.Int16, short.MinValue, short.MaxValue);
        }

        [TestMethod]
        public void Int32Test()
        {
            doTests(GetRandom.Int32, 100, 200);
            doTests(GetRandom.Int32, -200, 100);
            doTests(GetRandom.Int32, -400, -200);
            doTests(GetRandom.Int32, int.MinValue, int.MinValue + 200);
            doTests(GetRandom.Int32, int.MaxValue - 100, int.MaxValue);
            doTests(GetRandom.Int32, int.MinValue, int.MaxValue);
        }

        [TestMethod]
        public void Int64Test()
        {
            var d = 100000000L;
            doTests(GetRandom.Int64, (long)100, 200);
            doTests(GetRandom.Int64, (long)-200, 100);
            doTests(GetRandom.Int64, (long)-400, -200);
            doTests(GetRandom.Int64, long.MinValue, long.MaxValue);
            doTests(GetRandom.Int64, long.MinValue, long.MinValue + d);
            doTests(GetRandom.Int64, long.MaxValue - d, long.MaxValue);
        }

        [TestMethod]
        public void StringTest()
        {
            doTests(() => GetRandom.String());
        }

        [TestMethod]
        public void TimeSpanTest()
        {
            doTests(GetRandom.TimeSpan);
        }

        [TestMethod]
        public void UInt8Test()
        {
            doTests(GetRandom.UInt8, (byte)10, (byte)110);
            doTests(GetRandom.UInt8, byte.MinValue, (byte)(byte.MinValue + 100));
            doTests(GetRandom.UInt8, (byte)(byte.MaxValue - 100), byte.MaxValue);
            doTests(GetRandom.UInt8, byte.MinValue, byte.MaxValue);
        }

        [TestMethod]
        public void UInt16Test()
        {
            doTests(GetRandom.UInt16, (ushort)100, (ushort)200);
            doTests(GetRandom.UInt16, ushort.MinValue, (ushort)(ushort.MinValue + 200));
            doTests(GetRandom.UInt16, (ushort)(ushort.MaxValue - 100), ushort.MaxValue);
            doTests(GetRandom.UInt16, ushort.MinValue, ushort.MaxValue);
        }

        [TestMethod]
        public void UInt32Test()
        {
            doTests(GetRandom.UInt32, (uint)100, (uint)200);
            doTests(GetRandom.UInt32, uint.MinValue, uint.MinValue + 200);
            doTests(GetRandom.UInt32, uint.MaxValue - 100, uint.MaxValue);
            doTests(GetRandom.UInt32, uint.MinValue, uint.MaxValue);
        }

        [TestMethod]
        public void EmailTest()
        {
            Assert.AreNotEqual(GetRandom.Email(), GetRandom.Email());
        }

        [TestMethod]
        public void PasswordTest()
        {
            Assert.AreNotEqual(GetRandom.Password(), GetRandom.Password());
        }

        [TestMethod]
        public void UInt64Test()
        {
            var d = 100000000UL;
            doTests(GetRandom.UInt64, (ulong)100, (ulong)200);
            doTests(GetRandom.UInt64, ulong.MinValue, ulong.MaxValue);
            doTests(GetRandom.UInt64, ulong.MinValue, ulong.MinValue + d);
            doTests(GetRandom.UInt64, ulong.MaxValue - d, ulong.MaxValue);
        }

        [TestMethod]
        public void ArrayTest()
        {
            static void test(Type x, Type y = null) => Assert.IsInstanceOfType(GetRandom.Array(x), y);
            test(typeof(bool), typeof(bool[]));
            test(typeof(char), typeof(char[]));
            test(typeof(Color), typeof(Color[]));
            test(typeof(int), typeof(int[]));
        }

        [TestMethod]
        public void ValueTest()
        {
            static void test(Type x, Type y = null)
            {
                Assert.IsInstanceOfType(GetRandom.Value(x), y ?? x);

                if (y is null) return;
                Assert.IsInstanceOfType(GetRandom.Value(y), y);
            }

            test(typeof(bool?), typeof(bool));
            test(typeof(char?), typeof(char));
            test(typeof(Color?), typeof(Color));
            test(typeof(DateTime?), typeof(DateTime));
            test(typeof(decimal?), typeof(decimal));
            test(typeof(double?), typeof(double));
            test(typeof(IsoGender?), typeof(IsoGender));
            test(typeof(float?), typeof(float));
            test(typeof(sbyte?), typeof(sbyte));
            test(typeof(short?), typeof(short));
            test(typeof(int?), typeof(int));
            test(typeof(long?), typeof(long));
            test(typeof(TimeSpan?), typeof(TimeSpan));
            test(typeof(byte?), typeof(byte));
            test(typeof(ushort?), typeof(ushort));
            test(typeof(uint?), typeof(uint));
            test(typeof(ulong?), typeof(ulong));
            test(typeof(string));
            test(typeof(object));
            test(typeof(EventData));
        }

        [TestMethod]
        public void ObjectTest()
        {
            Assert.IsNull(GetRandom.Object(null));
            var o = GetRandom.Object(typeof(EventData)) as EventData;
            Assert.IsNotNull(o);
            Assert.IsFalse(string.IsNullOrWhiteSpace(o.Id));
            Assert.IsFalse(string.IsNullOrWhiteSpace(o.Name));
            var l = GetRandom.Object(typeof(List<int>)) as List<int>;
            Assert.IsNotNull(l);
            Assert.IsTrue(l.Count > 0);
        }

        [TestMethod]
        public void ListTest()
        {
            var l = GetRandom.List(() => GetRandom.String());
            Assert.IsNotNull(l);
            Assert.IsInstanceOfType(l, typeof(List<string>));
            Assert.AreNotEqual(0, l.Count);
            foreach (var s in l) Assert.IsFalse(string.IsNullOrWhiteSpace(s));
        }

        [TestMethod]
        public void AnyDoubleTest()
        {
            var x = GetRandom.AnyDouble();

            switch (x)
            {
                case byte _:
                case sbyte _:
                case short _:
                case ushort _:
                case int _:
                case uint _:
                case long _:
                case ulong _:
                case float _:
                case double _:
                    return;
                default:
                    Assert.Fail($"{x} is <{x.GetType().Name}> is not double");

                    break;
            }
        }

        [TestMethod]
        public void AnyIntTest()
        {
            var x = GetRandom.AnyInt();

            switch (x)
            {
                case byte _:
                case sbyte _:
                case short _:
                case ushort _:
                case int _:
                case uint _:
                case long _:
                case ulong _:
                    return;
                default:
                    Assert.Fail($"{x} is <{x.GetType().Name}> is not int");

                    break;
            }
        }

        [TestMethod]
        public void AnyValueTest()
        {
            var x = GetRandom.AnyValue();

            switch (x)
            {
                case byte _:
                case sbyte _:
                case short _:
                case ushort _:
                case int _:
                case uint _:
                case long _:
                case ulong _:
                case float _:
                case double _:
                case DateTime _:
                case string _:
                case char _:
                case decimal _:
                    return;
                default:
                    Assert.Fail($"{x} is <{x.GetType().Name}> is not allowed object");

                    break;
            }
        }

        private static void doTests<T>(Func<T, T, T> f, T min, T max)
            where T : IComparable
        {
            testBorder(f, min);
            testBorder(f, max);
            testBetweenBorders(f, min, max);
            testBetweenBorders((x, y) => f(max, min), min, max);
        }

        private static void testBorder<T>(Func<T, T, T> f, T x) => Assert.AreEqual(x, f(x, x));

        private static void testBetweenBorders<T>(Func<T, T, T> f, T min, T max) where T : IComparable
        {
            var l = new List<T>();

            for (var i = 0; i < 10; i++)
            {
                T r;

                do { r = f(min, max); } while (l.Contains(r));

                Assert.IsInstanceOfType(r, typeof(T));
                Assert.IsTrue(r.CompareTo(min) >= 0, $"{r} !>= {min}");
                Assert.IsTrue(r.CompareTo(max) <= 0, $"{r} !<= {min}");
                l.Add(r);
            }
        }


        private static void doTests<T>(Func<T> f)
        {
            var l = new List<T>();

            for (var i = 0; i < 10; i++)
            {
                T r;

                do { r = f(); } while (l.Contains(r));

                Assert.IsInstanceOfType(r, typeof(T));
                l.Add(r);
            }
        }


    }

}











