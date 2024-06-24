using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SoundManager : MonoBehaviour
{
    private string url = "https://dds.dui.ai/runtime/v1/synthesize?voiceId=linbaf_qingxin&text=";
    private string url1 = "&speed=1&volume=50&audioType=mp3";
    private AudioSource audioSource;
    public static SoundManager instance;
    private void Awake()
    {
        instance = this;
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayerSound(string word)
    {
        StartCoroutine(DownloadAndPlayAudio(word));
    }

    

    IEnumerator DownloadAndPlayAudio(string word)
    {
        string tempString = url + word+ url1;
        Debug.Log(tempString);
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(tempString, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}
