using UnityEngine;
using UnityEngine.UI;

public class JHA_padeInEffect : MonoBehaviour
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
            if (color.a > 0)
            {
                color.a -= Time.deltaTime;
            }
            image.color = color;
        }
    }
}
