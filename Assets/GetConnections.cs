using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Game
{
    private int minutesPlayed;
    
    public Game(int minutesPlayed)
    {
        this.minutesPlayed = minutesPlayed;
    }

    public void AddTime(int minutes)
    {
        minutesPlayed += minutes;
    }

    public int MinutesPlayed
    {
        get => minutesPlayed;
        set => minutesPlayed = value;
    }

    public float HoursPlayed
    {
        get => (float) this.minutesPlayed / 60;
    }
}

public class GetConnections : MonoBehaviour
{
    private GameObject connections;

    [SerializeField]
    private int addTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText());

        Game game = new Game(200);

        print("Minutes played: " + game.MinutesPlayed);
        print("Hours played: " + game.HoursPlayed);
        
        game.AddTime(50);
        print("Minutes played: " + game.MinutesPlayed);
    }

    // Update is called once per frame
    void Update()
    {
        print(Time.deltaTime);
    }
    
    IEnumerator GetText() {
        UnityWebRequest www = new UnityWebRequest("https://gist.githubusercontent.com/OskarKaminski/3da4b012a9d9ed85a948d44165aa0b33/raw/30577d7a5ed1327555b3838204672dd46fc79125/mocked-connections.json");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            
            var connectionsText = www.downloadHandler.text;
            Debug.Log(connectionsText);
        }
    }
}
