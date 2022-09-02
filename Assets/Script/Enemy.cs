using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer enemySprite; // 9-1 적 피격 효과

    private Material enemyMaterial; //9-1 적 피격 효과

    [SerializeField] int health = 100; //9-2 적 체력 100

    [SerializeField] Material flash; //9-1

    private void Start() //9-1 적피격효과
    {
        enemySprite = GetComponent<SpriteRenderer>();

        enemyMaterial = enemySprite.material;

        flash = new Material(flash);
    }

    void Update()
    {
        // Vector3.down = 0.-1.1
        transform.Translate(Vector3.down * Time.deltaTime);
        
                                       // || health <= 0 //9-2
        if (transform.position.y <= -4.5f || health <= 0) // 데드존
        {
            Destroy(gameObject);
        }

        // 적 피격 테스트 9-1 
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(nameof(Damage));// 데미지 함수 호출
        //}
    }

    // 게임 오브젝트가 화면 밖으로 벗어났을 때 호출되는 함수
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}


    // 게임 오브젝트와 충돌을 했을 때 호출되는 함수 // 지워주기
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject); 9-2 주석


        // 충돌한 게임 오브젝트의 태그가 Lazer라면 //9-2
        if(other.CompareTag("Lazer")) 
        {
            

            health -= other.GetComponent<Bullet>().attack; // 데미지가 20식 들어감
            StartCoroutine(nameof(Damage));// 데미지 함수 호출 //9-2 추가
        }

        // 플레이어 죽기
        // Character라는 태그를 가진 게임 오브젝트가 충돌했을 때
        if (other.CompareTag("Character")) 
        {
            // 충돌당한 게임 오브젝트가 파괴됩니다.
            Destroy(other.gameObject);
        }
        
    }

    // 게임 오브젝트가 파괴되었을 때 호출되는 함수
    private void OnDestroy()
    {
        GameManager.instance.score += 100;// 적 죽일때 마다 점수 100 /9-2

        // 게임 데이터를 저장합니다.
        GameManager.instance.Save();


        SoundManager.instance.SoundStart(1); // 파괴 되었을때 소리 출력

        //Debug.Log("충돌");
        Instantiate
            (Resources.Load<GameObject>("Explosion"), //생성하고 싶은 게임 오브젝트
            transform.position, // 생성되는 게임 오브젝트의 위치 
            Quaternion.identity // Quaternion.identity : 회전을 하지 않겠다는 의미입니다.
            );
    }

    // 데미지를 받았을때 코르틴으로 처리하는 게 좋음 9-1
    private IEnumerator Damage()
    {
        enemySprite.material = flash;
        flash.color = new Color(1, 1, 1, 0.5f); // 감마값 투명도 0.5
        // 색깔지정 

        yield return new WaitForSeconds(0.05f); // 0.05초 대기

        enemySprite.material = enemyMaterial; // 에너미 머르티얼로 돌려주기
    }
}
