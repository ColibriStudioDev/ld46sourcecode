using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPee : MonoBehaviour
{
    [SerializeField]
    GameObject WhereTheScriptToTrigger;
    [SerializeField]
    float upFactor;

    private void Start()
    {
        if (PlayerStat.isFinished)
        {
            if(PlayerStat.order >= 1)
            {
                WhereTheScriptToTrigger.GetComponent<Upping>().enabled = true;
                Vector3 newpos = WhereTheScriptToTrigger.transform.position;
                newpos.y += PlayerStat.order * upFactor;
                WhereTheScriptToTrigger.transform.position = newpos;
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            WhereTheScriptToTrigger.GetComponent<Upping>().enabled = true;
            Destroy(gameObject);
        }
    }
}
