using System.Collections.Generic;

[System.Serializable]

public class UserCalendarData
{
    public List<DailyStatsData> stats = new List<DailyStatsData>();
    public int currentStreak;
    public int maxStreak; 
}

