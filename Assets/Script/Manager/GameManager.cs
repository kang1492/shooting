using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ��𼭵� ���� ����

    public int score;


    void Start()
    {   
        // ���� �����͸� ������ ������ �� �ҷ��ɴϴ�.
        Load();

        if(instance == null)
        {
            instance = this;
        }
    }

    public void Save()
    {
        // PlayerPrefs.SetInt �������� �����ϴ� �Լ�
        // KEY - VALUE�� ������ �����մϴ�.
        PlayerPrefs.SetInt("Score", score);
    }

    public void Load()
    {
        // PlayerPrefs.GetInt �������� �ҷ����� �Լ�
        score = PlayerPrefs.GetInt("Score");
    }
}
