using UnityEngine;
using UnityEngine.Pool; //9-1

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    // ������Ʈ ��ü���� � pool�� ���� �ϴ��� �������ִ� �����Դϴ�.
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
        //Destroy(gameObject); 9-1 ���̻� ���ʿ� ����

        // �޸� Ǯ�� ��ȯ�Ǵ� �Լ�
        lazerPool.Release(this); 
        //                �ڱ��ڽ�
    }
}
