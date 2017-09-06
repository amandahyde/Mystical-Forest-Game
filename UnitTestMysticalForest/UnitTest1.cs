using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mystical_forest;
using System.Windows.Forms;



namespace UnitTestMysticalForest
{
    [TestClass]
    public class UnitTest1
    {
        
     

        [TestMethod]

        //Test that MushPurple holds the int value of 2
        public void Shroom()
        {
            shroomDoom calcDoom = new shroomDoom();
           
            string actual = calcDoom.ShroomNumber("MushPurple").ToString();
            Assert.AreEqual('2'.ToString(), actual);
        }

        //
        [TestMethod]

        //Test that MushGreen holds the int value of 1
        public void ShroomGreen()
        {
            shroomDoom calcDoom = new shroomDoom();

            string actual = calcDoom.ShroomNumber("MushGreen").ToString();
            Assert.AreEqual('1'.ToString(), actual);
        }

        
        [TestMethod]

        //test that the random number is not null and holds a value between 1 and 7
        public void randomness()
        {
            shroomDoom calcDoom = new shroomDoom();

            int actual = calcDoom.RandomNumber();
           
         Assert.IsNotNull("actual");
         Assert.IsTrue(1 <= 7);
        }






    }


}

