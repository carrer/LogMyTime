using LogMyTime;
using LogMyTime.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LogMyTimeUnitTests
{
    [TestClass]
    public class TimeCardTest
    {
        [TestMethod]
        public void ShouldInitializeVariables()
        {
            TimeCard card = new TimeCard(new DateTime());
            Assert.AreEqual<int>(0, card.Strokes);
            Assert.AreEqual<int>(0, card.Clicks);
            Assert.AreEqual<int>(0, card.Apps.Count);
        }

        [TestMethod]
        public void ShouldCountApplications()
        {
            ProgramInfo program = new ProgramInfo("test", "test", "test");
            ProgramInfo program2 = new ProgramInfo("test2", "test2", "test2");
            TimeCard card = new TimeCard(new DateTime());
            for (int i = 0; i < 10; i++)
            {
                card.CountApp(program);
                for (int j = 0; j < 3; j++)
                    card.CountApp(program2);
            }

//            Assert.AreEqual<int>(10, card.Applications.Count);
//           Assert.AreEqual<int>(30, card.Applications.Count);
            Assert.AreEqual<int>(2, card.Apps.Count);
        }

        [TestMethod]
        public void ShouldNotCountNullApplications()
        {
            TimeCard card = new TimeCard(new DateTime());
            card.CountApp(null);
            Assert.AreEqual<int>(0, card.Apps.Count);
        }


        [TestMethod]
        public void ShouldMergeTwoCards()
        {
            TimeCard card = new TimeCard(new DateTime());
            TimeCard card2 = new TimeCard(card.GetDateTimeEnd());

            ProgramInfo program = new ProgramInfo("test", "test", "test");

            card.Strokes = 5;
            card2.Strokes = 10;
            card.Clicks = 1;
            card2.Clicks = 2;

            for (int i = 0; i < 10; i++)
            {
                card.CountApp(program);
                card2.CountApp(program);
            }

            for (int i = 0; i < 10; i++)
                card2.CountApp(program);

            card.Merge(card2);

            Assert.AreEqual<int>(15, card.Strokes);
            Assert.AreEqual<int>(3, card.Clicks);
//            Assert.AreEqual<int>(30, card.Applications[program.Key()].Count);
            Assert.AreEqual<string>(card2.End, card.End);
        }

        [TestMethod]
        public void ShouldMergeTwoCardsHandleDates()
        {
            TimeCard card = new TimeCard(new DateTime());
            TimeCard card2 = new TimeCard(card.GetDateTimeEnd());

            card2.Merge(card);

            Assert.AreEqual<string>(card2.Start, card.Start);
        }

        [TestMethod]
        public void ShouldSerialize()
        {
            ProgramInfo prog = new ProgramInfo("Name", "Path", "Title");
            TimeCard card = new TimeCard();
            card.CountApp(prog);
            card.Clicks = 1;
            card.Strokes = 2;

            var xmlserializer = new XmlSerializer(card.GetType());
            var stringWriter = new StringWriter();
            string output;
            using (var writer = XmlWriter.Create(stringWriter))
            {
                xmlserializer.Serialize(writer, card);
                output = stringWriter.ToString();
            }

            Assert.IsTrue(output.Contains("<Name>Name</Name>"));
            Assert.IsTrue(output.Contains("<AbsolutePath>Path</AbsolutePath>"));
            Assert.IsTrue(output.Contains("<Title>Title</Title>"));
        }

        [TestMethod]
        public void ShouldSetGetApplications()
        {
            List<Counter> list = new List<Counter>();
            list.Add(new Counter(new ProgramInfo("teste", "teste", "teste")));
            list.Add(new Counter(new ProgramInfo("teste", "teste", "teste")));
            list.Add(new Counter(new ProgramInfo("teste", "teste", "teste")));
            TimeCard card = new TimeCard();
            card.Apps = list;

            List<Counter> list2 = card.Apps;

            Assert.AreEqual<int>(3, list.Count);
            Assert.AreEqual<int>(1, list2.Count);
            Assert.AreEqual<int>(3, list2[0].Count);
            Assert.AreEqual<string>(list[0].Reference.Name, list2[0].Reference.Name);
        }
    }
}