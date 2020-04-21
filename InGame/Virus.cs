using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{

    private ParticleSystem[] allparticles;

    [SerializeField]
   public int Virus_order;

    [SerializeField]
    private float destroySpeed;

    bool isDraining;

    Vector3 initScale;
    private void Awake()
    {
        initScale = transform.localScale;
        allparticles = gameObject.GetComponentsInChildren<ParticleSystem>();

       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && PlayerStat.isFinished)
        {
            GetComponent<AudioSource>().volume = HUD_Update.globalVolume;
            if (HUD_Update.isMuted)
            {
                GetComponent<AudioSource>().volume = 0;
            }


            foreach (ParticleSystem particle in allparticles)
            {
                particle.Play();
            }
            PlayerController.virusDrained = gameObject;
            StartCoroutine(Absorber());
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && isDraining)
        {
            PlayerController.virusDrained = null;
            isDraining = false;
        }
    }






    private IEnumerator Absorber()
    {
        isDraining = true;
        if (PlayerStat.isFinished)
        {
            gameObject.GetComponent<AudioSource>().Play();

            float _time = 0;
            while (_time < PlayerStat.PlayerStats[Stats.AbsorptionTime])
            {
                if (isDraining == false) yield return _time = PlayerStat.PlayerStats[Stats.AbsorptionTime];

                PlayerStat.PlayerStats[Stats.Life] += PlayerStat.PlayerStats[Stats.GivenLife] * Time.deltaTime / PlayerStat.PlayerStats[Stats.AbsorptionTime];
                transform.localScale -= _time * transform.localScale * destroySpeed / PlayerStat.PlayerStats[Stats.AbsorptionTime];
                transform.GetComponent<CircleCollider2D>().radius += _time * destroySpeed *transform.GetComponent<CircleCollider2D>().radius/ PlayerStat.PlayerStats[Stats.AbsorptionTime];
                yield return _time += Time.deltaTime;
                
            }
            if (isDraining)
            {
                PlayerStat.lastCoordinate = transform.position;
                PlayerStat.order = Virus_order;
                isDraining = false;
                VirusDestroyed();
            }
            else
            {
                VirusInit();
            }
        }






    }

    private void VirusInit()
    {
        foreach (ParticleSystem particle in allparticles)
        {
            particle.Stop();
        }
        transform.localScale = initScale;
        gameObject.GetComponent<AudioSource>().Stop();
    }

    private void VirusDestroyed()
    {
        Destroy(gameObject);
    }

}
