using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCH_GameManager : MonoBehaviour
{
    public static SCH_GameManager instance;
    [Header("#Game Control")]
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 2 * 10f;

    [Header("# Player Info")]
    public float health;
    public float maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

    [Header("# Game Object")]
    public Player player;
    public Enemy1 monster;
    public Result uiResult;
    public HA_titleScene titleScene;

    void Start()
    {
        health = maxHealth;
        isLive = true;
        Resume();
    }
    void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if (!isLive)
            return;
        gameTime += Time.deltaTime;
    }
    //public void GameStart()
    //{
    //    health = maxHealth;
    //    isLive = true;
    //    Resume();
    //}

    public void GameOver()
    {
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        isLive = false;
        yield return new WaitForSeconds(0.5f);  //0.5√  µÙ∑π¿Ã
        uiResult.gameObject.SetActive(true);
        uiResult.Lose();
        Stop();

    }

    public void GameVictroy()
    {
        StartCoroutine(GameVictroyRoutine());
    }

    IEnumerator GameVictroyRoutine()
    {
        isLive = false;
        yield return new WaitForSeconds(0.5f);  //0.5√  µÙ∑π¿Ã
        uiResult.gameObject.SetActive(true);
        uiResult.Win();
        Stop();

    }
    public void GameRetry()
    {
        SceneManager.LoadScene(1);
    }


    public void GetExp()
    {
        if (!isLive)
            return; 
        exp++;
        if(exp == nextExp[Mathf.Min(level,nextExp.Length-1)])
        {
            level++;
            exp = 0;
        }
    }
    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}
