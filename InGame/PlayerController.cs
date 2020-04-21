using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PRIVATE GEAR
    private Rigidbody2D rb;
    private Vector2 moving;
    public static bool isGrounded = false;
    private LineRenderer line;
    
    private Camera cam;
    public static GameObject virusDrained;

    //PUBLIC PROPERTIES
    [SerializeField]
    private float speed, jumpForce, camSpeed,gravityForce;





    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;

    }


    private void Update()
    {
        Debug.Log(isGrounded);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode2D.Impulse);
        }

        float x = Input.GetAxis("Horizontal");

        moving = transform.right * x;
     
        
        


        Vector3 camMove = cam.transform.position;
        camMove.x = Mathf.Lerp(camMove.x, transform.position.x, Time.deltaTime * camSpeed);
        cam.transform.position = camMove;

        if(virusDrained != null)
        {
            line.positionCount = 2;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, virusDrained.transform.position);
        }
        else
        {
            line.positionCount = 0;
        }


    }





    private void FixedUpdate()
    {




        rb.velocity = new Vector2(moving.x * speed *10* Time.fixedDeltaTime,rb.velocity.y);
   



    }

   

}
