using UnityEngine;
using UnityEngine.UI;

public class JHA_padeOutEffect : MonoBehaviour
{
    private Image image;
    public bool isEffect;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        Color color = image.color;

        if (isEffect)
        {
            if (color.a < 1)
            {
                color.a += Time.deltaTime;
            }
            image.color = color;
        }
    }
}
