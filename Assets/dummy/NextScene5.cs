using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene5 : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CrowChacing");
    }
}
