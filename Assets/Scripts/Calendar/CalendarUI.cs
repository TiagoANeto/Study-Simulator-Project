using UnityEngine;

public class CalendarUI : MonoBehaviour
{
    public GameObject dayPrefab;
    public Transform gridParent;

    public void GenerateMonth(int month, int year, UserCalendarData data)
    {
        foreach (Transform t in gridParent)
            Destroy(t.gameObject);

        int days = System.DateTime.DaysInMonth(year, month);

        for (int d = 1; d <= days; d++)
        {
            GameObject obj = Instantiate(dayPrefab, gridParent);
            //var controller = obj.GetComponent<DayButton>();

            System.DateTime date = new System.DateTime(year, month, d);
            var stats = data.stats.Find(x => x.date == date.ToString("yyyy-MM-dd"));

            //controller.Setup(date, stats);
        }
    }
}
