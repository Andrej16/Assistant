using System;
using System.Linq;
using Uwp.Core;
using Uwp.Model;

namespace Uwp.Controllers
{
    public class QueriesToOracle : IReader
    {
        public void DoRead()
        {
            //FilterByName();
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
