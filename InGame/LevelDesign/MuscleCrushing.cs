using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuscleCrushing : MonoBehaviour
{
    [SerializeField]
    private CrushProc[] allBox;
    [SerializeField]
    float ContractionForce;
    private float gap = 0.01f;

    [SerializeField]
    bool iscrushing;


    bool notThisTime = false;
    bool justOnce = false;

    [SerializeField]
    float speed, timeIntervalle,timeAmplitude,speedAmplitude;


    private void Awake()
    {
        speed = Random.Range(speed, speedAmplitude);
        timeIntervalle = Random.Range(timeAmplitude, timeAmplitude);
    }

    private void Update()
    {
        if (iscrushing != true) return;


        notThisTime = true;
        foreach(CrushProc proc in allBox)
        {
            if(proc.getSate() == false)
            {
                notThisTime = false;
                
            }
        }

        if (notThisTime && justOnce == false)
        {
            justOnce = true;
            CRUSHINGTRIGGER();
        }
    }


    void CRUSHINGTRIGGER()
    {
        GameEngine.triggerDeath = true;
    }


    private void Start()
    {
        StartCoroutine(contracting());
    }


    public IEnumerator contracting()
    {

        Vector3 Size = transform.localScale;
        Size.y += ContractionForce;
        

        while(Mathf.Abs(transform.localScale.y) < Mathf.Abs(Size.y - gap)){

            Vector2 newsize = transform.localScale;
            newsize.y = Mathf.Lerp(newsize.y, Size.y, Time.deltaTime * speed);

            transform.localScale = newsize;


            yield return null;

        }


        StartCoroutine(FlipContract());
    }

    public IEnumerator FlipContract()
    {
        Vector3 Size = transform.localScale;
        Size.y -= ContractionForce;


        while (Mathf.Abs(transform.localScale.y) > Mathf.Abs(Size.y + gap))
        {

            Vector2 newsize = transform.localScale;
            newsize.y = Mathf.Lerp(newsize.y, Size.y, Time.deltaTime * speed);

            transform.localScale = newsize;

            yield return null;

        }

        yield return new WaitForSeconds(timeIntervalle);
        
        StartCoroutine(contracting());
    }

}
