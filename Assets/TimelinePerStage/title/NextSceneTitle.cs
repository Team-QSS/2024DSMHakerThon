using UnityEngine;
using UnityEngine.SceneManagement;

namespace TimelinePerStage.title
{
    public class NextSceneTitle : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("Stage1");
        }
    }
}

