using LongArithmetic.Core;
using System.Numerics;

namespace LongArithmetic.Tests;

public class BigNumbersTests
{
    [Test]
    public void TestToString()
    {
        BigInteger expected = new BigInteger(15315135135135);

        BigNumber actual = new BigNumber("15315135135135");

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestToStringNegative()
    {
        BigInteger expected = new BigInteger(-15315135135135);

        BigNumber actual = new BigNumber("-15315135135135");

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestMultiplication()
    {
        BigInteger bigInteger1 = new BigInteger(12345);
        BigInteger bigInteger2 = new BigInteger(23456);
        BigInteger expected = bigInteger1 * bigInteger2;

        BigNumber bigNumber1 = new BigNumber("12345");
        BigNumber bigNumber2 = new BigNumber("23456");
        BigNumber actual = bigNumber1 * bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestMultiplicationOnZero()
    {
        BigNumber bigNumber1 = new BigNumber("12345");
        BigNumber bigNumber2 = new BigNumber("0");
        BigNumber actual = bigNumber1 * bigNumber2;

        Assert.AreEqual("0", actual.ToString());
    }

    [Test]
    public void TestMultiplicationDoubleZero()
    {
        BigNumber bigNumber1 = new BigNumber("0");
        BigNumber bigNumber2 = new BigNumber("0");
        BigNumber actual = bigNumber1 * bigNumber2;

        Assert.AreEqual("0", actual.ToString());
    }

    [Test]
    public void TestSuperBigNumbers()
    {
        BigInteger bigInteger1 = new BigInteger(1000000000000);
        BigInteger bigInteger2 = new BigInteger(2412412423623);
        BigInteger expected = bigInteger1 * bigInteger2;

        BigNumber bigNumber1 = new BigNumber("1000000000000");
        BigNumber bigNumber2 = new BigNumber("2412412423623");
        BigNumber actual = bigNumber1 * bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestMultiplicationNegativeNumber()
    {
        BigInteger bigInteger1 = new BigInteger(-2);
        BigInteger bigInteger2 = new BigInteger(3);
        BigInteger expected = bigInteger1 * bigInteger2;

        BigNumber bigNumber1 = new BigNumber("-2");
        BigNumber bigNumber2 = new BigNumber("3");
        BigNumber actual = bigNumber1 * bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestMultiplicationNegativeNumbers()
    {
        BigInteger bigInteger1 = new BigInteger(-2);
        BigInteger bigInteger2 = new BigInteger(-3);
        BigInteger expected = bigInteger1 * bigInteger2;

        BigNumber bigNumber1 = new BigNumber("-2");
        BigNumber bigNumber2 = new BigNumber("-3");
        BigNumber actual = bigNumber1 * bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestMultiplicationOnOne()
    {
        BigInteger bigInteger1 = new BigInteger(123123);
        BigInteger bigInteger2 = new BigInteger(1);
        BigInteger expected = bigInteger1 * bigInteger2;

        BigNumber bigNumber1 = new BigNumber("123123");
        BigNumber bigNumber2 = new BigNumber("1");
        BigNumber actual = bigNumber1 * bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestDivisionBasic()
    {
        BigInteger bigInteger1 = new BigInteger(100);
        BigInteger bigInteger2 = new BigInteger(10);
        BigInteger expected = bigInteger1 / bigInteger2;

        BigNumber bigNumber1 = new BigNumber("100");
        BigNumber bigNumber2 = new BigNumber("10");
        BigNumber actual = bigNumber1 / bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestDivisionNegativeNumber01()
    {
        BigInteger bigInteger1 = new BigInteger(100);
        BigInteger bigInteger2 = new BigInteger(-10);
        BigInteger expected = bigInteger1 / bigInteger2;

        BigNumber bigNumber1 = new BigNumber("100");
        BigNumber bigNumber2 = new BigNumber("-10");
        BigNumber actual = bigNumber1 / bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestDivisionNegativeNumber02()
    {
        BigInteger bigInteger1 = new BigInteger(10000000000);
        BigInteger bigInteger2 = new BigInteger(-100000);
        BigInteger expected = bigInteger1 / bigInteger2;

        BigNumber bigNumber1 = new BigNumber("10000000000");
        BigNumber bigNumber2 = new BigNumber("-100000");
        BigNumber actual = bigNumber1 / bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestDivisionNegativeNumbers01()
    {
        BigInteger bigInteger1 = new BigInteger(-100);
        BigInteger bigInteger2 = new BigInteger(-10);
        BigInteger expected = bigInteger1 / bigInteger2;

        BigNumber bigNumber1 = new BigNumber("-100");
        BigNumber bigNumber2 = new BigNumber("-10");
        BigNumber actual = bigNumber1 / bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestDivisionNegativeNumbers02()
    {
        BigInteger bigInteger1 = new BigInteger(-100000000000000);
        BigInteger bigInteger2 = new BigInteger(-100000000000);
        BigInteger expected = bigInteger1 / bigInteger2;

        BigNumber bigNumber1 = new BigNumber("-100000000000000");
        BigNumber bigNumber2 = new BigNumber("-100000000000");
        BigNumber actual = bigNumber1 / bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestDivisionZeroNumerator()
    {
        BigInteger bigInteger1 = new BigInteger(0);
        BigInteger bigInteger2 = new BigInteger(1);
        BigInteger expected = bigInteger1 / bigInteger2;

        BigNumber bigNumber1 = new BigNumber("0");
        BigNumber bigNumber2 = new BigNumber("1");
        BigNumber actual = bigNumber1 / bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
    [Test]
    public void TestDivisionNegativeZeroNumerator()
    {
        BigInteger bigInteger1 = new BigInteger(0);
        BigInteger bigInteger2 = new BigInteger(-1);
        BigInteger expected = bigInteger1 / bigInteger2;

        BigNumber bigNumber1 = new BigNumber("0");
        BigNumber bigNumber2 = new BigNumber("-1");
        BigNumber actual = bigNumber1 / bigNumber2;

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestAbs()
    {

        BigInteger bigInteger1 = new BigInteger(1);
        BigInteger expected = BigInteger.Abs(bigInteger1);

        BigNumber bigNumber1 = new BigNumber("1");
        BigNumber actual = BigNumber.Abs(bigNumber1);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestAbsNegative()
    {

        BigInteger bigInteger1 = new BigInteger(-1);
        BigInteger expected = BigInteger.Abs(bigInteger1);

        BigNumber bigNumber1 = new BigNumber("-1");
        BigNumber actual = BigNumber.Abs(bigNumber1);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestGreaterThan01()
    {
        BigNumber bigNumber1 = new BigNumber("554262461");
        BigNumber bigNumber2 = new BigNumber("25245243");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsTrue(result);

    }

    [Test]
    public void TestGreaterThan03()
    {
        BigNumber bigNumber1 = new BigNumber("554262461");
        BigNumber bigNumber2 = new BigNumber("-24124123");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsTrue(result);
    }

    [Test]
    public void TestGreaterThan04()
    {
        BigNumber bigNumber1 = new BigNumber("-554262461");
        BigNumber bigNumber2 = new BigNumber("-24124123");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsTrue(result);
    }

    [Test]
    public void TestGreaterThanFalse01()
    {
        BigNumber bigNumber1 = new BigNumber("24123214");
        BigNumber bigNumber2 = new BigNumber("451241241");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestGreaterThanFalse02()
    {
        BigNumber bigNumber1 = new BigNumber("-24123214");
        BigNumber bigNumber2 = new BigNumber("451241241");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestGreaterThanFalse04()
    {
        BigNumber bigNumber1 = new BigNumber("-24123214");
        BigNumber bigNumber2 = new BigNumber("-451241241");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestGreaterThanFalse05()
    {
        BigNumber bigNumber1 = new BigNumber("24123214");
        BigNumber bigNumber2 = new BigNumber("24123214");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestGreaterThanFalse06()
    {
        BigNumber bigNumber1 = new BigNumber("-24123214");
        BigNumber bigNumber2 = new BigNumber("-24123214");
        bool result = BigNumber.GreaterThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestLessThan01()
    {
        BigNumber bigNumber1 = new BigNumber("2412421");
        BigNumber bigNumber2 = new BigNumber("24123214");
        bool result = BigNumber.LessThan(bigNumber1, bigNumber2);

        Assert.IsTrue(result);
    }

    [Test]
    public void TestLessThan02()
    {
        BigNumber bigNumber1 = new BigNumber("-2412421");
        BigNumber bigNumber2 = new BigNumber("24123214");
        bool result = BigNumber.LessThan(bigNumber1, bigNumber2);

        Assert.IsTrue(result);
    }

    [Test]
    public void TestLessThanFalse01()
    {
        BigNumber bigNumber1 = new BigNumber("24123214");
        BigNumber bigNumber2 = new BigNumber("2412421");
        bool result = BigNumber.LessThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestLessThanFalse02()
    {
        BigNumber bigNumber1 = new BigNumber("24123214");
        BigNumber bigNumber2 = new BigNumber("-241242124123214");
        bool result = BigNumber.LessThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestLessThanFalse03()
    {
        BigNumber bigNumber1 = new BigNumber("24123214");
        BigNumber bigNumber2 = new BigNumber("24123214");
        bool result = BigNumber.LessThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestLessThanFalse04()
    {
        BigNumber bigNumber1 = new BigNumber("-24123214");
        BigNumber bigNumber2 = new BigNumber("-24123214");
        bool result = BigNumber.LessThan(bigNumber1, bigNumber2);

        Assert.IsFalse(result);
    }

    [Test]
    public void TestAdd()
    {
        BigInteger bigInteger1 = new BigInteger(124124);
        BigInteger bigInteger2 = new BigInteger(124124);
        BigInteger expected = BigInteger.Add(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("124124");
        BigNumber bigNumber2 = new BigNumber("124124");
        BigNumber actual = BigNumber.Add(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestAddNegativeFirst()
    {
        BigInteger bigInteger1 = new BigInteger(-124124);
        BigInteger bigInteger2 = new BigInteger(124124);
        BigInteger expected = BigInteger.Add(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("-124124");
        BigNumber bigNumber2 = new BigNumber("124124");
        BigNumber actual = BigNumber.Add(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestAddNegativeSecond()
    {
        BigInteger bigInteger1 = new BigInteger(124124);
        BigInteger bigInteger2 = new BigInteger(-124124);
        BigInteger expected = BigInteger.Add(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("124124");
        BigNumber bigNumber2 = new BigNumber("-124124");
        BigNumber actual = BigNumber.Add(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestAddNegativeBoth()
    {
        BigInteger bigInteger1 = new BigInteger(-124124);
        BigInteger bigInteger2 = new BigInteger(-124124);
        BigInteger expected = BigInteger.Add(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("-124124");
        BigNumber bigNumber2 = new BigNumber("-124124");
        BigNumber actual = BigNumber.Add(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestSubstract()
    {
        BigInteger bigInteger1 = new BigInteger(124124);
        BigInteger bigInteger2 = new BigInteger(124124);
        BigInteger expected = BigInteger.Subtract(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("124124");
        BigNumber bigNumber2 = new BigNumber("124124");
        BigNumber actual = BigNumber.Subtract(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestSubstractNegativeFirst()
    {
        BigInteger bigInteger1 = new BigInteger(-124124);
        BigInteger bigInteger2 = new BigInteger(124124);
        BigInteger expected = BigInteger.Subtract(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("-124124");
        BigNumber bigNumber2 = new BigNumber("124124");
        BigNumber actual = BigNumber.Subtract(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestSubstractNegativeSecond()
    {
        BigInteger bigInteger1 = new BigInteger(124124);
        BigInteger bigInteger2 = new BigInteger(-124124);
        BigInteger expected = BigInteger.Subtract(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("124124");
        BigNumber bigNumber2 = new BigNumber("-124124");
        BigNumber actual = BigNumber.Subtract(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestSubstractNegativeBoth()
    {
        BigInteger bigInteger1 = new BigInteger(-124124);
        BigInteger bigInteger2 = new BigInteger(-124124);
        BigInteger expected = BigInteger.Subtract(bigInteger1, bigInteger2);

        BigNumber bigNumber1 = new BigNumber("-124124");
        BigNumber bigNumber2 = new BigNumber("-124124");
        BigNumber actual = BigNumber.Subtract(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestMod01()
    {

        int a = 1412412;
        int b = 13203;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("1412412");
        BigNumber bigNumber2 = new BigNumber("13203");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestMod02()
    {

        int a = 13203;
        int b = 1412412;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("13203");
        BigNumber bigNumber2 = new BigNumber("1412412");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModNegativeFirst01()
    {

        int a = -1412412;
        int b = 13203;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("-1412412");
        BigNumber bigNumber2 = new BigNumber("13203");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModNegativeFirst02()
    {

        int a = -13203;
        int b = 1412412;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("-13203");
        BigNumber bigNumber2 = new BigNumber("1412412");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModNegativeSecond01()
    {

        int a = 1412412;
        int b = -13203;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("1412412");
        BigNumber bigNumber2 = new BigNumber("-13203");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModNegativeSecond02()
    {

        int a = 13203;
        int b = -1412412;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("13203");
        BigNumber bigNumber2 = new BigNumber("-1412412");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModNegativeBoth01()
    {

        int a = -1412412;
        int b = -13203;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("-1412412");
        BigNumber bigNumber2 = new BigNumber("-13203");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModNegativeBoth02()
    {

        int a = -13203;
        int b = -1412412;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("-13203");
        BigNumber bigNumber2 = new BigNumber("-1412412");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModEquals()
    {

        int a = 1412412;
        int b = 1412412;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("1412412");
        BigNumber bigNumber2 = new BigNumber("1412412");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }

    [Test]
    public void TestModEqualsNegative()
    {

        int a = -1412412;
        int b = -1412412;
        int expected = a % b;

        BigNumber bigNumber1 = new BigNumber("-1412412");
        BigNumber bigNumber2 = new BigNumber("-1412412");
        BigNumber actual = BigNumber.Mod(bigNumber1, bigNumber2);

        Assert.AreEqual(expected.ToString(), actual.ToString());
    }
}