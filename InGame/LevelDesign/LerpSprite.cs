using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSprite : MonoBehaviour
{
    [SerializeField]
    private PlayerController controller;
    private Vector3 target;
    [SerializeField]
    private float lerpSpeed;


    void Update()
    {
        target = controller.transform.position;
        Vector3 newpos = transform.position;
        newpos.x = Mathf.Lerp(newpos.x, target.x, Time.deltaTime * lerpSpeed);
        transform.position = newpos;
    }
}
