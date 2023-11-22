using UnityEngine;
using UnityEngine.SceneManagement;

public class JHA_textAniScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SceneChange", 13f);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
