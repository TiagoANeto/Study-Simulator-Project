using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Globalization;

public class CalendarController : MonoBehaviour
{
    [Header("Referências UI")]
    public TMP_Text monthYearText;
    public Transform daysParent;    
    public GameObject dayPrefab;     

    public Button prevMonthButton;
    public Button nextMonthButton;

    private DateTime currentDate;
    private CultureInfo culture = new CultureInfo("en-US");

    void Start()
    {
        currentDate = DateTime.Now;

        prevMonthButton.onClick.AddListener(() =>
        {
            currentDate = currentDate.AddMonths(-1);
            UpdateCalendar();
        });

        nextMonthButton.onClick.AddListener(() =>
        {
            currentDate = currentDate.AddMonths(1);
            UpdateCalendar();
        });

        UpdateCalendar();
    }

    void UpdateCalendar()
    {
        monthYearText.text = currentDate.ToString("MMMM yyyy", culture);

        foreach (Transform child in daysParent)
            Destroy(child.gameObject);

        int daysInMonth = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);

        DateTime firstDay = new DateTime(currentDate.Year, currentDate.Month, 1);

        //AGORA O CABEÇALHO COMEÇA EM SUNDAY
        int startDayOfWeek = (int)firstDay.DayOfWeek;

        //Cria espaços vazios antes do dia 1
        for (int i = 0; i < startDayOfWeek; i++)
            Instantiate(dayPrefab, daysParent);

        //Preenche os dias corretos
        for (int day = 1; day <= daysInMonth; day++)
        {
            GameObject dayObj = Instantiate(dayPrefab, daysParent);

            TMP_Text dayText = dayObj.transform.Find("DayText").GetComponent<TMP_Text>();
            Image bg = dayObj.transform.Find("BG").GetComponent<Image>();

            dayText.text = day.ToString();

            // Destaque para o dia atual
            if (currentDate.Year == DateTime.Now.Year &&
                currentDate.Month == DateTime.Now.Month &&
                day == DateTime.Now.Day)
            {
                bg.color = new Color(0.2f, 0.5f, 1f, 0.4f);
            }
            else
            {
                bg.color = Color.white;
            }
        }
    }
}
