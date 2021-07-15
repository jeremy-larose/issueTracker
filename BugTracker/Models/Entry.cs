using System;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    /// <summary>
    /// Represents a bug that has been logged in the Bug Tracker app.
    /// </summary>
    public class Entry
    {
        /// <summary>
        /// The priority level of the bug.
        /// </summary>
        public enum PriorityLevel
        {
            Low,
            Medium,
            High
        }

        /// <summary>
        /// The current status of the bug.
        /// </summary>
        public enum CurrentStatus
        {
            Open,
            Closed
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Entry()
        {
        }

        /// <summary>
        /// Constructor for easily creating entries.
        /// </summary>
        /// <param name="id">The ID for the entry. </param>
        /// <param name="year">The year (1 through 9999) for the entry year.</param>
        /// <param name="month">The month (1 through 12) for the entry month.</param>
        /// <param name="day">The day (1 through the number of days for the month) for the entry day.</param>
        /// <param name="bugType">The bug type for the entry.</param>
        /// <param name="currentStatus">The status of the entry.</param>
        /// <param name="priority">The priority of the entry.</param>
        /// <param name="exclude">Whether or not the entry should be excluded from the list of known issues.</param>
        /// <param name="notes">The notes for the entry.</param>
        public Entry(int id, int year, int month, int day, Bug.BugType bugType, CurrentStatus currentStatus = CurrentStatus.Open,
            PriorityLevel priority = PriorityLevel.Medium,
            bool exclude = false, string notes = null)
        {
            Id = id;
            Date = new DateTime( year, month, day );
            BugId = (int) bugType;
            Status = currentStatus;
            Priority = priority;
            Exclude = exclude;
            Notes = notes;
        }
        
        /// <summary>
        /// The ID of the entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date of the entry.
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// The bug ID for the entry. The ID value should map to an ID in the bug collection.
        /// </summary>
        [Display(Name="Bug")]
        public int BugId { get; set; }
        
        /// <summary>
        /// The bug for the entry.
        /// </summary>
        public Bug Bug { get; set; }
        
        /// <summary>
        /// The status of the entry.
        /// </summary>
        public CurrentStatus Status { get; set; }
        
        /// <summary>
        /// The priority level of the entry.
        /// </summary>
        public PriorityLevel Priority { get; set; }

        /// <summary>
        /// Whether or not the entry should be excluded when calculating the total bug reports.
        /// </summary>
        public bool Exclude { get; set; }
        
        /// <summary>
        /// The notes for the entry.
        /// </summary>
        
        [Required]
        [MaxLength( 200, ErrorMessage = "The notes field cannot be longer than 200 characters.")]
        public string Notes { get; set; }
    }
}