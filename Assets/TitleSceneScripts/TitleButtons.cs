using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitleSceneScripts
{
    public class TitleButtons : MonoBehaviour
    {
        public void StartButton()
        {
            SceneManager.LoadScene("Stage1");
        }
        public void QuitButton()
        {
            Application.Quit();
        }
    }
}
