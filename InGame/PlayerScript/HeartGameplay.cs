using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartGameplay : MonoBehaviour
{

    [SerializeField]
    float radius, speed, backgroundSize,backgroundSliding,LevelDuration;
    [SerializeField]
    HUD_Update hudUpdater;
    private Vector3 originPos;
    private Vector3 backgroundOrigin;
    [SerializeField]
    RandomSpawn rdSpawner;
    private Rigidbody2D rb;

    public bool isEnding = false;

    public bool gameEnded = false;

    [SerializeField]
    GameObject characterRenderer,background,endLevel,littleObstacle;


    private GameObject currentbackground, nextbackground;

    [SerializeField]
    Transform right,left,up,down;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originPos = transform.position;

        currentbackground = Instantiate(background);
        nextbackground = Instantiate(background);
        Vector3 newBackPos = background.transform.position;
        newBackPos.y = backgroundSize;
        nextbackground.transform.position = newBackPos;
        backgroundOrigin = currentbackground.transform.position;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;


    }

    private void Start()
    {
        StartCoroutine(Timer());
    }


    private IEnumerator Timer()
    {
        hudUpdater.SetInfo("Wow, I'm floating and I'm feeling invincible");
        yield return new WaitForSeconds(5);
        hudUpdater.SetInfo("Something is falling...");
        GameObject go = Instantiate(littleObstacle);
        go.transform.position = rdSpawner.centrePos.position;
        go.AddComponent<Rigidbody2D>();
        yield return new WaitForSeconds(5);
        hudUpdater.SetInfo("");
        yield return new WaitForSeconds(5);
        rdSpawner.isDropping = true;
        yield return new WaitForSeconds(LevelDuration);
        rdSpawner.isDropping = false;
        endLevel.SetActive(true);


    }

    

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        //HANDLE BACKGROUNDSCROLLING
        if (gameEnded == false)
        {
            currentbackground.transform.Translate(Vector3.down * backgroundSliding * Time.deltaTime);
            nextbackground.transform.Translate(Vector3.down * backgroundSliding * Time.deltaTime);

        }

        if (nextbackground.transform.position.y <= backgroundOrigin.y)
        {
            Destroy(currentbackground);
            currentbackground = nextbackground;
            nextbackground = Instantiate(background);
            Vector3 newposbg = nextbackground.transform.position;
            newposbg.y += backgroundSize;
            nextbackground.transform.position = newposbg;
        }

        characterRenderer.transform.position = transform.position;
        if (isEnding) return;

        //transform.position = Vector3.MoveTowards(transform.position, mousePos,Time.deltaTime * speed);

        transform.position = Vector3.Lerp(transform.position, mousePos, Time.deltaTime * speed);
       

        Vector3 newpos = transform.position;

        if(transform.position.x > right.position.x)
        {
            newpos.x = right.position.x;
        }else if(transform.position.x < left.position.x)
        {
            newpos.x = left.position.x;
        }

        if (transform.position.y > up.position.y)
        {
            newpos.y = up.position.y;
        }
        else if (transform.position.y < down.position.y)
        {
            newpos.y = down.position.y;
        }

        transform.position = newpos;

       


    }


}
