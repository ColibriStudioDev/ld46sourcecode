using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadingController : MonoBehaviour
{
    private Animator FadingAnimation;

    public static UnityAction onFadingFinished;



    private void Awake()
    {
        FadingAnimation = GetComponent<Animator>();
    }
    private void Start()
    {
        onFadingFinished += _null;
        triggerFading();
       
    }
    public void FadingFinished()
    {
        onFadingFinished();
    }

    public void _null(){


        }
    

    public void triggerIFading()
    {
        FadingAnimation.SetTrigger("iFading");
    }

    public void triggerFading()
    {
        FadingAnimation.SetTrigger("fading");
    }
}
