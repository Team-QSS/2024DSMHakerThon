using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNext3 : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Stage3");
    }
}
