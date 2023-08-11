using NUnit.Framework;

namespace CGTest.Tests
{
    public class AttackCalculationTest 
    {
        [Test]
        public void TestDamageCalculation()
        {
            float damage = AttackCalculatorHandler.CalcDamage(50, 50);
            Assert.AreEqual(damage, 25);
            damage = AttackCalculatorHandler.CalcDamage(500, 101);
            Assert.AreEqual(damage, 0);
        }
        
        [Test]
        public void TestAppliedDamageCalculation()
        {
            float damage = AttackCalculatorHandler.CalcAppliedDamage(100, 50);
            Assert.AreEqual(damage, 50);
        }
        
        [Test]
        public void TestVampHPCalculation()
        {
            float damage = AttackCalculatorHandler.CalcVampHP(50, 10);
            Assert.AreEqual(damage, 5);
        }
    }
}