using UnityEngine;
using System;

public class RegisterTodayLogin : MonoBehaviour
{
    public void Register()
    {
        UserCalendarData data = SaveController.Instance.calendarData;

        string today = DateTime.Now.ToString("yyyy-MM-dd");
        string yesterday = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");

        var todayEntry = data.stats.Find(x => x.date == today);

        if (todayEntry == null)
        {
            todayEntry = new DailyStatsData()
            {
                date = today,
                usedAppToday = true
            };

            data.stats.Add(todayEntry);
        }

        bool usedYesterday = data.stats.Exists(
            x => x.date == yesterday && x.usedAppToday
        );

        if (usedYesterday)
            data.currentStreak++;
        else
            data.currentStreak = 1;

        if (data.currentStreak > data.maxStreak)
            data.maxStreak = data.currentStreak;

        Debug.Log("Streak atual: " + data.currentStreak);

        SaveController.Instance.Save();
    }
}
