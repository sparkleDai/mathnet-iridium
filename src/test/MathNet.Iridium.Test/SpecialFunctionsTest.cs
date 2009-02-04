//-----------------------------------------------------------------------
// <copyright file="SpecialFunctionsTest.cs" company="Math.NET Project">
//    Copyright (c) 2002-2009, Christoph R�egg.
//    All Right Reserved.
// </copyright>
// <author>
//    Christoph R�egg, http://christoph.ruegg.name
// </author>
// <product>
//    Math.NET Iridium, part of the Math.NET Project.
//    http://mathnet.opensourcedotnet.info
// </product>
// <license type="opensource" name="LGPL" version="2 or later">
//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU Lesser General Public License as published 
//    by the Free Software Foundation; either version 2 of the License, or
//    any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public 
//    License along with this program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using NUnit.Framework;

using MathNet.Numerics;

namespace Iridium.Test
{
    [TestFixture]
    public class SpecialFunctionsTest
    {
        [Test]
        public void TestSpecialFunctions_IntLog2()
        {
            Assert.AreEqual(0, Fn.IntLog2(1), "A");
            Assert.AreEqual(1, Fn.IntLog2(2), "B");
            Assert.AreEqual(2, Fn.IntLog2(3), "C");
            Assert.AreEqual(2, Fn.IntLog2(4), "D");

            for(int i = 2; i < 31; i++)
            {
                int pow = (int)Math.Pow(2.0, i);
                Assert.AreEqual(i, Fn.IntLog2(pow), pow.ToString());
                Assert.AreEqual(i, Fn.IntLog2(pow - 1), pow.ToString() + "-1");
                Assert.AreEqual(i + 1, Fn.IntLog2(pow + 1), pow.ToString() + "+1");
            }

            Assert.AreEqual(31, Fn.IntLog2(int.MaxValue), "Y");
            Assert.AreEqual(31, Fn.IntLog2(int.MaxValue - 1), "Z");
        }

        [Test]
        public void TestSpecialFunctions_FloorToPowerOf2()
        {
            Assert.AreEqual(0, Fn.FloorToPowerOf2(0), "A");
            Assert.AreEqual(1, Fn.FloorToPowerOf2(1), "B");
            Assert.AreEqual(2, Fn.FloorToPowerOf2(2), "C");
            Assert.AreEqual(2, Fn.FloorToPowerOf2(3), "D");
            Assert.AreEqual(4, Fn.FloorToPowerOf2(4), "E");

            for(int i = 2; i < 31; i++)
            {
                int pow = (int)Math.Pow(2.0, i);
                Assert.AreEqual(pow, Fn.FloorToPowerOf2(pow), pow.ToString());
                Assert.AreEqual(pow >> 1, Fn.FloorToPowerOf2(pow - 1), pow.ToString() + "-1");
            }

            Assert.AreEqual((int.MaxValue >> 1) + 1, Fn.FloorToPowerOf2(int.MaxValue), "Z");
        }

        [Test]
        public void TestSpecialFunctions_CeilingToPowerOf2()
        {
            Assert.AreEqual(0, Fn.CeilingToPowerOf2(0), "A");
            Assert.AreEqual(1, Fn.CeilingToPowerOf2(1), "B");
            Assert.AreEqual(2, Fn.CeilingToPowerOf2(2), "C");
            Assert.AreEqual(4, Fn.CeilingToPowerOf2(3), "D");
            Assert.AreEqual(4, Fn.CeilingToPowerOf2(4), "E");

            for(int i = 2; i < 31; i++)
            {
                int pow = (int)Math.Pow(2.0, i);
                Assert.AreEqual(pow, Fn.CeilingToPowerOf2(pow), pow.ToString());
                Assert.AreEqual(pow, Fn.CeilingToPowerOf2(pow - 1), pow.ToString() + "-1");
            }

            Assert.AreEqual((int.MaxValue >> 1) + 1, Fn.CeilingToPowerOf2((int.MaxValue >> 1) + 1), "Y");
            Assert.AreEqual((int.MaxValue >> 1) + 1, Fn.CeilingToPowerOf2((int.MaxValue >> 1)), "Z");
        }

