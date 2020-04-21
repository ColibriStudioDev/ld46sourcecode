using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DavidOchmann.Animation;


[RequireComponent(typeof(Rigidbody2D))]
public class DynamicPlaterform : MonoBehaviour
{
    [SerializeField]
    private float moveX, moveY, speed;

    private Vector3 origin;
    private Rigidbody2D rb;

    private bool isLimitX;
    private bool isLimitY;

    private void Start()
    {
        origin = transform.position;

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;


    }

    private void FixedUpdate()
    {
        Vector2 moving = Vector2.zero;
        if (Mathf.Abs(transform.position.x - origin.x) > Mathf.Abs(moveX))
        {
            isLimitX = true;
        }
        if(Vector2.Distance(origin,transform.position) < 0.1f)
        {
            isLimitX = false;

        }
        if (isLimitX)
        {
           if(moveX < 0) moving += new Vector2(speed * -moveX, 0);
           if (moveX > 0) moving += new Vector2(speed * -moveX ,0);
        }
        else
        {
            if (moveX < 0) moving += new Vector2(speed * +moveX, 0);
            if (moveX > 0) moving += new Vector2(speed * moveX, 0);
        }

        if (Vector2.Distance(origin, transform.position) < 0.1f)
        {
            isLimitY = false;

        }
        if (transform.position.y-origin.y  > moveY)
        {
            isLimitY = true;
        }
        if (isLimitY)
        {
            moving += new Vector2(0,speed * -moveY);
        }
        else
        {
            moving += new Vector2(0,speed * moveY);
        }

        rb.velocity = moving * Time.fixedDeltaTime;
    }

    private void OnDrawGizmosSelected()
    {
     

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position,Vector2.right * moveX+Vector2.up * moveY);
    }


}
