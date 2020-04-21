using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class heartEndScript : MonoBehaviour
{
    [SerializeField]
    string sceneToLoad;
    [SerializeField]
    float aspirationSpeed;
    [SerializeField]
    Transform aspirationPoint;
    [SerializeField]
    HeartGameplay heart;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<HeartGameplay>().isEnding = true;
            collision.transform.position = Vector3.Lerp(collision.transform.position, aspirationPoint.position, Time.deltaTime * aspirationSpeed);
            if (Vector3.Distance(collision.transform.position, aspirationPoint.position) < 0.01f)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }


    public void HEART()
    {
        heart.gameEnded = true;
    }

}
