using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Crush : MonoBehaviour
{
    [SerializeField]
    private bool haut, bas, gauche, droite;

    private Vector3 scaleChange, positionChange;
    
    [SerializeField]
    private float extensionHorizontal, extensionVertival;
    [Range(0f, 1f)]
    public float vitesse;

    
    private Vector3 origin;
    private Vector3 taille;
    private Rigidbody2D rb;
    public bool isTouch;


    private void Start()
    {
        
        origin = transform.position;
        taille = transform.localScale;
        scaleChange = new Vector3(extensionHorizontal, extensionVertival, 0);
        positionChange = new Vector3(extensionHorizontal*0.23f, extensionVertival*0.23f, 0);

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

    }

    private void Update()
    {
        if(haut && taille.y>=0)
        {
            rb.transform.localScale += scaleChange * Time.deltaTime * vitesse;
            rb.transform.position += positionChange * Time.deltaTime * vitesse;

            if (rb.transform.localScale.y < taille.y || rb.transform.localScale.y > extensionVertival+taille.y)
            {
                scaleChange = -scaleChange;
                positionChange = -positionChange;
            }
        }

        if(bas && taille.y<=0)
        {
            rb.transform.localScale -= scaleChange * Time.deltaTime * vitesse;
            rb.transform.position -= positionChange * Time.deltaTime * vitesse;

            if (rb.transform.localScale.y > taille.y || rb.transform.localScale.y < -extensionVertival+taille.y)
            {
                scaleChange = -scaleChange;
                positionChange = -positionChange;
            }
        }
        
        if(droite && taille.x>=0)
        {
            rb.transform.localScale += scaleChange * Time.deltaTime * vitesse;
            rb.transform.position += positionChange * Time.deltaTime * vitesse;

            if (rb.transform.localScale.x < taille.x || rb.transform.localScale.x > extensionHorizontal+taille.x)
            {
                scaleChange = -scaleChange;
                positionChange = -positionChange;
            }
        }
        
        if(gauche && taille.x<=0)
        {
            rb.transform.localScale -= scaleChange * Time.deltaTime * vitesse;
            rb.transform.position -= positionChange * Time.deltaTime * vitesse;

            if (rb.transform.localScale.x > taille.x || rb.transform.localScale.x < -extensionHorizontal+taille.x)
            {
                scaleChange = -scaleChange;
                positionChange = -positionChange;
            }
        }
    }

 

}
