using UnityEngine;
using UnityEngine.Pool; //9-1

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    public int attack = 20; // 9-2 총알 데미지 20

    // 오브젝트 자체에서 어떤 pool에 들어가야 하는지 선언해주는 과정입니다.
    private IObjectPool<Bullet> lazerPool;//9-1
    
    void Update()
    {
        // 게임메니져 잇는 state 변수가 false라면 함수를 return(종료)를 시킵니다.
        if (GameManager.instance.state == false) return; // 9-14

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void SetPool(IObjectPool<Bullet> pool) //9-1
    {
        lazerPool = pool;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject); 9-1 더이상 할필요 없음

        // 메모리 풀에 반환되는 함수
        lazerPool.Release(this); 
        //                자기자신
    }
}
