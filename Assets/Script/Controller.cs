using UnityEngine;
using UnityEngine.Pool; // 유니티 풀링 9-1

public class Controller : MonoBehaviour
{
    // 스피드 변수
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;
    [SerializeField] GameObject pet;//9-15

    // 메모리 풀로 사용할 게임 오브젝트
    [SerializeField] Bullet lazerPrefab; //9-1

    // 메모리 풀로 사용할 클래스
    private IObjectPool<Bullet> lazerPool; //9-1

    private void Awake() // 유니티 메모리풀
    {
        //매계변수
        //1.생성하는 함수
        //2.활성화하는 함수
        //3.비활성화하는 함수
        //4.게임 오브젝트를 파괴하는 함수
        //5.maxSize : 메모리에 저장하고 싶은 갯수
        lazerPool = new ObjectPool<Bullet>
            (
            LayerCreate, 
            LazerGet, 
            ReleaseLazer, 
            DestroyLazer
            );
    }

    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        //InvokeRepeating(nameof(LayerCreate), 0, 0.1f);9-1
        InvokeRepeating(nameof(InfiniteLazer), 0, 0.1f);
    }

    public void InfiniteLazer()
    {
        // 게임메니져 잇는 state 변수가 false라면 함수를 return(종료)를 시킵니다.
        if (GameManager.instance.state == false) return; // 9-14

        //lazerPool.Get();
        var bullet = lazerPool.Get(); //9-1
        SoundManager.instance.SoundStart(0); // 9-2 사운드 호출
        bullet.transform.position = centerMuzzle.transform.position; //9-1
    }
    
    void Update()
    {
        // 게임메니져 잇는 state 변수가 false라면 함수를 return(종료)를 시킵니다.
        if (GameManager.instance.state == false) return;

        //                                 0이면 펫을 구매하지 않은 상태입니다.1이면 구매상태
        if (GameManager.instance.dragon >= 1) //9-15
        {
            pet.SetActive(true);
        }


        //float x = Input.GetAxis("Horizontal"); // 모바일되고, PC로 됩니다.
        //float y = Input.GetAxis("Vertical");

        float x = Input.GetAxis("Mouse X"); 
        //float y = Input.GetAxis("Mouse Y"); // 드래곤 플라이 지우기

        //Vector3 direction = new Vector3(x, y, 0); // 드래곤 플라이 땀시 지우기
        Vector3 direction = new Vector3(x, 0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);



        // 카메라 고정 
        // 게임 오브젝트의 위치를 스크린 공간으로 변환합니다.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        // 좌표 정보를 기준으로 조건문을 작성합니다.
        if (position.x < 0f) position.x = 0.0f;
        if (position.x > 1f) position.x = 1.0f;

        //if (position.y < 0f) position.y = 0.0f;
        //if (position.y > 1f) position.y = 1.0f;

        transform.position = Camera.main.ViewportToWorldPoint(position);

        
        
    }

    // 게임 오브젝트를 생성하는 함수 9-1
    //public void LayerCreate() // 레이저 자동 발사
    public Bullet LayerCreate() //9-1
    {
        //Instantiate 9-1 유니티 풀 사용하기 위해 지워주기
        //(
        //   Resources.Load<GameObject>("Lazer"),
        //   centerMuzzle.position,         
        //   Quaternion.identity
        //);


        Bullet bullet = Instantiate(lazerPrefab).GetComponent<Bullet>();
        bullet.SetPool(lazerPool);
        return bullet;
    }

    // Get이 실행될 때 실행되는 함수
    // 게임 오브젝트를 활성화 하는 함수 9-1
    public void LazerGet(Bullet lazer)
    {
        lazer.gameObject.SetActive(true);
    }

    // 게임 오브젝트를 비활성화하는 함수 9-1
    public void ReleaseLazer(Bullet lazer)
    {
        lazer.gameObject.SetActive(false);
    }

    // 게임 오브젝트를 파괴하는 함수 9-1
    public void DestroyLazer(Bullet lazer)
    {
        Destroy(lazer.gameObject);
    }

}
