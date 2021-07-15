using System.Collections.Generic;
using System.Linq;
using BugTracker.Models;

namespace BugTracker.Data
{
    /// <summary>
    /// Repository for bugs.
    ///
    /// Note: The code in this class is not considered a "best practice"
    /// example of how to do data persistence, but rather as a workaround for
    /// not having a database to persist data to.
    /// </summary>
    public class BugsRepository
    {
        
        ///<summary>
        /// Returns a collection of bugs.
        /// </summary>
        /// <returns> A list of bugs.</returns>
        public List<Bug> GetBugs()
        {
            return Data.Bugs.OrderBy(a => a.Name).ToList();
        }
    }
}