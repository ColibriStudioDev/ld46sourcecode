using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpPlateform : MonoBehaviour
{
    [SerializeField]
    Vector2 bumpForce;
    [SerializeField]
    Sprite[] allsprites;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.attachedRigidbody.velocity = new Vector2(collision.attachedRigidbody.velocity.x, 0);
            collision.attachedRigidbody.AddForce(bumpForce * 10 );
            GetComponent<UI_Anim>().OnSpriteEnded1 += null;
            StartCoroutine(GetComponent<UI_Anim>().SPRITEANIM(allsprites, 0.5f, GetComponent<SpriteRenderer>()));
        }
    }




}
