
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class SaveData : MonoBehaviour
    {
        public static PlayerStatus playerStatus= new();

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public static void SaveScene()
        {
            playerStatus.stageTag = SceneManager.GetActiveScene().buildIndex;
            SaveToJson();
        }

        public static void SavePreviousScene()
        {
            playerStatus.stageTag = SceneManager.GetActiveScene().buildIndex+1;
            SaveToJson();
        }

        public static void LoadScene()
        {
            LoadFromJson();
            SceneManager.LoadScene(playerStatus.stageTag);
        }

        public static void SaveToJson()
        {
            string playerData = JsonUtility.ToJson(playerStatus);
            string path = Application.persistentDataPath + "/PlayerStatus.json";
            Debug.Log(path);
            System.IO.File.WriteAllText(path,playerData);
            Debug.Log(playerStatus);
            Debug.Log("saved");

        }

        public static void LoadFromJson()
        {
            string path = Application.persistentDataPath + "/PlayerStatus.json";
            string playerData = System.IO.File.ReadAllText(path);
            playerStatus = JsonUtility.FromJson<PlayerStatus>(playerData);
            Debug.Log(playerStatus.stageTag);
        }
    }
    
    [System.Serializable] 
    public class PlayerStatus
    {
        public int stageTag;
        public Dictionary<string, bool> playerAbility;
        public Dictionary<string, Vector2> lastLocation;
    }


