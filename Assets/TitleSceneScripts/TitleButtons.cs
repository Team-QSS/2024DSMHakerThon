using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitleSceneScripts
{
    public class TitleButtons : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene("IntroScene");
        }
        public void QuitButton()
        {
            Application.Quit();
        }
    }
}
