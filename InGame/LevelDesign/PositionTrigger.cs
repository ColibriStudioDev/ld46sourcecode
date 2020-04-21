using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTrigger : MonoBehaviour
{
   [SerializeField]
    Transform WhatToMove;

    Vector3 where;
    [SerializeField]
    float movingSpeed, duration;

    bool isSliding;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isSliding == false)
        {
            where = transform.position;

            isSliding = true;
            StartCoroutine(sliding());
        }
    }



    IEnumerator sliding()
    {
        float _time = 0;
        while(_time < duration)
        {
            WhatToMove.position = Vector3.Lerp(WhatToMove.position, where, Time.deltaTime * movingSpeed);   
            yield return _time += Time.deltaTime;
        }

    }
        



}
