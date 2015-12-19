using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[RequireComponent(typeof(Camera))]
public class gameController : MonoBehaviour {

    public new Camera camera;

    public static gameController controller;

    private static List<Player> contestants = new List<Player>();

    int numContestants;

    // Use this for bambooyah
    void Awake() {
        ReadInContestants();
        CheckContestants();
        Debug.Log(numContestants);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ReadInContestants()
    {
        string line;
        StreamReader file = new StreamReader(Application.dataPath + "/resources/files/contestants.txt");
        while((line = file.ReadLine()) != null)
        {
            contestants.Add(new Player(4, numContestants, line));
            numContestants++;
        }
        
    }

    void CheckContestants()
    {
        foreach (Player contestant in contestants)
        {
            Debug.Log(contestant.GetName());
        }
    }
    

    
}


public class Player
{
    int m_seed;
    int m_loses;
    int m_place;
    string m_song;
    string m_name;

    public Player(int place, int seed, string name)
    {
        m_loses = 0;
        m_place = place;
        m_seed = seed;
        m_name = name;
        
    }

    public string GetName()
    {
        return m_name;
    }
}
