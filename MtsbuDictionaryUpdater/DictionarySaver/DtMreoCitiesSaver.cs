using System;
using System.Collections.Generic;

namespace MtsbuDictionaryUpdater
{
    public class DtMreoCitiesSaver : IDictionarySaver
    {
        public void Save<T>(T dictionary)
        {
            if (!(dictionary is MreoCities mreoCities))
                throw new ArgumentException($"{nameof(dictionary)} typeof must be {nameof(MreoCities)}!");

            using (DatabaseManager db = new DatabaseManager())
                foreach (City c in mreoCities.DCity)
                {
                    var pars = new Dictionary<string, object>()
                    {
                        { "p_mc_id", c.DMREOCityID },
                        { "p_mc_zone_code", c.ZoneCode },
                        { "p_mc_koatuu", c.KOATUU },
                        { "p_mc_name", c.Name },
                        { "p_mc_active", c.IsActive },
                        { "p_mc_updatedby_id", 1 }
                    };
                    db.Update("pack_dt_mreo_cities.upd_dt_mreo_cities", pars);
                    Console.WriteLine($"MreoCity updated: { c.DMREOCityID }");
                }

        }
    }
}
