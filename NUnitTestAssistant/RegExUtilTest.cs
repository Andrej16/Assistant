using Assistant;
using NUnit.Framework;
using NUnit.StaticExpect;

namespace NUnitTestAssistant
{
    [TestFixture]
    class RegExUtilTest
    {
        [Test]
        public static void TestTelNumValidate()
        {
            Expectations.Expect(RegExUtil.TelNumValidate("0976513930"), Is.True, "Valid: 0976513930");
            Expectations.Expect(RegExUtil.TelNumValidate("_ëüëüüëüü0976513930"), Is.False, "Invalid: _ëüëüüëüü0976513930");
        }
        [Test]
        public static void TestVinValidate()
        {
            Expectations.Expect(RegExUtil.VinValidate("WVWZZZ1KZ5W201317"), Is.True, "Valid: WVWZZZ1KZ5W201317");
            Expectations.Expect(RegExUtil.VinValidate("WVWZZZ1KàâïðZ5W201317"), Is.False, "Invalid: WVWZZZ1KàâïðZ5W201317");
        }
        [Test]
        public static void TestIdentnumValidate()
        {
            Expectations.Expect(RegExUtil.IdentnumValidate("3183612868", 2), Is.True, "Valid: 3183612868");
            Expectations.Expect(RegExUtil.IdentnumValidate("3183 612868", 2), Is.False, "Invalid: 3183 612868");
            Expectations.Expect(RegExUtil.IdentnumValidate("243856126103", 1), Is.True, "Valid: 243856126103");
            Expectations.Expect(RegExUtil.IdentnumValidate("43856126103", 1), Is.False, "Invalid: 43856126103");
        }
        [Test]
        public static void TestEdrpouValidate()
        {
            Expectations.Expect(RegExUtil.EdrpouValidate("24385619"), Is.True, "Valid: 24385619");
            Expectations.Expect(RegExUtil.EdrpouValidate("2438G5619"), Is.False, "Invalid: 2438G5619");
        }
        [Test]
        public static void TestPrimaryPhoneValidate()
        {
            Expectations.Expect(RegExUtil.PrimaryPhoneValidate("380976513930"), Is.True, "Valid: 30976513930");
            Expectations.Expect(RegExUtil.PrimaryPhoneValidate("0976513930"), Is.False, "Invalid: 0976513930");
        }
        [Test]
        public static void TestEmailValidate()
        {
            Expectations.Expect(RegExUtil.EmailValidate("ashilin@ingo.ua"), Is.True, "Valid: ashilin@ingo.ua");
            Expectations.Expect(RegExUtil.EmailValidate("warning-mail.ua"), Is.False, "Invalid: warning-mail.ua");
        }
        [Test]
        public static void TestIsValidEmail()
        {
            Expectations.Expect(RegExUtil.IsValidEmail("js#internal@proseware.com"), Is.True, "Valid: js#internal@proseware.com");
            Expectations.Expect(RegExUtil.IsValidEmail("j.@server1.proseware.com"), Is.False, "Invalid: j.@server1.proseware.com");
        }
        [Test]
        public static void TransformOutbound_MustSeparateWithSlash()
        {
            //Arrange
            var input = "ControllerBase";

            //Act
            var result = RegExUtil.TransformOutbound(input);

            //Assert
            Assert.AreEqual(result, "controller-base");
        }
    }
}