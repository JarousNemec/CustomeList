using System;
using CustomeList;
using NUnit.Framework;

namespace CustomeListTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Initialization()
        {
            CustomeList<int> list = new CustomeList<int>();
            Assert.AreEqual(list.Capacity, 2);
            Assert.AreEqual(list.Count, 0);
        }

        [Test]
        public void AddItem()
        {
            CustomeList<int> list = new CustomeList<int>();
            try
            {
                list.Add(5);
                list.Add(5);
                list.Add(5);
                list.Add(5);
                list.Add(5);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void GetItemAt()
        {
            CustomeList<int> list = new CustomeList<int>();
            list.Add(3);
            list.Add(5);
            Assert.AreEqual(list[1], 5);
        }

        [Test]
        public void ListToString()
        {
            CustomeList<int> list = new CustomeList<int>();
            list.Add(3);
            list.Add(5);
            list.Add(9);
            list.Add(92);
            Assert.True(list.ToString() == "35992");
        }

        [Test]
        public void ClearList()
        {
            CustomeList<string> list = new CustomeList<string>();
            list.Add("3");
            list.Add("5");
            list.Add("3");
            list.Add("5");
            list.Clear();
            Assert.AreEqual(list.ToString(), string.Empty);
            Assert.AreEqual(list.Count, 0);
        }

        [Test]
        public void GetEnumerator()
        {
            CustomeList<int> list = new CustomeList<int>();
            int temp = 0;
            int goal = 0;
            do
            {
                goal += temp;
                list.Add(temp++);
            } while (goal < 100);

            temp = 0;
            foreach (var t in list)
            {
                temp += t;
                Console.WriteLine(t);
            }
            Assert.AreEqual(goal,temp);
        }

        [Test]
        public void IndexOf()
        {
            CustomeList<string> names = new CustomeList<string>() { "Pepa", "Karel", "Zdeněk","Milan","Petr"};
            Assert.AreEqual(3,names.IndexOf("Milan"));
        }

        [Test]
        public void Insert()
        {
            CustomeList<string> list = new CustomeList<string>() { "1","2","3","4" };
            int before = list.Count;
            list.Insert(2,"8");
            Assert.AreEqual(before+1,list.Count);
            Assert.AreEqual("8",list[2]);
            Assert.AreEqual("12834",list.ToString());
        }
    }
}