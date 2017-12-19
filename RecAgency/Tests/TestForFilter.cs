using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;
using RecAgency.Models;
namespace RecAgency.Tests
{
    [TestFixture]
    public class TestForFilter
    {
        [Test]
        public void EachField()
        {
            List<Vacancy> inp = new List<Vacancy>();
            List<Vacancy> outp = new List<Vacancy>();
            Vacancy vac = new Vacancy();
            vac.Info = "abcde a";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "";
            vac.Field = "zxcvb a";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "";
            vac.Field = "";
            vac.Name = "asdfg a";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "poiu76 a";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "mnbvc a";
            inp.Add(vac);
            outp.Add(vac);
            Filters f = new Filters();
            Assert.That(outp, Is.EquivalentTo(f.ForKeyWords(inp,"a")));
        }

        [Test]
        public void Register()
        {
            List<Vacancy> inp = new List<Vacancy>();
            List<Vacancy> outp = new List<Vacancy>();
            Filters f = new Filters();
            Vacancy vac = new Vacancy();
            vac.Info = "FORECAST";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            Assert.That(outp, Is.EquivalentTo(f.ForKeyWords(inp, "forecast")));
        }

        [Test]
        public void IntoCompoundWord()
        {
            List<Vacancy> inp = new List<Vacancy>();
            List<Vacancy> outp = new List<Vacancy>();
            Filters f = new Filters();
            Vacancy vac = new Vacancy();
            vac.Info = "forforecastnice";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            Assert.That(outp, Is.EquivalentTo(f.ForKeyWords(inp, "forecast")));
        }

        [Test]
        public void ManyWords()
        {
            List<Vacancy> inp = new List<Vacancy>();
            List<Vacancy> outp = new List<Vacancy>();
            Filters f = new Filters();
            Vacancy vac = new Vacancy();
            vac.Info = "forecast and good night";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "forecast";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "GOOD";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "not here";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            inp.Add(vac);
            Assert.That(outp, Is.EquivalentTo(f.ForKeyWords(inp, "forecast good")));
        }

        [Test]
        public void ManyFields()
        {
            List<Vacancy> inp = new List<Vacancy>();
            List<Vacancy> outp = new List<Vacancy>();
            Filters f = new Filters();
            Vacancy vac = new Vacancy();
            vac = new Vacancy();
            vac.Info = "forecast";
            vac.Field = "no";
            vac.Name = "in";
            vac.Schedule = "some";
            vac.Organization = "words";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "in";
            vac.Field = "no";
            vac.Name = "good";
            vac.Schedule = "some";
            vac.Organization = "words";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "in";
            vac.Field = "no";
            vac.Name = "in";
            vac.Schedule = "good";
            vac.Organization = "words";
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "in";
            vac.Field = "no";
            vac.Name = "property";
            vac.Schedule = "some";
            vac.Organization = "words";
            inp.Add(vac);
            Assert.That(outp, Is.EquivalentTo(f.ForKeyWords(inp, "forecast good")));
        }

        [Test]
        public void ForSalary()
        {
            List<Vacancy> inp = new List<Vacancy>();
            List<Vacancy> outp = new List<Vacancy>();
            Filters f = new Filters();
            Vacancy vac = new Vacancy();
            vac.Salary = 3000;
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Salary = 1000;
            inp.Add(vac);
            Assert.That(outp, Is.EquivalentTo(f.ForSalary(inp, 2000)));
        }

        [Test]
        public void CombiFilters()
        {
            List<Vacancy> inp = new List<Vacancy>();
            List<Vacancy> outp = new List<Vacancy>();
            Filters f = new Filters();
            Vacancy vac = new Vacancy();
            vac.Info = "in";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            vac.Salary = 5000;
            inp.Add(vac);
            outp.Add(vac);
            vac = new Vacancy();
            vac.Info = "in";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            vac.Salary = 1000;
            inp.Add(vac);
            vac = new Vacancy();
            vac.Info = "";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            vac.Salary = 5000;
            inp.Add(vac);
            vac = new Vacancy();
            vac.Info = "";
            vac.Field = "";
            vac.Name = "";
            vac.Schedule = "";
            vac.Organization = "";
            vac.Salary = 1000;
            inp.Add(vac);
            Assert.That(outp, Is.EquivalentTo(f.ForKeyWords(f.ForSalary(inp, 2000), "in")));
        }

    }
}