using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUIRemain : MonoBehaviour
{
    public TextMeshProUGUI Loot;
    public TextMeshProUGUI Balance;
    public TextMeshProUGUI Date;

    private GameObject GameSystemObj;
    private PlayerSavedStat SaveScript;
    // Start is called before the first frame update
    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        SaveScript = GameSystemObj.GetComponent<PlayerSavedStat>();

        Balance.text = "$" + SaveScript.gameData.Money;

        UpdateDayText();
    }

    // Update is called once per frame
    void Update()
    {
        Loot.text = "$" + SaveScript.Loot;
    }

    void UpdateDayText()
    {
        // Calculate the day of the week based on the date
        int dayOfWeekIndex = SaveScript.gameData.Day % 7; // Modulus 7 to get the index of the day of the week (0 = Sunday, 1 = Monday, ..., 6 = Saturday)
        string[] daysOfWeek = {"MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN"};
        string dayOfWeek = daysOfWeek[dayOfWeekIndex];

        // Update the TextMeshProUGUI text
        Date.text = "DAY " + (SaveScript.gameData.Day+1) + " (" + dayOfWeek + ")";
    }
}
