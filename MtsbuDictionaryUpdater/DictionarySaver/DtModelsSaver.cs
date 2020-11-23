using System;
using System.Collections.Generic;

namespace MtsbuDictionaryUpdater
{
    public class DtModelsSaver : IDictionarySaver
    {
        public void Save<T>(T dictionary)
        {
            if (!(dictionary is Models models))
                throw new ArgumentException($"{nameof(dictionary)} typeof must be {nameof(Models)}!");

            using (DatabaseManager db = new DatabaseManager())
                foreach (Model m in models.DModel)
                {
                    var pars = new Dictionary<string, object>()
                    {
                        { "p_mod_id", m.DModelID },
                        { "p_mod_name", m.Name },
                        { "p_mod_mark_id", m.DMarkID },
                        { "p_mod_name_en", m.NameEn },
                        { "p_mod_name_ru", m.NameRu },
                        { "p_mod_active", m.IsActive },
                        { "p_mod_updatedby_id", 1 }
                    };
                    db.Update("pack_dt_models.upd_dt_models", pars);
                    Console.WriteLine($"Model updated: { m.DModelID }");
                }
        }
    }
}