        [Test]
        public void TestSpecialFunctions_Gcd()
        {
            Assert.AreEqual(0, Fn.Gcd(0, 0), "Gcd(0,0)");
            Assert.AreEqual(5, Fn.Gcd(-5, 0), "Gcd(-5,0)");
            Assert.AreEqual(6, Fn.Gcd(0, 6), "Gcd(0,6)");
            Assert.AreEqual(Int32.MaxValue, Fn.Gcd(0, Int32.MaxValue), "Gcd(0,Int32Max)");
            Assert.AreEqual(Int64.MaxValue, Fn.Gcd(0, Int64.MaxValue), "Gcd(0,Int64Max)");
            Assert.AreEqual(1, Fn.Gcd(Int32.MaxValue, Int64.MaxValue), "Gcd(Int32Max,Int64Max)");
            Assert.AreEqual(1 << 18, Fn.Gcd(1 << 18, 1 << 20), "Gcd(1>>18,1<<20)");
            Assert.AreEqual(1, Fn.Gcd(7, 13), "Gcd(7,13)");
            Assert.AreEqual(7, Fn.Gcd(7, 14), "Gcd(7,14)");
            Assert.AreEqual(1, Fn.Gcd(7, 15), "Gcd(7,15)");
            Assert.AreEqual(3, Fn.Gcd(6, 15), "Gcd(6,15)");
        }

        [Test]
        public void TestSpecialFunctions_GcdList()
        {
            Assert.AreEqual(0, Fn.Gcd(), "Gcd()");
            Assert.AreEqual(100, Fn.Gcd(-100), "Gcd(-100)");
            Assert.AreEqual(2, Fn.Gcd(-10, 6, -8), "Gcd(-10,6,-8)");
            Assert.AreEqual(1, Fn.Gcd(-10, 6, -8, 5, 9, 13), "Gcd(-10,6,-8,5,9,13)");
            Assert.AreEqual(5, Fn.Gcd(-10, 20, 120, 60, -15, 1000), "Gcd(-10,20,120,60,-15,1000)");
            Assert.AreEqual(3, Fn.Gcd(Int64.MaxValue - 1, Int64.MaxValue - 4, Int64.MaxValue - 7), "Gcd(Int64Max-1,Int64Max-4,Int64Max-7)");
            Assert.AreEqual(123, Fn.Gcd(492, -2 * 492, 492 / 4), "Gcd(492, -984, 123)");
        }

        [Test]
        public void TestSpecialFunctions_Lcm()
        {
            Assert.AreEqual(10, Fn.Lcm(10, 10), "Lcm(10,10)");
            Assert.AreEqual(Int32.MaxValue, Fn.Lcm(Int32.MaxValue, Int32.MaxValue), "Lcm(Int32Max,Int32Max)");
            Assert.AreEqual(Int64.MaxValue, Fn.Lcm(Int64.MaxValue, Int64.MaxValue), "Lcm(Int64Max,Int64Max)");
            Assert.AreEqual(Int64.MaxValue, Fn.Lcm(-Int64.MaxValue, -Int64.MaxValue), "Lcm(-Int64Max,-Int64Max)");
            Assert.AreEqual(Int64.MaxValue, Fn.Lcm(-Int64.MaxValue, Int64.MaxValue), "Lcm(-Int64Max,Int64Max)");

            Assert.AreEqual(0, Fn.Lcm(0, 10), "Lcm(0,10)");
            Assert.AreEqual(0, Fn.Lcm(10, 0), "Lcm(10,0)");

            Assert.AreEqual(77, Fn.Lcm(11, 7), "Lcm(11,7)");
            Assert.AreEqual(33, Fn.Lcm(11, 33), "Lcm(11,33)");
            Assert.AreEqual(374, Fn.Lcm(11, 34), "Lcm(11,34)");
            Assert.AreEqual(352, Fn.Lcm(11, -32), "Lcm(11,-32)");
        }

        [Test]
        public void TestSpecialFunctions_LcmList()
        {
            Assert.AreEqual(1, Fn.Lcm(), "Lcm()");
            Assert.AreEqual(100, Fn.Lcm(-100), "Lcm(-100)");
            Assert.AreEqual(120, Fn.Lcm(-10, 6, -8), "Lcm(-10,6,-8)");
            Assert.AreEqual(4680, Fn.Lcm(-10, 6, -8, 5, 9, 13), "Lcm(-10,6,-8,5,9,13)");
            Assert.AreEqual(3000, Fn.Lcm(-10, 20, 120, 60, -15, 1000), "Lcm(-10,20,120,60,-15,1000)");
            Assert.AreEqual(984, Fn.Lcm(492, -2 * 492, 492 / 4), "Lcm(492, -984, 123)");
            Assert.AreEqual(2016, Fn.Lcm(32, 42, 36, 18), "Lcm(32,42,36,18)");
            Assert.AreEqual(2016, Fn.Lcm(32, 42, 36, 18), "Lcm(32,42,36,18)");
        }

