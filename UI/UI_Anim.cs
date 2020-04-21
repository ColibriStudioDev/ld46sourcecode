using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DavidOchmann.Animation;
using UnityEngine.UI;
using UnityEngine.Events;

public class UI_Anim : MonoBehaviour
{

    //PROPERTY
    [SerializeField]
    private float bumpForce, bumpTotalDuration;

    UnityAction OnSpriteEnded;

    //PRIVATE GEAR
    DTween dtween = new DTween();
    Tween tween;
    private bool isAnimating = false;

    public bool getStateAnim()
    {
        return isAnimating;
    }

    RectTransform rect;

    public UnityAction OnSpriteEnded1 { get => OnSpriteEnded; set => OnSpriteEnded = value; }


    //TRANSFORM METHOD
    public void BUMP(RectTransform button)
    {
        if (isAnimating) return;

        tween = dtween.To(button.localScale, bumpTotalDuration/2, new { x = bumpForce, y = bumpForce}, Back.EaseInOut);
        tween.OnComplete += dtweenBackToNormal;
        dtween.OnUpdate += dTweenOnUpdate;
        rect = button;
        isAnimating = true;

    }




    public IEnumerator SPRITEANIM(Sprite[] allsprite,float duration, Image renderer ) {
        for(int i = 0; i < allsprite.Length; i++ )
        {
            renderer.sprite = allsprite[(int)i];
            yield return new WaitForSeconds(duration/6);
        }

  
    }
    public IEnumerator SPRITEANIM(Sprite[] allsprite, float duration, SpriteRenderer renderer)
    {
        for (int i = 0; i < allsprite.Length; i++)
        {
            renderer.sprite = allsprite[(int)i];
            yield return new WaitForSeconds(duration / 6);
        }
        renderer.sprite = allsprite[0];
        if (OnSpriteEnded != null)
        {
            OnSpriteEnded1();
        }
    }




    //GEAR
    private void dTweenOnUpdate(Tween tween)
    {        
       rect.localScale = (Vector3)tween.target;
    }
    private void dtweenBackToNormal(Tween tween)
    {
       tween = dtween.To(rect.localScale, bumpTotalDuration/2, new { x = 1, y = 1}, Back.EaseInOut);
       tween.OnComplete += ResetAnim;
    }
    private void ResetAnim(Tween tween)
    {
        isAnimating = false;
    }


    //GETTER
    public bool IsAnimating()
    {
        return isAnimating;
    }


    private void Update()
    {
        dtween.Update();
    }
}
