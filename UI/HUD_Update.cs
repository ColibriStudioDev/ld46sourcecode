using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class HUD_Update : MonoBehaviour
{
    [SerializeField]
    private Image LifeBar = null;
    [SerializeField]
    private TextMeshProUGUI infoText,deathText;
  
    private string infotxt;
    [SerializeField]
    private Transform textTarget,mainMenuButtonTarget;

    private UI_Anim animUI;

    [SerializeField]
    private GameObject pauseMenu,MuteButton;

    [SerializeField]
    private Slider volumeSlider;


    [SerializeField]
    private Sprite mute, demute;


 

    public static float globalVolume = 1;
    public static bool isMuted = false;
    private AudioListener listener;


    bool isPaused;

    private void Awake()
    {
        listener = Camera.main.gameObject.GetComponent<AudioListener>();
        pauseMenu.SetActive(false);
        animUI = GetComponent<UI_Anim>();
    }
    public void SetInfo(string info)
    {
        infotxt = info;
    }

    private IEnumerator MainMenu()
    {

        animUI.BUMP(mainMenuButtonTarget as RectTransform);
        while (animUI.getStateAnim() == true)
        {
            yield return null;
        }

        PlayerStat.order = 0;
        PlayerController.isfreeze = false;
        PlayerStat.isFinished = false;
        PlayerStat.lastCoordinate = Vector3.zero;

        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMenu()
    {
        StartCoroutine(MainMenu());
    }

    public void MutingButton()
    {

        StartCoroutine(Muting());

    }

    public void SetVolume(float newVolume)
    {
        globalVolume = newVolume;
    }

    IEnumerator Muting()
    {
        if (isMuted)
        {
            MuteButton.GetComponentInChildren<Image>().sprite = demute;
            isMuted = false;
        }
        else
        {
            MuteButton.GetComponentInChildren<Image>().sprite = mute;
            isMuted = true;
        }

        animUI.BUMP(MuteButton.transform as RectTransform);
        while (animUI.getStateAnim())
        {
            yield return null;
        }

        

        
    }


    private void Update()
    {
        infoText.rectTransform.position = Camera.main.WorldToScreenPoint(textTarget.transform.position);

        deathText.text = $"Deaths : {DeathCounter.DeathNb}";

        infoText.text = infotxt;

        volumeSlider.value = globalVolume;

        if (PlayerStat.isFinished)
        {

            LifeBar.fillAmount = PlayerStat.PlayerStats[Stats.Life] / PlayerStat.PlayerStats[Stats.InitLife];
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pauseMenu.SetActive(false);
                isPaused = false;
                Time.timeScale = 1;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                if (isMuted) MuteButton.GetComponentInChildren<Image>().sprite = mute;
                else MuteButton.GetComponentInChildren<Image>().sprite = demute;
                isPaused = true;
                Time.timeScale = 0;
            }
        }

    }


}
