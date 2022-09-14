using UnityEngine;
using UnityEngine.Pool; //9-1

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;

    public int attack = 20; // 9-2 �Ѿ� ������ 20

    // ������Ʈ ��ü���� � pool�� ���� �ϴ��� �������ִ� �����Դϴ�.
    private IObjectPool<Bullet> lazerPool;//9-1
    
    void Update()
    {
        // ���Ӹ޴��� �մ� state ������ false��� �Լ��� return(����)�� ��ŵ�ϴ�.
        if (GameManager.instance.state == false) return; // 9-14

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
