using System;
using System.Collections.Generic;

namespace MtsbuDictionaryUpdater
{
    public class DtMarksSaver : IDictionarySaver
    {
        public void Save<T>(T dictionary)
        {
            if (!(dictionary is Marks marks))
                throw new ArgumentException($"{nameof(dictionary)} typeof must be {nameof(Marks)}!");

            using (DatabaseManager db = new DatabaseManager())
                foreach (Mark m in marks.DMark)
                {
                    var pars = new Dictionary<string, object>()
                    {
                        { "p_dm_dmark_id", m.DMarkID },
                        { "p_dm_name", m.Name },
                        { "p_dm_name_en", m.NameEn },
                        { "p_dm_name_ru", m.NameRu },
                        { "p_dm_active", m.IsActive },
                        { "p_dm_updatedby_id", 1 }
                    };
                    db.Update("pack_dt_marks.upd_dt_marks", pars);
                    Console.WriteLine($"Mark updated: { m.DMarkID }");
                }
        }
    }
}
