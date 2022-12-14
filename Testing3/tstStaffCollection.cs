using System;
using System.Collections.Generic;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing3
{
    [TestClass]
    public class tstStaffCollection
    {
        [TestMethod]
        public void InstanceOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            Assert.IsNotNull(AllStaff);
        }
        [TestMethod]
        public void StaffListOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            List<clsStaff> TestList = new List<clsStaff>();

            clsStaff TestItem = new clsStaff();
            TestItem.StaffId = 101;
            TestItem.FirstName = "Joe";
            TestItem.LastName = "Bennet";
            TestItem.EmailAddress = "jb@email.com";
            TestItem.HomeAddress = "101 Joe Ln, LE1 101";
            TestItem.StartDate = DateTime.Now.Date;
            TestItem.IsWorking = true;

            TestList.Add(TestItem);
            AllStaff.StaffList = TestList;
            Assert.AreEqual(AllStaff.StaffList, TestList);
        }
        [TestMethod]
        public void ThisStaffMemberOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();

            clsStaff TestStaff = new clsStaff();
            TestStaff.StaffId = 101;
            TestStaff.FirstName = "Joe";
            TestStaff.LastName = "Bennet";
            TestStaff.EmailAddress = "jb@email.com";
            TestStaff.HomeAddress = "101 Joe Ln, LE1 101";
            TestStaff.StartDate = DateTime.Now.Date;
            TestStaff.IsWorking = true;

            AllStaff.ThisStaffMember = TestStaff;
            Assert.AreEqual(AllStaff.ThisStaffMember, TestStaff);
        }
        [TestMethod]
        public void ListAndCountOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            List<clsStaff> TestList = new List<clsStaff>();

            clsStaff TestItem = new clsStaff();
            TestItem.StaffId = 101;
            TestItem.FirstName = "Joe";
            TestItem.LastName = "Bennet";
            TestItem.EmailAddress = "jb@email.com";
            TestItem.HomeAddress = "101 Joe Ln, LE1 101";
            TestItem.StartDate = DateTime.Now.Date;
            TestItem.IsWorking = true;

            TestList.Add(TestItem);
            AllStaff.StaffList = TestList;
            Assert.AreEqual(AllStaff.Count, TestList.Count);
        }
        [TestMethod]
        public void AddMethodOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestItem = new clsStaff();
            Int32 PrimaryKey = 0;
            //setting properties
            TestItem.StaffId = 73571;
            TestItem.FirstName = "Joe";
            TestItem.LastName = "Bennet";
            TestItem.EmailAddress = "jb@email.com";
            TestItem.HomeAddress = "101 Joe Ln, LE1 101";
            TestItem.StartDate = DateTime.Now.Date;
            TestItem.IsWorking = true;
            //setting ThisStaffMember to the test data
            AllStaff.ThisStaffMember = TestItem;
            //adding the record
            PrimaryKey = AllStaff.Add();
            //setting the primary key of the test data
            TestItem.StaffId = PrimaryKey;
            //find the record
            AllStaff.ThisStaffMember.Find(PrimaryKey);
            Assert.AreEqual(AllStaff.ThisStaffMember, TestItem);
        }
        [TestMethod]
        public void UpdateMethodOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestItem = new clsStaff();
            Int32 PrimaryKey = 0;
            //setting properties
            TestItem.StaffId = 7357;
            TestItem.FirstName = "Joe";
            TestItem.LastName = "Bennet";
            TestItem.EmailAddress = "jb@email.com";
            TestItem.HomeAddress = "101 Joe Ln, LE1 101";
            TestItem.StartDate = DateTime.Now.Date;
            TestItem.IsWorking = true;
            //setting ThisStaffMember to the test data
            AllStaff.ThisStaffMember = TestItem;
            //adding the record
            PrimaryKey = AllStaff.Add();
            TestItem.StaffId = PrimaryKey;
            //modifying the test data
            TestItem.FirstName = "Jack";
            TestItem.LastName = "Deck";
            TestItem.EmailAddress = "jd@email.com";
            TestItem.HomeAddress = "102 Jack Ln, LE1 102";
            TestItem.StartDate = DateTime.Now.Date;
            TestItem.IsWorking = false;
            //setting the record based on the new test data
            AllStaff.ThisStaffMember = TestItem;
            //updating the record
            AllStaff.Update();
            //fiding the record
            AllStaff.ThisStaffMember.Find(PrimaryKey);
            //testing
            Assert.AreEqual(AllStaff.ThisStaffMember, TestItem);
        }
        [TestMethod]
        public void DeleteMethodOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            clsStaff TestItem = new clsStaff();
            Int32 PrimaryKey = 0;
            //setting properties
            TestItem.FirstName = "Jason";
            TestItem.LastName = "Pratchet";
            TestItem.EmailAddress = "jp@email.com";
            TestItem.HomeAddress = "303 Pratt Ln, LE1 303";
            TestItem.StartDate = DateTime.Now.Date;
            TestItem.IsWorking = true;
            //setting ThisStaffMember to the test data
            AllStaff.ThisStaffMember = TestItem;
            //adding the record
            PrimaryKey = AllStaff.Add();
            //setting the primary key of the test data
            TestItem.StaffId = PrimaryKey;
            //finding the record
            AllStaff.ThisStaffMember.Find(PrimaryKey);
            //deleting the record
            AllStaff.Delete();
            //finding the record again
            Boolean Found = AllStaff.ThisStaffMember.Find(PrimaryKey);
            Assert.IsFalse(Found);
        }
        [TestMethod]
        public void ReportByLastNameMethodOK()
        {
            clsStaffCollection AllStaff = new clsStaffCollection();
            // creating an instance of filtered data
            clsStaffCollection FilteredStaff = new clsStaffCollection();
            //apply a blank string
            FilteredStaff.ReportByLastName("");
            Assert.AreEqual(AllStaff.Count, FilteredStaff.Count);
        }
        [TestMethod]
        public void ReportByLastNameNoneFound()
        {
            clsStaffCollection FilteredStaff = new clsStaffCollection();
            FilteredStaff.ReportByLastName("xxxxx");
            Assert.AreEqual(0, FilteredStaff.Count);
        }
        [TestMethod]
        public void ReportByLastNameTestDataFound()
        {
            clsStaffCollection FilteredStaff = new clsStaffCollection();
            Boolean OK = true;
            FilteredStaff.ReportByLastName("Bziuk");
            if(FilteredStaff.Count == 2)
            {
                if(FilteredStaff.StaffList[0].StaffId != 1)
                {
                    OK = false;
                }
                if(FilteredStaff.StaffList[1].StaffId != 73572)
                {
                    OK = false;
                }
            }
            else
            {
                OK = false;
            }
            Assert.IsTrue(OK);
        }
    }
}
