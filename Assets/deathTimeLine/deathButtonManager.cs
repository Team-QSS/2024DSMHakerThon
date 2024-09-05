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
            PlayerMove.Instance.gameObject.SetActive(false);
        }

        public void Load()
        {
            Destroy(PlayerMove.Instance.gameObject);
            Destroy(SilkThrow.Instance.gameObject);
            SaveData.LoadScene();
        }

        public void toMain()
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
