using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 어디서든 접근 가능

    public int score;

    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