        [Test]
        public void TestSpecialFunctions_Gamma()
        {
            // ensure poles return NaN
            Assert.IsTrue(double.IsNaN(Fn.Gamma(0.0)), "A1");
            Assert.IsTrue(double.IsNaN(Fn.Gamma(-1.0)), "A2");
            Assert.IsTrue(double.IsNaN(Fn.Gamma(-2.0)), "A3");
            Assert.IsTrue(double.IsNaN(Fn.Gamma(-20.0)), "A4");
            Assert.IsFalse(double.IsNaN(Fn.Gamma(-20.0000000001)), "A4b");

            // Compare Gamma with Maple: "evalf(GAMMA(x),20);"
            NumericAssert.AreAlmostEqual(999.42377248459546611, Fn.Gamma(0.001), 1e-15, "B1");
            NumericAssert.AreAlmostEqual(99.432585119150603714, Fn.Gamma(0.01), 1e-14, "B2");
            NumericAssert.AreAlmostEqual(9.5135076986687318363, Fn.Gamma(0.1), 1e-13, "B3");
            NumericAssert.AreAlmostEqual(4.5908437119988030532, Fn.Gamma(0.2), 1e-13, "B4");
            NumericAssert.AreAlmostEqual(2.2181595437576882231, Fn.Gamma(0.4), 1e-13, "B5");
            NumericAssert.AreAlmostEqual(1.4891922488128171024, Fn.Gamma(0.6), 1e-13, "B6");
            NumericAssert.AreAlmostEqual(1.0686287021193193549, Fn.Gamma(0.9), 1e-14, "B7");
            NumericAssert.AreAlmostEqual(1.0005782056293586480, Fn.Gamma(0.999), 1e-15, "B8");
            NumericAssert.AreAlmostEqual(1.0, Fn.Gamma(1.0), 1e-13, "B9");
            NumericAssert.AreAlmostEqual(.99942377248459546611, Fn.Gamma(1.001), 1e-15, "B10");
            NumericAssert.AreAlmostEqual(.88622692545275801365, Fn.Gamma(1.5), 1e-14, "B11");
            NumericAssert.AreAlmostEqual(.96176583190738741941, Fn.Gamma(1.9), 1e-14, "B12");
            NumericAssert.AreAlmostEqual(1.0, Fn.Gamma(2.0), 1e-15, "B13");
            NumericAssert.AreAlmostEqual(362880.0, Fn.Gamma(10.0), 1e-12, "B14");
            NumericAssert.AreAlmostEqual(1159686.4489708177739, Fn.Gamma(10.51), 1e-12, "B15");
            NumericAssert.AreAlmostEqual(.93326215443944152682e156, Fn.Gamma(100), 1e-9, "B16");
            NumericAssert.AreAlmostEqual(-100.58719796441077919, Fn.Gamma(-0.01), 1e-14, "B17");
            NumericAssert.AreAlmostEqual(-10.686287021193193549, Fn.Gamma(-0.1), 1e-14, "B18");
            NumericAssert.AreAlmostEqual(-3.5449077018110320546, Fn.Gamma(-0.5), 1e-14, "B19");
            NumericAssert.AreAlmostEqual(4.8509571405220973902, Fn.Gamma(-1.2), 1e-14, "B20");
            NumericAssert.AreAlmostEqual(-49.547903041431840399, Fn.Gamma(-2.01), 1e-13, "B21");
            NumericAssert.AreAlmostEqual(-.10234011287149294961e-155, Fn.Gamma(-100.01), 1e-9, "B22");
        }

