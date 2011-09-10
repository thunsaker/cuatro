using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cuatro.Common
{
    [Serializable]
    public class Leaderboard
    {
        public List<LeaderboardItem> UsersList { get; set; }
    }

    [Serializable]
    public class LeaderboardItem
    {
        public FoursquareUser User { get; set; }
        public FoursquareUserScores Scores { get; set; }
        public int Rank { get; set; }
    }
}
