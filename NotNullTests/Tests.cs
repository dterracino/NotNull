using NotNull;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotNullTests
{
    public class Tests
    {
        [Test]
        public void ShouldNotBeAbleToAssignNullToNotNull()
        {
            NotNull<Person> notNullPerson;
            Assert.Throws<NullReferenceException>(() => notNullPerson = null);
        }

        [Test]
        public void ShouldBeAbleToAssignInstanceToNotNull()
        {
            NotNull<Person> notNullPerson;
            notNullPerson = new Person();
        }

        [Test]
        public void ShouldNeverBeAbleToAssignNullToNotNull()
        {
            NotNull<Person> notNullPerson;
            notNullPerson = new Person() { Name = "Jake" };
            notNullPerson = new Person() { Name = "Ed" };
            Assert.Throws<NullReferenceException>(() => notNullPerson = null);
        }

        [Test]
        public void ShouldNotBeAbleToAssignNullToNotNullFromMethod()
        {
            NotNull<Person> notNullPerson;
            Assert.Throws<NullReferenceException>(() => notNullPerson = GetNullPerson());
        }

        [Test]
        public void ShouldBeAbleToAssignInstanceToNotNullMethod()
        {
            NotNull<Person> notNullPerson;
            notNullPerson = GetPerson();
        }

        [Test]
        public void ShouldImplicitCastToParameterNotNull()
        {
            var person = new Person { Name = "Jake" };
            WriteNameNotNull(person);
        }

        [Test]
        public void ShouldBeAbleToExplictAndImplicCastToNotNull_Null()
        {
            Person person;
            Assert.Throws<NullReferenceException>(() => person = (NotNull<Person>)GetNullPerson());
        }

        [Test]
        public void ShouldBeAbleToExplictAndImplicCastToNotNull_NotNull()
        {
            Person person = (NotNull<Person>)GetPerson();
        }

        [Test]
        public void ShouldBeAbleToUseNotNullExtension_NotNull()
        {
            Person person = GetPerson().NotNull();
        }

        [Test]
        public void ShouldBeAbleToUseNotNullExtension_Null()
        {
            Person person;
            Assert.Throws<NullReferenceException>(() => person = GetNullPerson().NotNull());
        }

        private Person GetNullPerson()
        {
            return null;
        }

        private Person GetPerson()
        {
            return new Person { Name = "John" };
        }

        private NotNull<Person> GetNotNullPerson()
        {
            return new Person { Name = "Steve" };
        }

        private static void WriteName(Person person)
        {
            Console.WriteLine(person.Name);
        }

        private static void WriteNameNotNull(NotNull<Person> notNullPerson)
        {
            Console.WriteLine(notNullPerson.Value.Name);
        }
    }
}
