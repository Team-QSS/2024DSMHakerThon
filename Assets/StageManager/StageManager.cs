using SaveAndLoad;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StageManager
{
    public class StageManager : MonoBehaviour
    {
        void Start()
        {
            SaveData.SaveScene();
            SaveData.LocatePosition();
        }
    }
}