        [Test]
        public void TestSpecialFunctions_GammaRegularized()
        {
            /*
            Maple: P := (a,x) -> 1 - GAMMA(a,x)/GAMMA(a)
            Mathematica: GammaRegularized[a,0,x]
            */

            // Special Points
            Assert.IsTrue(Double.IsNaN(Fn.GammaRegularized(0, 0)), "(0,0) -> NaN");

            // x axis (a=0)
            NumericAssert.AreAlmostEqual(1, Fn.GammaRegularized(0, 1), "(0,1) -> 1");
            NumericAssert.AreAlmostEqual(1, Fn.GammaRegularized(0, 0.5), "(0,1/2) -> 1");
            NumericAssert.AreAlmostEqual(1, Fn.GammaRegularized(0, 0.001), "(0,1/1000) -> 1");

            // a axis (x=0)
            NumericAssert.AreAlmostEqual(0, Fn.GammaRegularized(1, 0), "(1,0) -> 0");
            NumericAssert.AreAlmostEqual(0, Fn.GammaRegularized(0.5, 0), "(1/2,0) -> 0");
            NumericAssert.AreAlmostEqual(0, Fn.GammaRegularized(0.001, 0), "(1/1000,0) -> 0");

            // various points (some with known other representation)
            NumericAssert.AreAlmostEqual(0.63212055882855767840, Fn.GammaRegularized(1, 1), "(1,1) -> 1-exp(-1)");
            NumericAssert.AreAlmostEqual(0.95678608173622775023, Fn.GammaRegularized(1, Math.PI), "(1,pi) -> 1-exp(-pi)");
            NumericAssert.AreAlmostEqual(0.84270079294971486934, Fn.GammaRegularized(0.5, 1), 1e-13, "(1/2,1) -> erf(1)");
            NumericAssert.AreAlmostEqual(0.47291074313446191487, Fn.GammaRegularized(0.5, 0.2), 1e-13, "(1/2,1/5) -> erf(sqrt(5)/5)");
            NumericAssert.AreAlmostEqual(0.62890663047730242621, Fn.GammaRegularized(0.5, 0.4), 1e-13, "(1/2,2/5) -> erf(sqrt(10)/5)");
            NumericAssert.AreAlmostEqual(0.79409678926793169113, Fn.GammaRegularized(0.5, 0.8), 1e-13, "(1/2,4/5) -> erf(sqrt(20)/5)");
            NumericAssert.AreAlmostEqual(0.70985103173698245837, Fn.GammaRegularized(0.25, 0.2), 1e-13, "(1/4,1/5)");
            NumericAssert.AreAlmostEqual(0.99999999974603714105, Fn.GammaRegularized(0.5, 20d), "(1/2,20) -> erf(2*5^(1/2))");
        }

        [Test]
        public void TestSpecialFunctions_InverseGammaRegularized()
        {
            /*
            Maple: PInv := (a,y) -> RootOf(1 - GAMMA(a,x)/GAMMA(a) - y);
            Mathematica: InverseGammaRegularized[a,0,x]
            */

            // Special Points (expected value debatable)
            Assert.IsTrue(Double.IsNaN(Fn.InverseGammaRegularized(0, 0)), "(0,0) -> NaN");

            // a axis (y=0)
            NumericAssert.AreAlmostEqual(0, Fn.InverseGammaRegularized(1, 0), "(1,0) -> 0");
            NumericAssert.AreAlmostEqual(0, Fn.InverseGammaRegularized(0.5, 0), "(1/2,0) -> 0");
            NumericAssert.AreAlmostEqual(0, Fn.InverseGammaRegularized(0.001, 0), "(1/1000,0) -> 0");

            // shifted a axis (y=1)
            Assert.IsTrue(Double.IsPositiveInfinity(Fn.InverseGammaRegularized(1, 1)), "(1,1) -> +infty");
            Assert.IsTrue(Double.IsPositiveInfinity(Fn.InverseGammaRegularized(0.5, 1)), "(1/2,1) -> +infty");
            Assert.IsTrue(Double.IsPositiveInfinity(Fn.InverseGammaRegularized(0.001, 1)), "(1/1000,1) -> +infty");

            // shifted a axis (y=1.1)
            Assert.IsTrue(Double.IsNaN(Fn.InverseGammaRegularized(1, 1.1)), "(1,1) -> NaN");
            Assert.IsTrue(Double.IsNaN(Fn.InverseGammaRegularized(0.5, 1.1)), "(1/2,1) -> NaN");
            Assert.IsTrue(Double.IsNaN(Fn.InverseGammaRegularized(0.001, 1.1)), "(1/1000,1) -> NaN");

            // y axis (a=0)
            Assert.IsTrue(Double.IsNaN(Fn.InverseGammaRegularized(0, 1)), "(0,1) -> NaN");
            Assert.IsTrue(Double.IsNaN(Fn.InverseGammaRegularized(0, 0.001)), "(0,1/1000) -> NaN");

            // various points (some with known other representation)
            NumericAssert.AreAlmostEqual(1, Fn.InverseGammaRegularized(1, 0.63212055882855767840), 1e-12, "(1,1-exp(-1)) -> 1");
            NumericAssert.AreAlmostEqual(Math.PI, Fn.InverseGammaRegularized(1, 0.95678608173622775023), 1e-12, "(1,1-exp(-pi)) -> pi");
            NumericAssert.AreAlmostEqual(1, Fn.InverseGammaRegularized(0.5, 0.84270079294971486934), 1e-12, "(1/2,erf(1)) -> 1");
            NumericAssert.AreAlmostEqual(0.2, Fn.InverseGammaRegularized(0.5, 0.47291074313446191487), 1e-12, "(1/2,erf(sqrt(1/5))) -> 1/5");
            NumericAssert.AreAlmostEqual(0.4, Fn.InverseGammaRegularized(0.5, 0.62890663047730242621), 1e-12, "(1/2,erf(sqrt(2/5))) -> 2/5");
            NumericAssert.AreAlmostEqual(0.8, Fn.InverseGammaRegularized(0.5, 0.79409678926793169113), 1e-12, "(1/2,erf(sqrt(8/5))) -> 4/5");
            NumericAssert.AreAlmostEqual(0.2, Fn.InverseGammaRegularized(0.25, 0.70985103173698245837), 1e-12, "(1/4,?) -> 4/5");
            NumericAssert.AreAlmostEqual(10, Fn.InverseGammaRegularized(0.5, 0.99999225578356895592), 1e-12, "(1/2,erf(sqrt(10))) -> 10");
            NumericAssert.AreAlmostEqual(20, Fn.InverseGammaRegularized(0.5, 0.99999999974603714105), 1e-7, "(1/2,erf(sqrt(20))) -> 20");
            NumericAssert.AreAlmostEqual(5.4137830853313661466, Fn.InverseGammaRegularized(0.5, 0.999), 1e-12, "(1/2,0.999)");
            NumericAssert.AreAlmostEqual(0.82118720757490819339, Fn.InverseGammaRegularized(0.5, 0.8), 1e-12, "(1/2,0.8)");
            NumericAssert.AreAlmostEqual(0.35416315040039690443, Fn.InverseGammaRegularized(0.5, 0.6), 1e-12, "(1/2,0.6)");
            NumericAssert.AreAlmostEqual(0.032092377333650790123, Fn.InverseGammaRegularized(0.5, 0.2), 1e-13, "(1/2,0.2)");
        }

