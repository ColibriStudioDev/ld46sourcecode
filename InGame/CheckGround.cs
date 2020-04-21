using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            PlayerController.isGrounded = true;
            if(collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {
                PlayerController.plateformVelocity = rb.velocity;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") PlayerController.isGrounded = false;
        PlayerController.plateformVelocity = Vector2.zero;
    }
}
