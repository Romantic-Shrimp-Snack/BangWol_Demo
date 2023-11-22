using UnityEngine;
using UnityEngine.SceneManagement;

public class JHA_titleScene : MonoBehaviour
{
    public static GameManager instance2;
    public GameObject SelectBtn;
    public GameObject teamAni;
    public GameObject jongAni;

    public GameObject padeIn;
    public GameObject padeOut;
    
    void Start()
    {
        jongAni.SetActive(false);
        SelectBtn.SetActive(false);
        //padeIn.SetActive(false);
        //padeOut.SetActive(false);

        teamAni.GetComponent<Animator>().SetBool("isStart", true);
        Invoke("padeInEffect", 5f);
    }

    public void padeInEffect()
    {
        jongAni.SetActive(true);
        teamAni.SetActive(false);

        //padeIn.SetActive(true);
        //padeIn.GetComponent<HA_padeInEffect>().isEffect = true;
    }

    public void BtnStart()
    {
        SelectBtn.SetActive(true);
        jongAni.GetComponent<Animator>().SetBool("isClick", true);
        jongAni.GetComponent<AudioSource>().Play();
        Invoke("SceneChange", 3f);
        //Invoke("padeOutEffect", 3f);
    }

    public void padeOutEffect()
    {
        //padeOut.SetActive(true);
        //padeOut.GetComponent<HA_padeOutEffect>().isEffect = true;
        Invoke("SceneChange", 3f);
    }
    
    public void SceneChange()
    {
        SceneManager.LoadScene("textAni");
    }
}
