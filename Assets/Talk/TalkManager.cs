using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;

namespace Talk
{
    public class TalkManager : MonoBehaviour
    {
        public static TalkManager instance;
        [SerializeField] private GameObject[] talkers = new GameObject[10];
        private readonly TalkersName[] instanceTalkers = new TalkersName[10];
        private readonly GameObject[] talkerOnScene = new GameObject[3];
        private bool playingCheck;
        private int lineLength;
        private string[] lines;
        private int progress;
        private InsertPositions focusedTalkerTemp;
        [SerializeField] private float typingTime;
        [SerializeField] private TextMeshProUGUI talkTextUI;

        public void GoTalk(string textPath)
        {
            var fileInfo = new FileInfo(textPath);
            string value;
            progress = 0;
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
            texts = texts.Split("--info End--")[1];
            var textInfos = textInfo.Split("|");
            lineLength = int.Parse(textInfos[0].Split(":")[1]);
            int index = 0;
            foreach (var i in textInfos[1].Split("_"))
            {
                Enum.TryParse(i.Split(":")[1],true, out instanceTalkers[index++]);
            }
            lines = texts.Split("|");
        }
        private enum TalkersName
        {
            DefaultMan
        }
        private IEnumerator playCoroutine;
        public void ClickButton()
        {
            if (!playingCheck)
            {
                progress++;
                if (lines[progress].Equals("exit"))
                {
                    TalkEndFlow();
                    return;
                }//exit
                if (lines[progress].Contains("insert"))
                {
                    var pos =Enum.Parse<InsertPositions>(lines[progress].Split("-")[2]);
                    if(talkerOnScene[(int)pos] is not null)
                        GetDown(pos);
                    Insert(pos,talkers[int.Parse(lines[progress].Split("-")[1])]);
                    progress++;
                }//insert-괴조-Right

                if (lines[progress].Contains("focus"))
                {
                    var pos =Enum.Parse<InsertPositions>(lines[progress].Split("-")[1]);
                    if(talkerOnScene[(int)pos] is not null)
                        Focus(pos);
                    progress++;
                }//focus-Right
                var text = lines[progress].Split(":")[1];
                playCoroutine = TypingText(text);
            
                StartCoroutine(playCoroutine);
            }
            else
            {
                if (playCoroutine is null) return;
                StopCoroutine(playCoroutine);
                talkTextUI.text = lines[progress];
            }
        
        }
    
        private IEnumerator TypingText(string text)
        {
            playingCheck = false;
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

        private void Insert(InsertPositions pos, GameObject insertThing)
        {
            talkerOnScene[(int)pos] = insertThing;
            insertThing.SetActive(true);
            insertThing.GetComponent<Animator>().Play("GGalanghan Insert ANimation BRo;");
        }

        private void GetDown(InsertPositions pos)
        {
            talkerOnScene[(int)pos].GetComponent<Animator>().Play("fuckingGetDownBRO;;;;;;;;;;");
            talkerOnScene[(int)pos] = null;
        }

        private void Focus(InsertPositions pos)
        {
            talkerOnScene[(int)pos].GetComponent<Animator>().Play("focus");
        }
        private void TalkEndFlow()
        {
            //다끄기
        }
    }
}
