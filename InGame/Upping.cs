using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upping : MonoBehaviour
{
    [SerializeField]
    float uppingSpeed, animSpeed;
    [SerializeField]
    Sprite[] allsprite;
    // Update is called once per frame
    private void Start()
    {
        gameObject.GetComponent<UI_Anim>().OnSpriteEnded1 += generic;
        StartCoroutine(gameObject.GetComponent<UI_Anim>().SPRITEANIM(allsprite, animSpeed, transform.GetComponent<SpriteRenderer>()));
       
    }

    private void generic()
    {
        StartCoroutine( gameObject.GetComponent<UI_Anim>().SPRITEANIM(allsprite, animSpeed, transform.GetComponent<SpriteRenderer>()));
    }


    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += uppingSpeed * Time.deltaTime;
        transform.position = pos;




    }
}
