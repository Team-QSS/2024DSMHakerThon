using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Talk
{
    public class TalkManager : MonoBehaviour
    {
        private static TalkManager _instance;
        [SerializeField] private Sprite[] talkers = new Sprite[10];
        private static readonly TalkersName[] InstanceTalkers = new TalkersName[10];
        [SerializeField] private GameObject[] talkerOnScene = new GameObject[3];
        private bool playingCheck;
        private int lineLength;
        private string[] lines;
        private int progress;
        private InsertPositions? focusedTalkerTemp;
        [SerializeField] private float typingTime;
        private TextMeshProUGUI talkTextUI;
        [SerializeField] private GameObject talkTextPanel;

        private void Awake()
        {
            _instance = this;
            talkTextUI = talkTextPanel.GetComponentInChildren<TextMeshProUGUI>();
            talkerOnScene[0].SetActive(false);
            talkerOnScene[1].SetActive(false);
            talkerOnScene[2].SetActive(false);
            talkTextPanel.SetActive(false);
        }

        public static TalkManager GetInstance()
        {
            return _instance;
        }
        
        public void GoTalk(string textPath)
        {
            var fileInfo = new FileInfo(textPath);
            progress = -1;
            string value;
            if (fileInfo.Exists)
            {
                var reader = new StreamReader(textPath);
                value = reader.ReadToEnd();
                reader.Close();
            } else value = textPath;
            TalkSetting(value);
        }

        private void TalkSetting(string texts)
        {
            texts = texts.Replace("\r\n", "").Replace("\n", "");
            texts = texts[texts.IndexOf("*/", StringComparison.Ordinal)..];
            var textInfo = texts.Split("--info End--")[0];
            textInfo = textInfo.Replace("--Character Info--", "");
            texts = texts.Split("--info End--")[1];
            var index = 0;
            foreach (var s in textInfo.Split(",")) if (!Enum.TryParse(s,true, out InstanceTalkers[index++])) InstanceTalkers[index-1] = TalkersName.Whitefish;
            lines = texts.Split("|");
            talkTextPanel.SetActive(true);
            ClickButton();
        }
        private enum TalkersName
        {
            Sanabang,
            Crow,
            Spider,
            Mantis,
            Developer,
            JhGhost,
            Sans,
            Whitefish
        }
        private IEnumerator playCoroutine;

        public TalkManager(GameObject talkTextPanel)
        {
            this.talkTextPanel = talkTextPanel;
        }

        public void ClickButton()
        {
            if (playingCheck)
            {
                if (playCoroutine is null) return;
                StopCoroutine(playCoroutine);
                talkTextUI.text = lines[progress];
                playingCheck = false;
                return;
            }
            progress++;
            Debug.Log(lines[progress] + progress);
            var data = lines[progress].Split("-");
            switch (data[0])
            {
                case "exit":
                    TalkEndFlow();
                    break; //ex:exit
                case "insert":
                    Insert(Enum.Parse<InsertPositions>(data[2]), talkers[(int)Enum.Parse<TalkersName>(data[1])]);
                    break; //ex:insert-괴조-Right
                case "out":
                {
                    var pos = Enum.Parse<InsertPositions>(data[1]);
                    if (talkerOnScene[(int)pos].GetComponent<Image>().sprite) GetDown(pos);
                    break; //ex:out-Right
                }
                case "focus":
                {
                    var pos = Enum.Parse<InsertPositions>(data[1]);
                    if (talkerOnScene[(int)pos].GetComponent<Image>().sprite) Focus(pos);
                    break; //focus-Right
                }
                case "disFocus":
                    DisFocus();
                    break; //disFocus
                default:
                    StartCoroutine(playCoroutine = TypingText(lines[progress]));
                    break;
            }
        }

        private IEnumerator TypingText(string text)
        {
            playingCheck = true;
            talkTextUI.text = "";
            foreach (var s in text)
            {
                talkTextUI.text += s;
                yield return new WaitForSeconds(typingTime);
            }
            playingCheck = false;
        }

        private enum InsertPositions
        {
            Left,
            Center,
            Right
        }

        private void Insert(InsertPositions pos, Sprite insertThing)
        {
            focusedTalkerTemp = pos;
            talkerOnScene[(int)pos].GetComponent<Image>().sprite = insertThing;
            talkerOnScene[(int)pos].SetActive(true);
            talkerOnScene[(int)pos].GetComponent<Animator>().Play("insert");
            ClickButton();
        }

        private void GetDown(InsertPositions pos)
        {
            talkerOnScene[(int)pos].GetComponent<Animator>().Play("out");
            StartCoroutine(FalseMaker((int)pos));
            ClickButton();
        }

        private IEnumerator FalseMaker(int pos)
        {
            yield return new WaitForSeconds(1f);
            talkerOnScene[pos].GetComponent<Image>().sprite = null;
            talkerOnScene[pos].SetActive(false);
        }
        private void Focus(InsertPositions pos)
        {
            if (focusedTalkerTemp != pos) DisFocus(); else ClickButton();
            focusedTalkerTemp = pos;
            talkerOnScene[(int)pos].GetComponent<Animator>().Play("focus");
        }

        private void DisFocus()
        {
            if (focusedTalkerTemp != null && talkerOnScene[(int)focusedTalkerTemp])
            {
                talkerOnScene[(int)focusedTalkerTemp].GetComponent<Animator>().Play("disfocus");
                Debug.Log($"disFocused{focusedTalkerTemp}");
            }
            focusedTalkerTemp = null;
            ClickButton();
        }
        private void TalkEndFlow()
        {
            talkTextPanel.SetActive(false);
            talkerOnScene[0].SetActive(false);
            talkerOnScene[1].SetActive(false);
            talkerOnScene[2].SetActive(false);
        }
    }
}
