using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableFish : MonoBehaviour
{

    public GameObject SeaTurtle;
    public GameObject Lionfish;
    public GameObject Manta;
    public GameObject WhaleShark;

    private GameObject GameSystemObj;
    private PlayerSavedStat SaveScript;
    // Start is called before the first frame update
    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        SaveScript = GameSystemObj.GetComponent<PlayerSavedStat>();

        if(SaveScript.gameData.SeaTurtle == false)
        {
            SeaTurtle.SetActive(false);
        }

        if (SaveScript.gameData.LionFish == false)
        {
            Lionfish.SetActive(false);
        }

        if (SaveScript.gameData.Manta == false)
        {
            Manta.SetActive(false);
        }

        if (SaveScript.gameData.WhaleShark == false)
        {
            WhaleShark.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
