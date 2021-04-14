using NUnit.Framework;
using Problems;

namespace NUnitTestProblems
{
    public class LitCodeProblemsTest
    {
        private int _isPolindrome;
        private int _isNotPolindrome;
        [OneTimeSetUp]
        public void Setup()
        {
            _isPolindrome = 1221;
            _isNotPolindrome = 123;
        }

        [Test]
        public void IsPalindromeTest()
        {
            Assert.IsTrue(LitCodeProblems.IsPalindrome(_isPolindrome));
            Assert.IsFalse(LitCodeProblems.IsPalindrome(_isNotPolindrome));
        }
        [Test]
        public void IsPalindromeTest2()
        {
            Assert.IsTrue(LitCodeProblems.IsPalindrome(_isPolindrome));
            Assert.IsFalse(LitCodeProblems.IsPalindrome(_isNotPolindrome));
        }

    }
}