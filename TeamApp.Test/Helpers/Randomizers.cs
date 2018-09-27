using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Test.Helpers
{
    public class GameTestRandom:Random
    {
        int[] results = { 0, 0, 0, 0, 0, 0 };
        int current = 0;        

        public GameTestRandom(int[] results)
        {
            this.results = results;
        }

        //will fail if you didn't populate enough numbers!
        public override int Next(int maxValue)
        {
            var result = results[current];
            current++;
            return result;
        }
    }
}
