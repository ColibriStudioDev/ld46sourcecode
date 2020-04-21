using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class FinalSceneScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI deathcount;
    public void MAIN()
    {
        SceneManager.LoadScene("MainMenu");


    }

    public void PLAYING(AudioClip _clip)
    {
        GetComponent<AudioSource>().clip = _clip;
        GetComponent<AudioSource>().Play();
    }


    public void Start()



    {
        deathcount.text = $"Death : {DeathCounter.DeathNb}";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GetComponent<AudioSource>().volume = HUD_Update.globalVolume;
        if (HUD_Update.isMuted) GetComponent<AudioSource>().volume = 0;


        StartCoroutine(startAnim());
    }


    IEnumerator startAnim()
    {
        yield return new WaitForSeconds(3);

        GetComponent<Animator>().SetTrigger("harold");
    }

}
