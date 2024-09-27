using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsRecharge : MonoBehaviour
{
    public bool isRecharge;
    // Start is called before the first frame update
    void Start()
    {
        isRecharge = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Recharge"))
        {
            isRecharge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Recharge"))
        {
            isRecharge = false;
        }
    }
}
