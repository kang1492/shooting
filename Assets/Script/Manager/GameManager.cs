using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 어디서든 접근 가능

    public int score;


    void Start()
    {   
        // 게임 데이터를 게임이 시작할 때 불러옵니다.
        Load();

        if(instance == null)
        {
            instance = this;
        }
    }

    public void Save()
    {
        // PlayerPrefs.SetInt 정수값을 저장하는 함수
        // KEY - VALUE를 가지고 저장합니다.
        PlayerPrefs.SetInt("Score", score);
    }

    public void Load()
    {
        // PlayerPrefs.GetInt 정수값을 불러오는 함수
        score = PlayerPrefs.GetInt("Score");
    }
}
