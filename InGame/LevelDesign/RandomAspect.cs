using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class RandomAspect : MonoBehaviour
{
    private SpriteRenderer _renderer;
    [SerializeField]
    private float amplitudeBrightness;
    private bool pileouface()
    {
        int i = (int)Random.Range(0, 2);
        if (i == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _renderer.flipX = pileouface();
        _renderer.flipY = pileouface();

        Color color = Color.white;
        float rd = Random.Range(0.5f - amplitudeBrightness, 0.5f + amplitudeBrightness);
        color.r = rd;
        color.g = rd;
        color.b = rd;

        _renderer.color = color;

    }
}
