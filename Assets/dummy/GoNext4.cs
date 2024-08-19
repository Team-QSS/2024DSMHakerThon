using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext4 : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LastScene");
    }
}