        [Test]
        public void TestSpecialFunctions_Digamma()
        {
            // ensure poles return NaN
            Assert.IsTrue(double.IsNaN(Fn.Digamma(0.0)), "A1");
            Assert.IsTrue(double.IsNaN(Fn.Digamma(-1.0)), "A2");
            Assert.IsTrue(double.IsNaN(Fn.Digamma(-2.0)), "A3");
            Assert.IsTrue(double.IsNaN(Fn.Digamma(-20.0)), "A4");
            Assert.IsFalse(double.IsNaN(Fn.Digamma(-20.0000000001)), "A4b");

            // Compare Gamma with Maple: "evalf(Psi(x),20);"
            NumericAssert.AreAlmostEqual(-1000.5755719318103005, Fn.Digamma(0.001), 1e-15, "B1");
            NumericAssert.AreAlmostEqual(-100.56088545786867450, Fn.Digamma(0.01), 1e-15, "B2");
            NumericAssert.AreAlmostEqual(-10.423754940411076795, Fn.Digamma(0.1), 1e-15, "B3");
            NumericAssert.AreAlmostEqual(-5.2890398965921882955, Fn.Digamma(0.2), 1e-15, "B4");
            NumericAssert.AreAlmostEqual(-2.5613845445851161457, Fn.Digamma(0.4), 1e-15, "B5");
            NumericAssert.AreAlmostEqual(-1.5406192138931904148, Fn.Digamma(0.6), 1e-15, "B6");
            NumericAssert.AreAlmostEqual(-.75492694994705139189, Fn.Digamma(0.9), 1e-15, "B7");
            NumericAssert.AreAlmostEqual(-.57886180210864542646, Fn.Digamma(0.999), 1e-15, "B8");
            NumericAssert.AreAlmostEqual(-.57721566490153286061, Fn.Digamma(1.0), 1e-15, "B9");
            NumericAssert.AreAlmostEqual(-.57557193181030047147, Fn.Digamma(1.001), 1e-14, "B10");
            NumericAssert.AreAlmostEqual(.36489973978576520559e-1, Fn.Digamma(1.5), 1e-14, "B11");
            NumericAssert.AreAlmostEqual(.35618416116405971922, Fn.Digamma(1.9), 1e-15, "B12");
            NumericAssert.AreAlmostEqual(.42278433509846713939, Fn.Digamma(2.0), 1e-15, "B13");
            NumericAssert.AreAlmostEqual(2.2517525890667211076, Fn.Digamma(10.0), 1e-15, "B14");
            NumericAssert.AreAlmostEqual(2.3039997054324985520, Fn.Digamma(10.51), 1e-15, "B15");
            NumericAssert.AreAlmostEqual(4.6001618527380874002, Fn.Digamma(100), 1e-15, "B16");
            NumericAssert.AreAlmostEqual(99.406213695944404856, Fn.Digamma(-0.01), 1e-15, "B17");
            NumericAssert.AreAlmostEqual(9.2450730500529486081, Fn.Digamma(-0.1), 1e-15, "B18");
            NumericAssert.AreAlmostEqual(.36489973978576520559e-1, Fn.Digamma(-0.5), 1e-14, "B19");
            NumericAssert.AreAlmostEqual(4.8683247666271948739, Fn.Digamma(-1.2), 1e-15, "B20");
            NumericAssert.AreAlmostEqual(100.89382514365634023, Fn.Digamma(-2.01), 1e-13, "B21");
            NumericAssert.AreAlmostEqual(104.57736050326787844, Fn.Digamma(-100.01), 1e-12, "B22");
        }

