using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public bool isTimePassing = true;  // Boolean to control whether time is passing

    private float realTimeSecondsPerGameMinute = 5f; // 1 game minute equals 0.5 real-time seconds
    private float timer;

    private int gameMinutes = 0;
    public int gameHours = 6;

    private const int startHour = 6;
    private const int endHour = 24; // Represents midnight (12 AM next day)

    private GameSystem GameSystemScript;

    void Start()
    {
        GameSystemScript = gameObject.GetComponentInParent<GameSystem>();

        UpdateTimeText();
    }

    void Update()
    {
        if (GameSystemScript.isPause)
        {
            isTimePassing = false;
        }
        else
        {
            isTimePassing = true;
        }
        

        if (isTimePassing)
        {
            timer += Time.deltaTime;

            if (timer >= realTimeSecondsPerGameMinute)
            {
                timer = 0f;
                AdvanceTime();
            }
        }
    }

    void AdvanceTime()
    {
        gameMinutes += 10;

        if (gameMinutes >= 60)
        {
            gameMinutes = 0;
            gameHours++;

            if (gameHours >= endHour)
            {
                gameHours = startHour;
            }
        }

        UpdateTimeText();
    }

    void UpdateTimeText()
    {
        string period = gameHours >= 12 ? "PM" : "AM";
        int displayHour = gameHours > 12 ? gameHours - 12 : gameHours;
        displayHour = displayHour == 0 ? 12 : displayHour;

        timeText.text = string.Format("{0:00}:{1:00} {2}", displayHour, gameMinutes, period);
    }
}
