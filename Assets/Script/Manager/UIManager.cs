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

    // 이 함수를 버튼에 등록할 때 게임 오브젝트 매개 변수로 등록할 수 있습니다.
    // 등록한 게임 오브젝트를 비활성화 할 수 있습니다.
    //public void GameStart(GameObject mainMenu) // 코드가 간결해지고 유지보수 쉬워짐
    public void GameStart() // 9-15 지워주기
    {
        StartCoroutine(FadeIn(1)); // 9-15 코르틴 함수 실행

        //mainMenu.SetActive(false); // 9-15 지워주기

        GameManager.instance.state = true; //9-14 

        //SpawnManager.action(); // 9-14 호출

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // 움겨 오기 9-11 마우스 락 풀기

        // Time Scale의 영향을 받지 않는 시간 입니다.
        // Time.unscaledDeltaTime
    }

    // 매개 변수 time은 FadeIn 되는 시간을 조절하는 변수입니다.
    private IEnumerator FadeIn(float time) //9-15
    {
        // 컬러 변수
        Color color = fadePanel.color;

        //   컬러의 알파값이 0보다 작다면 실행되게
        // Image의 알파 값이 0이 되는 순간 While문을 탈출합니다.
        // 0 ~ 255 (0 ~ 1 ) 비율로 계산
        while(color.a < 0f)
        {
            // 컬러의 알파 값을 천천히 줄이기
            color.a -= Time.deltaTime / time;
            fadePanel.color = color;
            // 알파값이 깍인 값이 페널에 들어감.

            // 제어권 유니티 한태 돌려주기
            yield return null;
        }

        // 코르틴 함수가 다 끝났을 때 mainMenu를 비활성화 합니다.
        mainMenu.SetActive(false); //9-15 일루 이동
    }
}