        [Test]
        public void TestSpecialFunctions_Erf()
        {
            // Compare Erf with Maple: "evalf(erf(x),20);"
            Assert.AreEqual(.0, Fn.Erf(0.0), 1e-14, "A1");
            Assert.AreEqual(.11246291601828489220, Fn.Erf(0.1), 1e-14, "A2");
            Assert.AreEqual(.22270258921047845414, Fn.Erf(0.2), 1e-14, "A3");
            Assert.AreEqual(.32862675945912742764, Fn.Erf(0.3), 1e-13, "A4");
            Assert.AreEqual(.42839235504666845510, Fn.Erf(0.4), 1e-13, "A5");
            Assert.AreEqual(.52049987781304653768, Fn.Erf(0.5), 1e-13, "A6");
            Assert.AreEqual(.60385609084792592256, Fn.Erf(0.6), 1e-13, "A7");
            Assert.AreEqual(.67780119383741847298, Fn.Erf(0.7), 1e-13, "A8");
            Assert.AreEqual(.74210096470766048617, Fn.Erf(0.8), 1e-13, "A9");
            Assert.AreEqual(.79690821242283212852, Fn.Erf(0.9), 1e-13, "A10");
            Assert.AreEqual(.84270079294971486934, Fn.Erf(1.0), 1e-13, "A11");
            Assert.AreEqual(.88020506957408169977, Fn.Erf(1.1), 1e-13, "A12");
            Assert.AreEqual(.91031397822963538024, Fn.Erf(1.2), 1e-13, "A13");
            Assert.AreEqual(.99997790950300141456, Fn.Erf(3.0), 1e-13, "A14");
            Assert.AreEqual(1.0, Fn.Erf(9.0), 1e-13, "A15");
            Assert.AreEqual(1.0, Fn.Erf(100), 1e-13, "A16");
            Assert.AreEqual(-.32862675945912742764, Fn.Erf(-0.3), 1e-13, "A17");
            Assert.AreEqual(-.74210096470766048617, Fn.Erf(-0.8), 1e-13, "A18");

            // Compare ErvInverse with Maple: "erfinv := y -> RootOf(-erf(_Z)+y); evalf(erfinv(x),20);"
            Assert.AreEqual(.0, Fn.ErfInverse(0.0), 1e-14, "B1");
            Assert.AreEqual(.88855990494257687016e-1, Fn.ErfInverse(0.1), 1e-10, "B2");
            Assert.AreEqual(.17914345462129167649, Fn.ErfInverse(0.2), 1e-9, "B3");
            Assert.AreEqual(.27246271472675435562, Fn.ErfInverse(0.3), 1e-9, "B4");
            Assert.AreEqual(.37080715859355792906, Fn.ErfInverse(0.4), 1e-9, "B5");
            Assert.AreEqual(.47693627620446987338, Fn.ErfInverse(0.5), 1e-9, "B6");
            Assert.AreEqual(.59511608144999485002, Fn.ErfInverse(0.6), 1e-9, "B7");
            Assert.AreEqual(.73286907795921685222, Fn.ErfInverse(0.7), 1e-9, "B8");
            Assert.AreEqual(.90619380243682322007, Fn.ErfInverse(0.8), 1e-9, "B9");
            Assert.AreEqual(1.1630871536766740867, Fn.ErfInverse(0.9), 1e-8, "B10");
            Assert.AreEqual(2.7510639057120607961, Fn.ErfInverse(0.9999), 1e-8, "B11");
            Assert.AreEqual(3.7665625815708380738, Fn.ErfInverse(0.9999999), 1e-8, "B12");
            Assert.AreEqual(-.27246271472675435562, Fn.ErfInverse(-0.3), 1e-10, "B13");
            Assert.AreEqual(-.90619380243682322007, Fn.ErfInverse(-0.8), 1e-9, "B14");
            Assert.AreEqual(.88622715746655210457e-3, Fn.ErfInverse(0.001), 1e-12, "B15");
            Assert.AreEqual(.44311636293707267099e-2, Fn.ErfInverse(0.005), 1e-11, "B16");
        }

