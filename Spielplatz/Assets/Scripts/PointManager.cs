using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class PointManager : ScriptableObject
{
    

    public int score = 0;
    public int highscore = 0;

    void Awake()
    {
        
        score = 0;
    }
    public void AddPoint()
    {
        score += 1;      
        if (highscore < score)
            highscore = score;
    }
}
