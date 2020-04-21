using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private string nextLevelName;
    [SerializeField]
    private float aspirationDuration,speed;
    [SerializeField]
    private Transform translatepoint;

    [SerializeField]
    bool isFirst;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (isFirst)
            {
                StartCoroutine(startAspire(collision.transform));
                return;
            }

            if (PlayerStat.isFinished)
            {


                if (PlayerStat.PlayerStats[Stats.Dead] == 0)
                {
                    StartCoroutine(startAspire(collision.transform));
                }
            }
        }
    }


    IEnumerator startAspire(Transform target)
    {

        float _time = 0;
        while (_time < aspirationDuration)
        {
            target.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            PlayerStat.PlayerStats[Stats.Life] = 100;
            target.position = Vector3.Lerp(target.position, translatepoint.position, Time.deltaTime * speed);
            
            yield return _time += Time.deltaTime;
        }
        PlayerStat.order = 0;
        PlayerController.isfreeze = false;
        PlayerStat.isFinished = false;
        PlayerStat.lastCoordinate = Vector3.zero;
        SceneManager.LoadSceneAsync(nextLevelName);
    }





}