        [Test]
        public void TestSpecialFunctions_Beta()
        {
            // Symmetry:
            NumericAssert.AreAlmostEqual(Fn.Beta(1.0, 0.1), Fn.Beta(0.1, 1.0), "A1");
            NumericAssert.AreAlmostEqual(Fn.Beta(10.0, 0.1), Fn.Beta(0.1, 10.0), "A2");
            NumericAssert.AreAlmostEqual(Fn.Beta(1.0, 0.5), Fn.Beta(0.5, 1.0), "A3");
            NumericAssert.AreAlmostEqual(Fn.Beta(10.0, 0.5), Fn.Beta(0.5, 10.0), "A4");
            NumericAssert.AreAlmostEqual(Fn.Beta(100.0, 10.0), Fn.Beta(10.0, 100.0), "A1");

            // Compare with Maple: "evalf(Beta(0.1,x),20);", with relative accuracy
            NumericAssert.AreAlmostEqual(19.714639489050161663, Fn.Beta(0.1, 0.1), 1e-13, "B1");
            NumericAssert.AreAlmostEqual(14.599371492764829943, Fn.Beta(0.1, 0.2), 1e-13, "B2");
            NumericAssert.AreAlmostEqual(12.830598536321300437, Fn.Beta(0.1, 0.3), 1e-13, "B3");
            NumericAssert.AreAlmostEqual(10.0, Fn.Beta(0.1, 1.0), 1e-13, "B4");
            NumericAssert.AreAlmostEqual(9.0909090909090909091, Fn.Beta(0.1, 2.0), 1e-13, "B5");
            NumericAssert.AreAlmostEqual(8.1743590791584497328, Fn.Beta(0.1, 5.0), 1e-13, "B6");
            NumericAssert.AreAlmostEqual(7.5913800009109903433, Fn.Beta(0.1, 10.0), 1e-13, "B7");
            NumericAssert.AreAlmostEqual(6.0053229390929389725, Fn.Beta(0.1, 100.0), 1e-13, "B8");

            // Compare with Maple: "evalf(Beta(25.0,x),20);", with relative accuracy
            NumericAssert.AreAlmostEqual(6.9076854432998202098, Fn.Beta(25.0, 0.1), 1e-12, "C1");
            NumericAssert.AreAlmostEqual(2.4193558279880311532, Fn.Beta(25.0, 0.2), 1e-12, "C2");
            NumericAssert.AreAlmostEqual(1.1437887414566949564, Fn.Beta(25.0, 0.3), 1e-12, "C3");
            NumericAssert.AreAlmostEqual(.40000000000000000000e-1, Fn.Beta(25.0, 1.0), 1e-11, "C4");
            NumericAssert.AreAlmostEqual(.15384615384615384615e-2, Fn.Beta(25.0, 2.0), 1e-11, "C5");
            NumericAssert.AreAlmostEqual(.16841396151740979327e-5, Fn.Beta(25.0, 5.0), 1e-11, "C6");
            NumericAssert.AreAlmostEqual(.76261281522028757519e-9, Fn.Beta(25.0, 10.0), 1e-10, "C7");
            NumericAssert.AreAlmostEqual(.38445319996184968535e-27, Fn.Beta(25.0, 100.0), 1e-11, "C8");
        }

