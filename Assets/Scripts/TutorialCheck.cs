using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCheck : MonoBehaviour
{
    private GameObject GameSystemObj;
    private PlayerSavedStat SaveScript;

    public GameObject Tutorial;
    // Start is called before the first frame update
    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        SaveScript = GameSystemObj.GetComponent<PlayerSavedStat>();

        if(SaveScript.gameData.Day == 0)
        {
            Tutorial.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
