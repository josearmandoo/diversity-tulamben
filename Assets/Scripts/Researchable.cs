using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Researchable : MonoBehaviour
{
    public float goalPoint = 5;
    public float currPoint = 0;

    public int LootWorth = 20;
    public GameObject FishObj;

    public int researchDiff;

    public GameObject PhotoManager;
    private RingMinigameManager PhotoManagerScript;

    public GameObject FinishPhoto;

    private GameObject GameSystemObj;
    private PlayerSavedStat DataScript;

    // Start is called before the first frame update
    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        DataScript = GameSystemObj.GetComponent<PlayerSavedStat>();

        PhotoManager = GameObject.FindGameObjectWithTag("PhotoManager");
        PhotoManagerScript = PhotoManager.GetComponent<RingMinigameManager>();
        StartCoroutine(Decay());
    }

    // Update is called once per frame
    void Update()
    {


        if(currPoint >= goalPoint && FishObj.tag == "Researchable")
        {
            DataScript.Loot = DataScript.Loot + LootWorth;
            FinishPhoto.SetActive(true);
            FishObj.tag = "Untagged";
            Destroy(GameObject.FindGameObjectWithTag("MinigameObj"));
        }


    }

    private IEnumerator Decay()
    {
        while(true)
        {
            if(currPoint > 0)
            {
                currPoint = currPoint - 0.1f;
            }
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(FishObj.tag == "Researchable" && collision.gameObject.tag == "PhotoManager")
        {
            PhotoManagerScript.CurrentObjectOnPhoto = this.gameObject;
            PhotoManagerScript.isTakingPhoto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PhotoManager")
        {
            Destroy(GameObject.FindGameObjectWithTag("MinigameObj"));
            PhotoManagerScript.CurrentObjectOnPhoto = null;
            PhotoManagerScript.isTakingPhoto = false;
            PhotoManagerScript.ringExist = false;
        }
    }
}
