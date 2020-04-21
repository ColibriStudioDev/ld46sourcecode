using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusInit : MonoBehaviour
{
   
    void Start()
    {
        Virus[] viruses = GetComponentsInChildren<Virus>();

        foreach (Virus virus in viruses)
        {
            if(virus.Virus_order < PlayerStat.order)
            {
                Destroy(virus.gameObject);
            }

        }





    }


}
