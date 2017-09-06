using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mystical_forest
{
   public class shroomDoom
    {//fields


        //properties  
        public int Poison  { get; set; }
        public int Eat { get; set; }
    
        public int Discard { get; set; }
  
        public int EATSHROOM { get; set; }

        public int losses { get; set; }

        public int wins { get; set; }

        

    //METHODS


        //generates random number between 1 and 7
    public int RandomNumber()
        {
           Random myrnd = new Random(DateTime.Now.Millisecond);
                return myrnd.Next(1, 7);
            }


        //adds count to eat variable
        public int EAT()
        {

            int eat = 0;
            eat++;
            return eat;
            
        }

      
        // adds count to discard variable
        public int DISCARD(string discardText)
        {

            int discard = 0;
            discard = Convert.ToInt16(discardText);
            discard++;
            return discard;

 

        }


        //assigns numerical value to each shroom

        public int ShroomNumber(string name)
        {
            if (name == "MushGreen")
            {
                return 1;
            }

            if (name == "MushPurple")

            {
                return 2;
            }

            if (name == "MushCyan")
            {
                return 3;
            }

            if (name == "MushRed")
            {
                return 4;
            }

            if (name == "MushBlue")

            {
                return 5;
            }

            if (name == "MushPink")

            {
                return 6;
            }

            return 0;
        }

    


        public string EatShroom(int shroom, string poisonText)
        {
            int poison = Convert.ToInt16(poisonText);
            return Convert.ToString(shroom);
          

        }

     





    }
}
