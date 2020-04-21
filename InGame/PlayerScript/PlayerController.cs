using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PRIVATE GEAR
    private Rigidbody2D rb;
    private Vector2 moving;
    [SerializeField]
    private Animator character;
    [SerializeField]
    private Transform CharacterRenderer;
    [SerializeField]
    private Transform LevitatePoint;

    private bool dying = false;
    public static Vector2 plateformVelocity;
    private Vector3 originalScale;
    private LineRenderer line;
    private Vector3 realHigh;
    private Camera cam;
    public static GameObject virusDrained;
    public static bool isGrounded = false;
    public static bool isfreeze = false;
    private Vector2 originalCamHeigh;

    private bool hasJump = false;


    //PUBLIC PROPERTIES
    [SerializeField]
    private float speed, jumpForce, camSpeed, floatingSpeed,heigh,floatFrequence,floatSpeed,contractionForce,deathSpeed,deathDuration,camHeigh, camOffSet;


    [SerializeField]
    private Transform PlayerPrefab;

    public void changeCamHeigh(float addHeigh,float _camOffSet)
    {
        camHeigh += addHeigh;
        camOffSet += _camOffSet;
    }

    public void backToNormalHeigh()
    {
        camHeigh = originalCamHeigh.y;
        camOffSet = originalCamHeigh.x;
    }
    
    


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        originalScale = CharacterRenderer.localScale;
        dying = false;
        originalCamHeigh.y = camHeigh;
        originalCamHeigh.x = camOffSet;
    }


    public void Start()
    {
        if(PlayerStat.lastCoordinate != Vector3.zero)
        {
            PlayerPrefab.transform.position = PlayerStat.lastCoordinate;
        }
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 newpos = CharacterRenderer.localScale;
            newpos.y -= contractionForce;
            CharacterRenderer.localScale = newpos;
            rb.AddForce(transform.up * Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y), ForceMode2D.Impulse);
            StartCoroutine(Jump());
        }

        float x = Input.GetAxis("Horizontal");

        moving = transform.right * x;

  

        Vector3 camMove = cam.transform.position;
        camMove.x = Mathf.Lerp(camMove.x, transform.position.x + camOffSet, Time.deltaTime * camSpeed);
        camMove.y = Mathf.Lerp(camMove.y, transform.position.y + camHeigh, Time.deltaTime * camSpeed);
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


        //ANIMATION HANDLE
        if(x > 0)
        {
            character.SetBool("isWalking", true);
            character.SetBool("right", true);
            character.SetBool("left", false);

        }
        else if(x < 0)
        {
            character.SetBool("isWalking", true);
            character.SetBool("left", true);
            character.SetBool("right", false);

        }
        else if(x == 0)
        {
            character.SetBool("isWalking", false);
            character.SetBool("left", false);
            character.SetBool("right", false);
        }



        

        CharacterRenderer.position = Vector3.Lerp(CharacterRenderer.position, transform.position + realHigh, floatingSpeed * Time.deltaTime);



        if (isfreeze && dying == false)
        {
            dying = true;
            StartCoroutine(death());
        }

    }





    private void FixedUpdate()
    {
        if (isfreeze) return;
       
        Vector2 velo = new Vector2(moving.x * speed * 10 * Time.fixedDeltaTime, rb.velocity.y);
        velo.x += plateformVelocity.x;

        rb.velocity = velo;


        //UPDATE RENDERER
        if (character.GetBool("isWalking") == false)
        {
            realHigh = (Vector3.up) * (heigh + floatFrequence * Mathf.Cos(Time.fixedTime * floatSpeed) * Time.fixedDeltaTime);
        }
        else
        {
            realHigh = Vector3.up * heigh;
        }


    }

    private IEnumerator Jump()
    {
        float _time = 0;
        while(_time < 0.5f)
        {
            CharacterRenderer.localScale = Vector3.Lerp(CharacterRenderer.localScale, originalScale, Time.deltaTime * floatingSpeed);
            yield return _time += Time.deltaTime;
        }
    }
    private IEnumerator death()
    {
        rb.velocity = Vector2.zero;

        float _time = 0;
        while(_time < deathDuration)
        {
            CharacterRenderer.localScale = Vector3.Lerp(CharacterRenderer.localScale, Vector3.zero, Time.deltaTime * deathSpeed);

            yield return _time += Time.deltaTime;
        }

        Destroy(GameObject.FindGameObjectWithTag("Player"));

    }

   

}
