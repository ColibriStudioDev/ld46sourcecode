using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushProc : MonoBehaviour
{
    private bool isCrushing;

    public bool getSate()
    {
        return isCrushing;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") isCrushing = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") isCrushing = false;
    }
}
