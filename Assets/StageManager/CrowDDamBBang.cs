using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageManager
{
    public class CrowDDamBBang : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadScene("CrowChacing");
        }
    }
}
