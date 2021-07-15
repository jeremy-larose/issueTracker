namespace BugTracker.Models
{
    public class Bug
    {
        /// <summary>
        /// The list of bug types
        /// </summary>
        public enum BugType
        {
            Functionality = 1,
            Mathematical = 2,
            Typo = 3
        }

        /// <summary>
        /// Constructs a bug for the provided bug type and name.
        /// </summary>
        /// <param name="bugType"> The bug type for the activity.</param>
        /// <param name="name"The name for the bug.</param>
        public Bug(BugType bugType, string name = null)
        {
            Id = (int) bugType;
            
            // If we don't have a name argument,
            // then use the string representation of the bug type for the name.
            Name = name ?? bugType.ToString();
        }
        
        /// <summary>
        /// The ID of the bug.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the bug.
        /// </summary>
        public string Name { get; set; }
    }
}