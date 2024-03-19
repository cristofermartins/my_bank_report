using System;

namespace Processors.Taggers
{
    public class TaggerTest
    {
        public bool Test(string testString)
        {
            if (testString.ToLower().Contains(TextSub.ToLower()))
            {
                return true;
            }

            return false;
        }
        public string Name {get; init;} = "";
        public string TextSub {get; init;} = "";
    }
}
