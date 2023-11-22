using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Time,PlayerHealth,BossHealth}
    public InfoType type;
    Text myText;
    Slider mySlider;

    void Awake()
    {
        myText= GetComponent<Text>();
        mySlider= GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Time:
                float remainTime = GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min,sec);
                break;
            case InfoType.PlayerHealth:
                float curHealth = GameManager.instance.player.health;
                float maxHealth = GameManager.instance.player.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
            case InfoType.BossHealth:
                float bossCurHealth = GameManager.instance.monster.health;
                float bossMaxHealth = GameManager.instance.monster.maxHealth;
                mySlider.value = bossCurHealth / bossMaxHealth;
                break;
        }
    }
}
