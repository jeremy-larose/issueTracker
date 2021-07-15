using System.Collections.Generic;
using BugTracker.Models;

namespace BugTracker.Data
{
    /// <summary>
    /// Provides an in-memory data store.
    /// 
    /// Note: The code in this class is not to be considered a "best practice" 
    /// example of how to do data persistence, but rather as workaround for
    /// not having a database to persist data to.
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// The collection of bugs.
        /// </summary>
        public static List<Bug> Bugs { get; set; }
        
        /// <summary>
        /// The collection of entries.
        /// </summary>
        public static List<Entry> Entries { get; set; }

        /// <summary>
        /// Static constructor used to initialize the data.
        /// </summary>
        static Data()
        {
            InitData();
        }

        public static void InitData()
        {
            // Create the collection of bugs first
            // so we can reference them when creating the bugs collection.
            var bugs = new List<Bug>()
            {
                new Bug(Bug.BugType.Functionality),
                new Bug(Bug.BugType.Typo),
                new Bug(Bug.BugType.Mathematical)
            };

            var entries = new List<Entry>()
            {
                new Entry(1, 2020, 8, 24, Bug.BugType.Typo, Entry.CurrentStatus.Open,
                    Entry.PriorityLevel.Low, false, null),
                new Entry(2, 2020, 9, 4, Bug.BugType.Functionality, Entry.CurrentStatus.Open,
                    Entry.PriorityLevel.High, false, null),
                new Entry(3, 2020, 9, 3, Bug.BugType.Mathematical, Entry.CurrentStatus.Closed,
                    Entry.PriorityLevel.Medium, false, null)
            };

            Bugs = bugs;
            Entries = entries;
        }
    }
}