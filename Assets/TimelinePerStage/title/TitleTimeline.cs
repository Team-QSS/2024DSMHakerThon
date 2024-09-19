using Managers;
using player.script;
using SaveAndLoad;
using UnityEngine;
using weapons.Silk;

namespace TimelinePerStage.title
{
    public class TitleTimeline : MonoBehaviour
    {
        [SerializeField] private GameObject canVas;
        [SerializeField] private GameObject timeLine;
        private void Start()
        {
            AudioManager.SetAsBackgroundMusicInstance("Audio/MAIN_THEME", true);
            timeLine.SetActive(false);
            Destroy(PlayerMove.Instance.gameObject);
            Destroy(SilkThrow.Instance.gameObject);
        }

        public void TimeLineStart()
        {
            AudioManager.PlaySoundInstance("Audio/Decide");
            AudioManager.PlaySoundInstance("Audio/Sea");
            canVas.SetActive(false);
            timeLine.SetActive(true);
            SaveData.DeleteInJson();
            SaveData.SavePreviousScene();
        }

        public void Load()
        {
            SaveData.LoadScene();
        }
    }
}
