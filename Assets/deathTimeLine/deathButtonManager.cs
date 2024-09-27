using player.script;
using SaveAndLoad;
using UnityEngine;
using UnityEngine.SceneManagement;
using weapons.Silk;

namespace deathTimeLine
{
    public class DeathButtonManager : MonoBehaviour
    {
        private void Start()
        {
            Destroy(PlayerMove.Instance.gameObject);
            Destroy(SilkThrow.Instance.gameObject);
        }

        public void Load()
        {
            SaveData.LoadScene();
        }

        public void toMain()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
