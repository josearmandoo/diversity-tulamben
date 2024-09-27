using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public GameObject Flipper1Btn;
    public GameObject SeaTurtleBtn;
    public GameObject Oxygen1Btn;
    public GameObject Battery1Btn;
    public GameObject MantaBtn;
    public GameObject Flipper2Btn;
    public GameObject LionFishBtn;
    public GameObject Oxygen2Btn;
    public GameObject Battery2Btn;
    public GameObject WhaleSharkBtn;

    private GameObject GameSystemObj;
    private PlayerSavedStat SaveScript;

    // Start is called before the first frame update
    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        SaveScript = GameSystemObj.GetComponent<PlayerSavedStat>();

        if (SaveScript.gameData.Flipper1)
        {
            Destroy(Flipper1Btn);
        }
        if (SaveScript.gameData.SeaTurtle)
        {
            Destroy(SeaTurtleBtn);
        }
        if (SaveScript.gameData.Oxygen1)
        {
            Destroy(Oxygen1Btn);
        }
        if (SaveScript.gameData.Battery1)
        {
            Destroy(Battery1Btn);
        }
        if (SaveScript.gameData.Manta)
        {
            Destroy(MantaBtn);
        }
        if (SaveScript.gameData.Flipper2)
        {
            Destroy(Flipper2Btn);
        }
        if (SaveScript.gameData.LionFish)
        {
            Destroy(LionFishBtn);
        }
        if (SaveScript.gameData.Oxygen2)
        {
            Destroy(Oxygen2Btn);
        }
        if (SaveScript.gameData.Battery2)
        {
            Destroy(Battery2Btn);
        }
        if (SaveScript.gameData.WhaleShark)
        {
            Destroy(WhaleSharkBtn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyFlipper1()
    {
        if(SaveScript.gameData.Money >= 200)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 200;
            SaveScript.gameData.Flipper1 = true;
            Destroy(Flipper1Btn);
        }
    }

    public void BuySeaTurtle()
    {
        if (SaveScript.gameData.Money >= 200)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 200;
            SaveScript.gameData.SeaTurtle = true;
            Destroy(SeaTurtleBtn);
        }
    }

    public void BuyOxygen1()
    {
        if (SaveScript.gameData.Money >= 300)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 300;
            SaveScript.gameData.Oxygen1 = true;
            Destroy(Oxygen1Btn);
        }
    }

    public void BuyBattery1()
    {
        if (SaveScript.gameData.Money >= 350)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 350;
            SaveScript.gameData.Battery1 = true;
            Destroy(Battery1Btn);
        }
    }

    public void BuyManta()
    {
        if (SaveScript.gameData.Money >= 300)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 300;
            SaveScript.gameData.Manta = true;
            Destroy(MantaBtn);
        }
    }

    public void BuyFlipper2()
    {
        if (SaveScript.gameData.Money >= 500)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 500;
            SaveScript.gameData.Flipper2 = true;
            Destroy(Flipper2Btn);
        }
    }

    public void BuyLionfish()
    {
        if (SaveScript.gameData.Money >=400)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 400;
            SaveScript.gameData.LionFish = true;
            Destroy(LionFishBtn);
        }
    }

    public void BuyOxygen2()
    {
        if (SaveScript.gameData.Money >= 600)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 600;
            SaveScript.gameData.Oxygen2 = true;
            Destroy(Oxygen2Btn);
        }
    }

    public void BuyBattery2()
    {
        if (SaveScript.gameData.Money >= 650)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 650;
            SaveScript.gameData.Battery2 = true;
            Destroy(Battery2Btn);
        }
    }

    public void BuyWhaleShark()
    {
        if (SaveScript.gameData.Money >= 700)
        {
            SaveScript.gameData.Money = SaveScript.gameData.Money - 700;
            SaveScript.gameData.WhaleShark = true;
            Destroy(WhaleSharkBtn);
        }
    }


}
