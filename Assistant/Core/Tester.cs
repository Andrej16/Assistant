using System;
using System.Collections.Generic;

namespace Assistant.Core
{
    public class Tester
    {
        public ITestLib Test { get; set; }
        private IStub _stub;
        private IStub _origin;

        public IStub Stub
        {
            set { _stub = value; }
            get
            {
                return _stub ?? throw new MemberAccessException("Stub has not been initialized.");
            }
        }

        public IStub Origin
        {
            set { _origin = value; }
            get
            {
                return _origin ?? throw new MemberAccessException("Origin has not been initialized.");
            }
        }

        public Tester(ITestLib tl)
        {
            Test = tl;
        }
        public void DoTest()
        {
            Test.DoAction();
        }
        /// <summary>
        /// Используется для проверки юнит тестов
        /// </summary>
        public bool CharRepeatComparator(string input)
        {

            Dictionary<char, short> generated = Stub.DoSomeAction(null) as Dictionary<char, short>;
            Dictionary<char, short> result = Origin.DoSomeAction(input) as Dictionary<char, short>;

            if (generated.Count != result.Count)
                return false;

            foreach (var r in result)
            {
                short value;
                if(generated.TryGetValue(r.Key, out value))
                {
                    if (value != r.Value)
                        return false;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}
