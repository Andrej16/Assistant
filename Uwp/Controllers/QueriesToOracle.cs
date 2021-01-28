using System;
using System.Linq;
using Uwp.Core;
using Uwp.Model;

namespace Uwp.Controllers
{
    /// <summary>
    /// Oracle, doesn't work on UWP - https://community.oracle.com/tech/developers/discussion/4479820/windows-uwp-compatibility
    /// </summary>
    public class QueriesToOracle : IReader
    {
        public MainPage Page { get; set; }

        public QueriesToOracle(MainPage page)
        {
            Page = page;
        }
        public void DoRead()
        {
            LoadIdentRisk();
        }
        private void LoadIdentRisk()
        {
            using (Context db = new Context())
            {
                IQueryable<IdentRisk> risks = from risk in db.IdentRisks select risk;
                foreach (var item in risks)
                    Console.WriteLine($"{item.Id} - {item.Name}");
            }
        }
    }
}
