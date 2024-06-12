using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine;


public class NativeAPI
{
#if UNITY_IOS && !UNITY_EDITOR
  [DllImport("__Internal")]
  public static extern void sendMessageToMobileApp(string message);
#endif
}

//Score class
public class Score
{

    public int score;
    public string date;
    public Score(int score, string date)
    {
        this.score = score;
        this.date = date;
    }
}

public class MessageToReactScript : MonoBehaviour
{

    private Text _score;

    public void ButtonPressed()
    {
        //getting current date in ISO format
        var date = DateTime.Now.ToString("o");
        //getting current score from UI
        _score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        //creating an instance of Score class
        Score score = new(int.Parse(_score.text), date);
        //pare score object to json (we sending a string)
        string scoreJSON = JsonUtility.ToJson(score);

        print(scoreJSON);

        if (Application.platform == RuntimePlatform.Android)
        {
            using (AndroidJavaClass jc = new AndroidJavaClass("com.azesmwayreactnativeunity.ReactNativeUnityViewManager"))
            {
                //send message to android
                jc.CallStatic("sendMessageToMobileApp", scoreJSON);
            }
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
#if UNITY_IOS && !UNITY_EDITOR
            //send message to iOS
            NativeAPI.sendMessageToMobileApp(scoreJSON);
#endif
        }
    }

}