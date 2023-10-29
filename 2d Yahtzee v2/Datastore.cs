using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2d_Yahtzee_v2
{

    public class Datastore
    {


        public string playerName { get; set; }
        public int diceButtonCount { get; set; }
        public bool highscore;
        public Dictionary<string, Int32> highScores = new Dictionary<string, Int32>();
        public bool musicplay = true;

    }

}
