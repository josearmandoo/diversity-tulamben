using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarStats : MonoBehaviour
{
    public Slider oxygenBar;
    public Slider batteryBar;
    public float oxygenDepletionRate = 1f; // Oxygen depletes per second
    public float batteryDepletionRate = 1f; // Battery depletes per second when active
    public float rechargeRate = 10f; // Rate at which bars recharge
    public bool isBatteryDepleting = false; // Boolean to control battery depletion
    public bool isRecharging = false; // Boolean to control recharging state

    private float maxOxygen = 200f;
    private float maxBattery = 100f;
    public float currentOxygen;
    public float currentBattery;

    private GameObject PlayerObj;
    private PlayerStatsRecharge PlayerStatsScript;

    private GameObject GameSystemObj;
    private PlayerSavedStat SaveScript;
    private LoadScene LoadSceneNextDay;

    public bool isBlackOut = false;

    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        SaveScript = GameSystemObj.GetComponent<PlayerSavedStat>();
        LoadSceneNextDay = GameSystemObj.GetComponent<LoadScene>();

        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerStatsScript = PlayerObj.GetComponent<PlayerStatsRecharge>();

        if (SaveScript.gameData.Oxygen1)
        {
            maxOxygen = maxOxygen * 2;
        }

        if (SaveScript.gameData.Oxygen2)
        {
            maxOxygen = maxOxygen * 2;
        }

        if (SaveScript.gameData.Battery1)
        {
            maxBattery = maxBattery * 2;
        }

        if (SaveScript.gameData.Battery2)
        {
            maxBattery = maxBattery * 2;
        }

        currentOxygen = maxOxygen;
        currentBattery = maxBattery;

        oxygenBar.maxValue = maxOxygen;
        oxygenBar.value = currentOxygen;

        batteryBar.maxValue = maxBattery;
        batteryBar.value = currentBattery;
    }

    void Update()
    {
        if (isBlackOut == false && currentOxygen <= 0f)
        {
            SaveScript.BlackOut();
            LoadSceneNextDay.FadeIn();
            isBlackOut = true;
        }

        isRecharging = PlayerStatsScript.isRecharge;

        if (!isRecharging)
        {
            // Deplete oxygen over time
            currentOxygen -= oxygenDepletionRate * Time.deltaTime;
            currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
            oxygenBar.value = currentOxygen;

            // Deplete battery only when isBatteryDepleting is true
            if (isBatteryDepleting)
            {
                currentBattery -= batteryDepletionRate * Time.deltaTime;
                currentBattery = Mathf.Clamp(currentBattery, 0, maxBattery);
                batteryBar.value = currentBattery;
            }
        }
        else
        {
            // Recharge oxygen and battery gradually
            currentOxygen += rechargeRate * Time.deltaTime;
            currentOxygen = Mathf.Clamp(currentOxygen, 0, maxOxygen);
            oxygenBar.value = currentOxygen;

            currentBattery += rechargeRate * Time.deltaTime;
            currentBattery = Mathf.Clamp(currentBattery, 0, maxBattery);
            batteryBar.value = currentBattery;
        }
    }

    // Call this method to change the depletion state of the battery
    public void SetBatteryDepletionState(bool state)
    {
        isBatteryDepleting = state;
    }

    // Call this method to change the recharging state
    public void SetRechargingState(bool state)
    {
        isRecharging = state;
    }
}
