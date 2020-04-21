using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    [SerializeField]
    ParticleSystem[] particles;


    [SerializeField]
    float frequence,windDuration,lifeLess;
    [SerializeField]
    Vector2 impulseForce;

    private Collider _collider;
    private GameObject PlayerPrefabs;

    private void Start()
    {
        _collider = gameObject.GetComponent<Collider>();
        StartCoroutine(Windingo());
    }

    private IEnumerator Windingo()
    {
        if (PlayerStat.isFinished)
        {


            yield return new WaitForSeconds(frequence);
            foreach (ParticleSystem particle in particles)
            {
                particle.Play();
            }
            float _time = 0;
            while (_time < windDuration)
            {
                if (PlayerPrefabs != null)
                {
                    PlayerPrefabs.GetComponent<Rigidbody2D>().AddForce(impulseForce * Time.deltaTime*1000);

                    //PlayerPrefabs.GetComponent<Rigidbody2D>().velocity += impulseForce * Time.deltaTime;
                    PlayerStat.PlayerStats[Stats.Life] -= lifeLess * Time.deltaTime;
                }
                
                yield return _time += Time.deltaTime;
            }
            foreach (ParticleSystem particle in particles)
            {
                particle.Stop();
            }


            StartCoroutine(Windingo());
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerPrefabs = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefabs = null;
        }
    }








}
