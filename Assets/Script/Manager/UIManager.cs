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

    // 이 함수를 버튼에 등록할 때 게임 오브젝트 매개 변수로 등록할 수 있습니다.
    // 등록한 게임 오브젝트를 비활성화 할 수 있습니다.
    public void GameStart(GameObject mainMenu) // 코드가 간결해지고 유지보수 쉬워짐
    {
        mainMenu.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // 움겨 오기 9-11 마우스 락 풀기
    }
}
