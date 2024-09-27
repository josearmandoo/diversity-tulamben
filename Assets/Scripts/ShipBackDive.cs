using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBackDive : MonoBehaviour
{
    private GameObject GameSystemObj;
    private GameSystem GameSystemScript;

    public GameObject ShipCanvas;
    // Start is called before the first frame update
    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        GameSystemScript = GameSystemObj.GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickBackDive()
    {
        ShipCanvas.SetActive(false);
        GameSystemScript.isPause = false;
    }
}
