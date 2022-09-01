using UnityEngine;
using UnityEngine.Pool; //9-1

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    // 오브젝트 자체에서 어떤 pool에 들어가야 하는지 선언해주는 과정입니다.
    private IObjectPool<Bullet> lazerPool;//9-1
    
    void Update()
    {     
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
