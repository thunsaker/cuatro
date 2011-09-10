using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common
{
    /// <summary>
    /// Foursquare Venue Tips
    /// </summary>
    [Serializable]
    public class Tips
    {
        /// <summary>
        /// Foursquare Tips Id
        /// </summary>
        public string FoursquareTipsId { get; set; }

        /// <summary>
        /// Date/Time Tip was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Tip Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Current Tip Status
        /// </summary>
        public TipStatus Status { get; set; }

        /// <summary>
        /// Total Number of Todos for the Tip
        /// </summary>
        public int TotalTodoCount { get; set; }

        /// <summary>
        /// Total Number of completions of the tip
        /// </summary>
        public int TotalDoneCount { get; set; }

        /// <summary>
        /// Venue where the tip was left
        /// </summary>
        public Venue Venue { get; set; }
    }

    /// <summary>
    /// Todos
    /// </summary>
    [Serializable]
    public class Todos : Tips { }

    /// <summary>
    /// Tip Status
    /// </summary>
    [Serializable]
    public enum TipStatus
    {
        todo,
        done
    }
}
