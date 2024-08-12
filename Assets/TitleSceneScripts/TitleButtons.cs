using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TitleSceneScripts
{
    public class TitleButtons : MonoBehaviour
    {
        public void QuitButton()
        {
            AudioManager.PlaySoundInstance("Audio/Decide");
            Application.Quit();
        }
    }
}
