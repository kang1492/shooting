using UnityEngine;
using UnityEngine.UI;
using System.Collections; //9-15

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;
    //[SerializeField] GameManager mainMenu; // 9-13
    
    [SerializeField] Image fadePanel; //9-15
    [SerializeField] GameObject mainMenu; //9-15

    void Start()
    {
        
    }

    
    void Update()
    {
        score.text = "Kill : " + GameManager.instance.score; 
    }

    // �� �Լ��� ��ư�� ����� �� ���� ������Ʈ �Ű� ������ ����� �� �ֽ��ϴ�.
    // ����� ���� ������Ʈ�� ��Ȱ��ȭ �� �� �ֽ��ϴ�.
    //public void GameStart(GameObject mainMenu) // �ڵ尡 ���������� �������� ������
    public void GameStart() // 9-15 �����ֱ�
    {
        StartCoroutine(FadeIn(1)); // 9-15 �ڸ�ƾ �Լ� ����

        //mainMenu.SetActive(false); // 9-15 �����ֱ�

        GameManager.instance.state = true; //9-14 

        //SpawnManager.action(); // 9-14 ȣ��

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // ��� ���� 9-11 ���콺 �� Ǯ��

        // Time Scale�� ������ ���� �ʴ� �ð� �Դϴ�.
        // Time.unscaledDeltaTime
    }

    // �Ű� ���� time�� FadeIn �Ǵ� �ð��� �����ϴ� �����Դϴ�.
    private IEnumerator FadeIn(float time) //9-15
    {
        // �÷� ����
        Color color = fadePanel.color;

        //   �÷��� ���İ��� 0���� �۴ٸ� ����ǰ�
        // Image�� ���� ���� 0�� �Ǵ� ���� While���� Ż���մϴ�.
        // 0 ~ 255 (0 ~ 1 ) ������ ���
        while(color.a < 0f)
        {
            // �÷��� ���� ���� õõ�� ���̱�
            color.a -= Time.deltaTime / time;
            fadePanel.color = color;
            // ���İ��� ���� ���� ��ο� ��.

            // ����� ����Ƽ ���� �����ֱ�
            yield return null;
        }

        // �ڸ�ƾ �Լ��� �� ������ �� mainMenu�� ��Ȱ��ȭ �մϴ�.
        mainMenu.SetActive(false); //9-15 �Ϸ� �̵�
    }
}
