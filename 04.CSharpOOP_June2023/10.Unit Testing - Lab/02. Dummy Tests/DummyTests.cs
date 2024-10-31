using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(1);

            Assert.That(dummy.Health, Is.EqualTo(9), "Dummy doesn't change health when being attacked.");
        }
        [Test]
        public void DeadDummyShouldThrowAnExceptionIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>( () => dummy.TakeAttack(10), "Dummy is dead.");
        }
        [Test]
        public void GiveExpShouldReturnCurrentExpIfDummyIsDead()
        {
            Dummy dummy = new Dummy(100, 100);

            dummy.TakeAttack(50);
            dummy.TakeAttack(50);

            Assert.AreEqual(100, dummy.GiveExperience());
        }
        [Test]
        public void AliveDummyCannotGiveExp()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }
    }
}