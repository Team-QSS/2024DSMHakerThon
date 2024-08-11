using Managers;
using UnityEngine;

namespace TimelinePerStage.title
{
    public class TitleTimeline : MonoBehaviour
    {
        [SerializeField] private GameObject canVas;
        [SerializeField] private GameObject timeLine;
        private void Start()
        {
            AudioManager.SetAsBackgroundMusicInstance("Audio/Cricket", true);
            timeLine.SetActive(false);
        }

        public void TimeLineStart()
        {
            AudioManager.PlaySoundInstance("Audio/Sea");
            canVas.SetActive(false);
            timeLine.SetActive(true);
        }
    }
}
