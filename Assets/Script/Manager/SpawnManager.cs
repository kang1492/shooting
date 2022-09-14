//using System; //9-14 안되는 사람꺼
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //               배열 선언   
    [SerializeField] Transform[ ] randomPosition;

    //static public Action action; //9-14 안되는 사람꺼

    float timer;

    //public void Awake() // 9-14 안되는 사람꺼
    //{
    //    action = () => { InvokeRepeating(nameof(CreateInfinite), 0, 5); };
    //}

    void Start()  //9-14 안되는 사람꺼
    {   // 함수 호출
        //CreateInfinite(); // 시작시 한번 호출

        // Invoke : 지정된 시간 후에 함수를 호출하는 함수입니다.
        // InvokeReapeating : 지정된 시간 후에 함수를 호출한 뒤 특정한 시간마다 반복 실행하는 함수입니다.
        //Invoke(nameof(CreateInfinite), 5);
               //nameof함수전달         5초뒤

        InvokeRepeating(nameof(CreateInfinite), 0, 5);
        // 0초 뒤에 5초마다 반복 실행 됩니다.
        // 10초 대기후 

        // 성능 -> 1.코르틴, 2 Update(), InvokeRepeating ()
    }

    // 업데이트에 리스폰 만들기
    //private void Update()
    //{
        //timer += time.deltatime;

        //if (timer >= 2f)
        //{
        //    createinfinite();
        //    timer = 0;
        //}
    //}

    // 게임 오브젝트(Enemy)를 생성하는 함수
    public void CreateInfinite() // 무한생성
    {
        // 게임메니져 잇는 state 변수가 false라면 함수를 return(종료)를 시킵니다.
        if (GameManager.instance.state == false) // 9-14
        {
            return;
        }

        Instantiate
            (// 리소스 폴더  ,로드 , 게임오브젝트 , 이름 Enemy
            Resources.Load<GameObject>("Enemy"),
            randomPosition[Random.Range(0,5)].position,
                         // 위치 랜덤 함수 
            Quaternion.identity
            );
    }


}
