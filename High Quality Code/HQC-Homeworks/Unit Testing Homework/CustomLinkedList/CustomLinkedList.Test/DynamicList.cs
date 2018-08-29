namespace CustomLinkedList.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DynamicList
    {
        private DynamicList<int> _list;

        [TestInitialize]
        public void InitTest()
        {
            this._list = new DynamicList<int>();
        }

        [TestMethod]
        public void TestAddingElement_ReturnsItemAtIndex()
        {
            this._list.Add(5);
            Assert.AreEqual(5, this._list[0],
                "The number in the list isnt the same as the one given.");
        }

        [TestMethod]
        public void TestAddingElement_IncrementsCount()
        {
            this._list.Add(75);
            this._list.Add(65);
            Assert.AreEqual(2,this._list.Count,
                "The Count doesnt increment correctly.");
        }

        [TestMethod]
        public void TestAddingFewElements_SetsHeadCorrectly()
        {
            this._list.Add(75);
            this._list.Add(65);
            this._list.Add(55);
            this._list.Add(45);
            Assert.AreEqual(75,this._list[0], 
                "The head isnt setted correctly.");
            
        }

        [TestMethod]
        public void TestAddingFewElements_SetsTailCorrectly()
        {
            this._list.Add(75);
            this._list.Add(65);
            this._list.Add(55);
            this._list.Add(45);
            Assert.AreEqual(45,this._list[this._list.Count - 1],
                "The tail isnt setted correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTryingToAccessNonExistingMember_ThrowsException()
        {
            this._list[80] = 5;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestTryingToRemoveElementAtInvalidPos_ThrowsException()
        {
            this._list.RemoveAt(85);
        }

        [TestMethod]
        public void TestTryingToRemoveElementAtPos_SuccessfullyReturnsTheRemovedElement()
        {
            this._list.Add(5);
            this._list.Add(6);
            this._list.Add(7);

            var removedValue = this._list.RemoveAt(1);

            Assert.AreEqual(6,removedValue,"RemoveAt returns wrong value.");
        }

        [TestMethod]
        public void TestRemovingElement_ReturnsTheIndexOfTheRemovedEle()
        {
            this._list.Add(5);
            this._list.Add(6);
            this._list.Add(7);

            var indexOfRemovedVal = this._list.Remove(6);

            Assert.AreEqual(1,indexOfRemovedVal,"Wrong index returned.");
        }

        [TestMethod]
        public void TestRemovingNonExistentElement_ReturnesMinus1()
        {
            this._list.Add(5);

            var indexOfRemovedElement = this._list.Remove(6);

            Assert.AreEqual(-1,indexOfRemovedElement, "Should return -1.");
        }

        [TestMethod]
        public void TestRemovingElement_ShouldDecrementCount()
        {
            this._list.Add(5);
            this._list.Add(6);

            this._list.Remove(5);

            Assert.AreEqual(1, this._list.Count, "Count should be equal to 1.");
        }

        [TestMethod]
        public void TestIndexOfGivenItem_ReturnedProperly()
        {
            this._list.Add(5);
            this._list.Add(6);

            var indexReturned = this._list.IndexOf(6);

            Assert.AreEqual(1,indexReturned, "Wrong index returned");
        }

        [TestMethod]
        public void TestIndexOfGivenItem_IsTheFirstOccurance()
        {
            this._list.Add(6);
            this._list.Add(6);
            this._list.Add(6);

            var indexReturned = this._list.IndexOf(6);

            Assert.AreEqual(0,indexReturned,"Wrong index returned.");
        }

        [TestMethod]
        public void TestIndexOfGivenItem_ReturnesMinus1IfNonExistingItemIsGiven()
        {
            this._list.Add(7);

            var indexReturned = this._list.IndexOf(6);

            Assert.AreEqual(-1,indexReturned,"Should return -1.");
        }

        [TestMethod]
        public void TestContains_ReturnTrueIfItemFound()
        {
            this._list.Add(5);

            var contains5 = this._list.Contains(5);

            Assert.IsTrue(contains5,
                "The method returns false when true is expected.");
        }

        [TestMethod]
        public void TestContains_ReturnFalseIfItemNotFound()
        {
            this._list.Add(5);

            var contains5 = this._list.Contains(6);

            Assert.IsFalse(contains5,
                "The method returns flase when true is expected.");
        }



    }
}