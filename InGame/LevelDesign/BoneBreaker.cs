using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneBreaker : MonoBehaviour
{

    [SerializeField]
    private float breakingCooldown,dropForce;
    private bool isBreaking = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isBreaking == false)
        {
            isBreaking = true;
            StartCoroutine(cooldown(breakingCooldown));

           
            
            
        }
    }


    private IEnumerator cooldown(float time)
    {
        bool right = false;
        yield return new WaitForSeconds(time);
        Rigidbody2D[] rbs = transform.GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rb in rbs)
        {
            rb.isKinematic = false;
            if(right == false) rb.AddForce(Vector2.right * -dropForce);
            else rb.AddForce(Vector2.right * dropForce);
            right = true;   
        }
        StartCoroutine(cooldownDestroy(1));

    }
    private IEnumerator cooldownDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