        [Test]
        public void TestSpecialFunctions_BetaRegularized()
        {
            // Maple: Ix := (x,a,b) -> int(t^(a-1)*(1-t)^(b-1),t=0..x)/Beta(a,b);

            // Compare with Maple: "evalf(Ix(x,0.2,0.2),20);", with relative accuracy
            NumericAssert.AreAlmostEqual(0.0, Fn.BetaRegularized(0.2, 0.2, 0.0), 1e-13, "A1");
            NumericAssert.AreAlmostEqual(.39272216435257082965, Fn.BetaRegularized(0.2, 0.2, 0.2), 1e-13, "A2");
            NumericAssert.AreAlmostEqual(.50000000000000000000, Fn.BetaRegularized(0.2, 0.2, 0.5), 1e-13, "A3");
            NumericAssert.AreAlmostEqual(.60727783564742917036, Fn.BetaRegularized(0.2, 0.2, 0.8), 1e-13, "A4");
            NumericAssert.AreAlmostEqual(1.0000000000000000000, Fn.BetaRegularized(0.2, 0.2, 1.0), 1e-13, "A5");

            // Compare with Maple: "evalf(Ix(x,0.6,1.2),20);", with relative accuracy
            NumericAssert.AreAlmostEqual(0.0, Fn.BetaRegularized(0.6, 1.2, 0.0), 1e-13, "B1");
            NumericAssert.AreAlmostEqual(.42540331997033591754, Fn.BetaRegularized(0.6, 1.2, 0.2), 1e-13, "B2");
            NumericAssert.AreAlmostEqual(.71641011564425207256, Fn.BetaRegularized(0.6, 1.2, 0.5), 1e-13, "B3");
            NumericAssert.AreAlmostEqual(.91373194998181983314, Fn.BetaRegularized(0.6, 1.2, 0.8), 1e-13, "B4");
            NumericAssert.AreAlmostEqual(1.0000000000000000000, Fn.BetaRegularized(0.6, 1.2, 1.0), 1e-13, "B5");

            // Compare with Maple: "evalf(Ix(x,7.0,1.2),20);", with relative accuracy
            NumericAssert.AreAlmostEqual(0.0, Fn.BetaRegularized(7.0, 1.2, 0.0), 1e-13, "C1");
            NumericAssert.AreAlmostEqual(.20126888449347947608e-4, Fn.BetaRegularized(7.0, 1.2, 0.2), 1e-13, "C2");
            NumericAssert.AreAlmostEqual(.11371092280417448678e-1, Fn.BetaRegularized(7.0, 1.2, 0.5), 1e-13, "C3");
            NumericAssert.AreAlmostEqual(.11102090346884848038, Fn.BetaRegularized(7.0, 1.2, 0.7), 1e-13, "C4");
            NumericAssert.AreAlmostEqual(.26774648551269072265, Fn.BetaRegularized(7.0, 1.2, 0.8), 1e-12, "C5");
            NumericAssert.AreAlmostEqual(.56477467605979107895, Fn.BetaRegularized(7.0, 1.2, 0.9), 1e-13, "C6");
            NumericAssert.AreAlmostEqual(.77753405618146275868, Fn.BetaRegularized(7.0, 1.2, 0.95), 1e-13, "C7");
            NumericAssert.AreAlmostEqual(1.0000000000000000000, Fn.BetaRegularized(7.0, 1.2, 1.0), 1e-13, "C8");
        }

        [Test]
        public void TestSpecialFunctions_Sinc()
        {
            // Test at integers:
            for(int i = -10; i < 10; i++)
            {
                NumericAssert.AreAlmostEqual((i == 0) ? 1.0 : 0.0, Fn.Sinc(i), "sinc(" + i.ToString() + ")");
            }
        }

        [Test]
        public void TestSpecialFunctions_Factorial()
        {
            // exact
            double factorial = 1.0;
            for(int i = 1; i < 32; i++)
            {
                factorial *= i;
                NumericAssert.AreAlmostEqual(factorial, Fn.Factorial(i), "Factorial: " + i.ToString());
            }

            // approximation
            for(int i = 32; i < 90; i++)
            {
                factorial *= i;
                NumericAssert.AreAlmostEqual(factorial, Fn.Factorial(i), 1e-10, "Factorial: " + i.ToString());
            }
        }

        [Test]
        public void TestSpecialFunctions_HarmonicNumber()
        {
            // exact
            double sum = 0.0;
            for(int i = 1; i < 32; i++)
            {
                sum += 1.0 / i;
                NumericAssert.AreAlmostEqual(sum, Fn.HarmonicNumber(i), "H" + i.ToString());
            }

            // approximation
            for(int i = 32; i < 90; i++)
            {
                sum += 1.0 / i;
                NumericAssert.AreAlmostEqual(sum, Fn.HarmonicNumber(i), 1e-10, "H" + i.ToString());
            }

            // Compare with Maple: "evalf(sum(1/k,k=1..x),20)"
            NumericAssert.AreAlmostEqual(12.090146129863427948, Fn.HarmonicNumber(100000), 1e-10, "H100000");
            NumericAssert.AreAlmostEqual(18.997896413853898325, Fn.HarmonicNumber(100000000), 1e-10, "H100000000");
        }
    }
}
