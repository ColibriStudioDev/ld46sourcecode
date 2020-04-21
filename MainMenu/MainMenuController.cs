using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private AudioManager manager;
    [SerializeField]
    private UI_Anim uicontroller;
    [SerializeField]
    private Sprite[] storysrite;
    [SerializeField]
    private FadingController fading;
    [SerializeField]
    private GameObject StoryCanvas,storyRenderer;
    [SerializeField]
    private float StoryDuration,AnimDuration;
   
    void Start()
    {
        manager.PlayMusic("MainMenu");
        StoryCanvas.SetActive(false);
    }


    public void EXIT()
    {
        Application.Quit();
    }

    public void PLAY()
    {
        DeathCounter.DeathNb = 0;
        FadingController.onFadingFinished += SHOWSTORY;
        fading.triggerIFading();
        
    }


    public void SHOWSTORY()
    {
        FadingController.onFadingFinished -= SHOWSTORY;
        StoryCanvas.SetActive(true);
        StartCoroutine(uicontroller.SPRITEANIM(storysrite, AnimDuration, storyRenderer.GetComponent<Image>()));
        StartCoroutine(startLevel());
        
    }


    private IEnumerator startLevel()
    {
        yield return new WaitForSeconds(StoryDuration);
        SceneManager.LoadSceneAsync("Intro00");
    }

    void Update()
    {
        



    }
}
