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
        public static TalkManager instance;
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
            talkTextUI = talkTextPanel.GetComponentInChildren<TextMeshProUGUI>();
            talkerOnScene[0].SetActive(false);
            talkerOnScene[1].SetActive(false);
            talkerOnScene[2].SetActive(false);
            talkTextPanel.SetActive(false);
        }

        public void GoTalk(string textPath)
        {
            var fileInfo = new FileInfo(textPath);
            string value;
            progress = -1;
            if (fileInfo.Exists)
            {
                var reader = new StreamReader(textPath);
                value = reader.ReadToEnd();
                reader.Close();
            }

            else
                value = textPath;

            TalkSetting(value);
        }

        private void TalkSetting(string texts)
        {
            texts = texts.Replace("\n", "");
            texts = texts.Split("*/")[1];
            var textInfo = texts.Split("--info End--")[0];
            textInfo = textInfo.Replace("--Character Info--", "");
            texts = texts.Split("--info End--")[1];
            int index = 0;
            foreach (var i in textInfo.Split("_"))
            {
                Enum.TryParse(i,true, out InstanceTalkers[index++]);
            }
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
            if (!playingCheck)
            {
                progress++;
                Debug.Log(lines[progress]+progress);
                if (lines[progress].Equals("exit"))
                {
                    TalkEndFlow();
                    return;
                }//ex:exit
                if (lines[progress].Contains("insert"))
                {
                    var pos = Enum.Parse<InsertPositions>(lines[progress].Split("-")[2]);
                    Insert(pos,talkers[(int)Enum.Parse<TalkersName>(lines[progress].Split("-")[1])]);
                    return;
                }//ex:insert-괴조-Right
                if (lines[progress].Contains("out"))
                {
                    var pos =Enum.Parse<InsertPositions>(lines[progress].Split("-")[1]);
                    if(talkerOnScene[(int)pos].GetComponent<Image>().sprite is not null)
                        GetDown(pos);
                    return;
                }//ex:out-Right
                if (lines[progress].Contains("focus"))
                {
                    var pos =Enum.Parse<InsertPositions>(lines[progress].Split("-")[1]);
                    if(talkerOnScene[(int)pos].GetComponent<Image>().sprite is not null)
                        Focus(pos);
                    return;
                }//focus-Right
                if (lines[progress].Contains("disFocus"))
                {
                    DisFocus();
                    return;
                }//disFocus
                var text = lines[progress];
                playCoroutine = TypingText(text);
                StartCoroutine(playCoroutine);
            }
            else
            {
                if (playCoroutine is null) return;
                StopCoroutine(playCoroutine);
                talkTextUI.text = lines[progress];
                playingCheck = false;
            }
        
        }
    
        private IEnumerator TypingText(string text)
        {
            playingCheck = true;
            for (var i = 0; i < text.Length + 1; i++)
            {
                var pageText = text[..i];
                talkTextUI.text = pageText;
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

        IEnumerator FalseMaker(int pos)
        {
            yield return new WaitForSeconds(1f);
            talkerOnScene[pos].GetComponent<Image>().sprite = null;
            talkerOnScene[pos].SetActive(false);
        }
        private void Focus(InsertPositions pos)
        {
            if (focusedTalkerTemp != pos)
            {
                DisFocus();
                focusedTalkerTemp = pos;
                talkerOnScene[(int)pos].GetComponent<Animator>().Play("focus");
                return;
            }
            focusedTalkerTemp = pos;
            talkerOnScene[(int)pos].GetComponent<Animator>().Play("focus");
            ClickButton();
        }

        private void DisFocus()
        {
            if (focusedTalkerTemp is not null)
            {
                if (talkerOnScene[(int)focusedTalkerTemp] is not null)
                {
                    talkerOnScene[(int)focusedTalkerTemp].GetComponent<Animator>().Play("disfocus");
                    Debug.Log($"disfocused{focusedTalkerTemp}");
                }
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
