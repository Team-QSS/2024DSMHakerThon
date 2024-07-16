using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace TitleSceneScripts
{
    public class LoadTitleScene : MonoBehaviour
    {
        private VideoPlayer player;
        private bool statement;

        private void Start()
        {
            player = GetComponent<VideoPlayer>();
        }

        private void Update()
        {
            switch (player.isPlaying)
            {
                case true:
                    statement = true;
                    break;
                case false when statement:
                    SceneManager.LoadScene("TitleScene");
                    break;
            }
        }
    }
}
