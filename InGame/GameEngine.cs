using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEngine : MonoBehaviour
{
    [SerializeField]
    private float lifeDecreasingFactor;
    [SerializeField]
    private GameObject DeathScreen;
    [SerializeField]
    private FadingController fading;

    private AudioManager _audio;
    private bool isDying = false;


    public static bool triggerDeath = false;

    
    private bool JustOnce = false;
    private bool JustOnce2 = false;

    [SerializeField]
    private string NormalMusic, SpeedMusic;
    [SerializeField]
    private float porcentageDeath;

    private void Awake()
    {
        DeathScreen.SetActive(false);
        _audio = GetComponent<AudioManager>();
        
    }

    public void Start()
    {
       
    }


    void Update()
    {
        if (PlayerStat.isFinished == false) return;

        PlayerStat.PlayerStats[Stats.Life] -= Time.deltaTime * lifeDecreasingFactor;




        if(PlayerStat.PlayerStats[Stats.Life] > PlayerStat.PlayerStats[Stats.InitLife])
        {
            PlayerStat.PlayerStats[Stats.Life] = PlayerStat.PlayerStats[Stats.InitLife];
        }

        if (PlayerStat.PlayerStats[Stats.Life] <= 0 && isDying == false)
        {
            isDying = true;
            triggerDeath = true;

        }

        if (triggerDeath)
        {
            PlayerStat.PlayerStats[Stats.Dead] = 1;
            DeathCounter.DeathNb += 1;
            triggerDeath = false;
            _audio.PlayMusic("Death");
            FadingController.onFadingFinished += OPENDEATH;
            PlayerController.isfreeze = true;
            fading.triggerIFading();
        }

        if(PlayerStat.PlayerStats[Stats.Life] <= PlayerStat.PlayerStats[Stats.InitLife]*porcentageDeath /100   && JustOnce == false)
        {
            JustOnce = true;
            JustOnce2 = false;
            _audio.PlayMusic(SpeedMusic);
        }
        else if(PlayerStat.PlayerStats[Stats.Life] >= PlayerStat.PlayerStats[Stats.InitLife] * porcentageDeath / 100 && JustOnce2 == false)
        {
            JustOnce2 = true;
            JustOnce = false;
            _audio.PlayMusic(NormalMusic);
        }


        if (PlayerStat.PlayerStats[Stats.Dead] == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            RESETGAME();
        }


    }


    void OPENDEATH()
    {
        FadingController.onFadingFinished -= OPENDEATH;
        fading.triggerFading();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DeathScreen.SetActive(true);
    }


    public void RESETGAME()
    {
        PlayerStat.PlayerStats[Stats.Dead] = 0;
        PlayerStat.PlayerStats = null;
        PlayerController.isfreeze = false;
        PlayerStat.isFinished = false;



        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
