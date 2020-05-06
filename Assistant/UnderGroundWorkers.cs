using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Assistant
{
    /// <summary>
    /// Managed UnderGroundWorker
    /// </summary>
    /// <example>
    ///UnderGroundWorkers workers = new UnderGroundWorkers();
    ///workers.Add(this, SelectRows, SetDataSource);
    ///workers.Add(this, SelectRows2, SetDataSource2);
    ///workers.Add(this, SelectRows3, SetDataSource3);
    ///workers.DoLoad();
    /// </example>
    public class UnderGroundWorkers : IEnumerable<UnderGroundWorker>
    {
        private List<UnderGroundWorker> workersList = new List<UnderGroundWorker>();
        public IEnumerator<UnderGroundWorker> GetEnumerator() => workersList.GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => workersList.GetEnumerator();
        public void Add(Form f, Func<object> loadAction, Action<object> setAction)
        {
            workersList.Add(new UnderGroundWorker(f, loadAction, setAction));
        }
        public void DoLoad()
        {
            foreach (var worker in workersList)
                worker.RunLoader();
        }
    }
}
