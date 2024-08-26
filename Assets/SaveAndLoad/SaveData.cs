using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector2 = UnityEngine.Vector2;


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
            playerStatus.lastLocation = new Vector2(0, 0);
            playerStatus.boneFireLocation = new Vector2(0, 0);
            playerStatus.stageTag = SceneManager.GetActiveScene().buildIndex+1;
            SaveToJson();
        }
        
        public static void LoadScene()
        {
            LoadFromJson();
            if (playerStatus.stageTag == 0) return;
            SceneManager.LoadScene(playerStatus.stageTag);
        }

        public static void LocatePosition()
        {
            LoadFromJson();
            if (playerStatus.lastLocation == new Vector2(0,0))
            {
                switch (playerStatus.stageTag)
                {
                    case 2:
                        playerStatus.lastLocation = new Vector2(-21.94f,-0.54f);
                        break;
                    case 3:
                        break;
                }
            }
            
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
            Debug.Log(playerStatus.lastLocation);
        }

        public static void DeleteInJson()
        {
            string path = Application.persistentDataPath + "/PlayerStatus.json";
            System.IO.File.Delete(path);
            Debug.Log("file deleted");
        }
    }
    
    [System.Serializable] 
    public class PlayerStatus
    {
        public int stageTag;
        public Dictionary<string, bool> playerAbility;
        public Vector2 lastLocation;
        public Vector2 boneFireLocation;
    }



