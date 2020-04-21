using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField]
    HUD_Update ui;
    [SerializeField]
    private float textDuration;
    [SerializeField]
    private string TxtToShow;

    bool isOne;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isOne == false)
        {
            isOne = true;
            ui.SetInfo(TxtToShow);
            StartCoroutine(Timer());
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(textDuration);
        ui.SetInfo("");
    }
}
