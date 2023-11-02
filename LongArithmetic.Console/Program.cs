// See https://aka.ms/new-console-template for more information

using LongArithmetic.Core;

Console.WriteLine("Hello, World!");

BigNumber num1 = new BigNumber("-789162378923789237891798123897397862173");
BigNumber num2 = new BigNumber("-91798123897397862173");

BigNumber result = num1 + num2;

Console.WriteLine(result);