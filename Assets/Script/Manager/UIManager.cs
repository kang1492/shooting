using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] GameManager mainMenu; // 9-13

    void Start()
    {
        
    }

    
    void Update()
    {
        score.text = "Kill : " + GameManager.instance.score; 
    }

    // �� �Լ��� ��ư�� ����� �� ���� ������Ʈ �Ű� ������ ����� �� �ֽ��ϴ�.
    // ����� ���� ������Ʈ�� ��Ȱ��ȭ �� �� �ֽ��ϴ�.
    public void GameStart(GameObject mainMenu) // �ڵ尡 ���������� �������� ������
    {
        mainMenu.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // ��� ���� 9-11 ���콺 �� Ǯ��
    }
}
