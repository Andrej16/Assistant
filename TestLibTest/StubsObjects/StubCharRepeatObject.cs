using Assistant.Core;
using System.Collections.Generic;

namespace TestLibTest.StubsObjects
{
    class StubCharRepeatObject : IStub
    {
        public object DoSomeAction(object arg)
        {
            Dictionary<char, short> verificationObject = new Dictionary<char, short>()
            {
                { 'c', 5 },
                { 'h', 2 },
                { 'a', 3}
            };
            return verificationObject;
        }
    }
}
