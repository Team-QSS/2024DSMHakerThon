using UnityEngine;
using UnityEngine.SceneManagement;

namespace TimelinePerStage.stage1
{
    public class GotoScene2 : MonoBehaviour
    {
        private void Start()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Stage2_Rework");
        }
    }
}
