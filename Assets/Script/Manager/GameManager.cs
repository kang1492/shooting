using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // ��𼭵� ���� ����

    public int score;

    public int dragon; // 9-15 ������ �����Ѱ� ����

    // bool ������ �ʱ�ȭ�� ���� ������ false ���� �ڵ����� ���ϴ�.
    public bool state; //9-14

    

    //void Start()
    private void Awake() // 9-13 ��ŸƮ �Լ� ������ ����˴ϴ�.
    {       

        if(instance == null)
        {
            instance = this;
        }

        // ���� �����͸� ������ ������ �� �ҷ��ɴϴ�.
        Load();
    }

    public void Save()
    {
        // PlayerPrefs.SetInt �������� �����ϴ� �Լ�
        // KEY - VALUE�� ������ �����մϴ�.
        PlayerPrefs.SetInt("Score", score);

        PlayerPrefs.SetInt("Dragon", dragon); // 9-15 ������ ���� ����
    }

    public void Load()
    {
        // PlayerPrefs.GetInt �������� �ҷ����� �Լ�
        score = PlayerPrefs.GetInt("Score");

        dragon = PlayerPrefs.GetInt("Dragon"); // 9-15
    }
}
