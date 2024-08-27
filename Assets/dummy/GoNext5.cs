using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext5 : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("FinalScene");
    }
}
