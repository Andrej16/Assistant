using Assistant.Core;
using TestLib.Controllers;
using TestLibTest.StubsObjects;
using Xunit;

namespace TestLibTest
{
    public class TesterTest
    {
        [Fact]
        public void CharRepeat_ShouldBe_ReturnTrue()
        {
            Tester tester = new Tester(null);
            tester.Stub = new StubCharRepeatObject();
            tester.Origin = new CharRepeat();

            Assert.True(tester.CharRepeatComparator("hccchccaaa"));
        }
    }
}
