using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

    public class SaveData : MonoBehaviour
    {
        public PlayerStatus playerStatus= new();
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                //playerStatus.stageTag = SceneManager.GetActiveScene().buildIndex;
                SaveToJson();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadFromJson();
            }
        }

        public void SaveToJson()
        {
            string playerData = JsonUtility.ToJson(playerStatus);
            string path = Application.persistentDataPath + "/PlayerStatus.json";
            Debug.Log(path);
            System.IO.File.WriteAllText(path,playerData);
            Debug.Log(playerStatus);
            Debug.Log("saved");

        }

        public void LoadFromJson()
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
    }


