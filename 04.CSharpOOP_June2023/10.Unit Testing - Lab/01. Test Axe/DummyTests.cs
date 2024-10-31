using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthIfAttacked()
        {
            Dummy dummy = new Dummy(100, 10);

            dummy.TakeAttack(10);

            Assert.That(dummy.Health, Is.EqualTo(90));
        }

        [Test]
        public void DeadDummyShoudlThrowAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10), "Dummy is dead.");
        }
    }
}