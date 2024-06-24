using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Button englishBut,chineseBut,nextWordBut;
    public TextMeshProUGUI chineseText,englishText;
    public List<WordSturt> wordSturts=new List<WordSturt>();
    private int wordIndex;
    private WordSturt currentWord;
    void Start()
    {
        UpdataWord(0);
        englishBut.onClick.AddListener(() => {
            //Player sound 
            SoundManager.instance.PlayerSound(currentWord.englishStr);
        });
        //show chinese  translate
        chineseBut.onClick.AddListener(() => {
            chineseText.enabled = !chineseText.enabled;
        });

        nextWordBut.onClick.AddListener(() => {
            UpdataWord(++wordIndex);
        });
    }

    void UpdataWord(int index) {
        if (index>= wordSturts.Count)
        {
            index = 0;
            wordIndex = 0;
        }
        currentWord = wordSturts[index];
        ShowWord(index);
    }
    void ShowWord(int index) {
        englishText.text = currentWord.englishStr;
        chineseText.text = currentWord.chineseStr;
        //chineseText.enabled=false;
    }
}
[System.Serializable]
public class WordSturt {
    public string englishStr,chineseStr;
}
