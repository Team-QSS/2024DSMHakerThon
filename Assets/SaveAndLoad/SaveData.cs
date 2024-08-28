using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveAndLoad
{
    public static class SaveData
    {
        public static PlayerStatus playerStatus = new();
        private static readonly string SavePath = Application.persistentDataPath + "/PlayerStatus.json";

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

        public static void SetAbilities(string abilityname)
        {
            playerStatus.playerAbility.Add(abilityname);
            Debug.Log(playerStatus.playerAbility);
            SaveToJson();
        }

        public static void GetAbilities()
        {
            LoadFromJson();
            if (playerStatus.playerAbility.Contains("parry"))
            {
                Parry.unlockParry = true;
            }
            if (playerStatus.playerAbility.Contains("dash"))
            {
                PlayerMove.unlockDash = true;
            }
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
            if (playerStatus.lastLocation != new Vector2(0, 0)) return;
            switch (playerStatus.stageTag)
            {
                case 2:
                    playerStatus.lastLocation = new Vector2(-21.94f,-0.54f);
                    break;
                case 3:
                    break;
            }

        }
        public static void SaveToJson() => File.WriteAllText(SavePath,JsonUtility.ToJson(playerStatus));

        public static void LoadFromJson()
        {
            if (File.Exists(SavePath)) playerStatus = JsonUtility.FromJson<PlayerStatus>(File.ReadAllText(SavePath));
        }

        public static void DeleteInJson() => File.Delete(SavePath);
    }
    
    [Serializable]
    public class PlayerStatus
    {
        public int stageTag;
        public HashSet<string> PlayerAbility;
        public Vector2 lastLocation;
        public Vector2 boneFireLocation;
    }
}