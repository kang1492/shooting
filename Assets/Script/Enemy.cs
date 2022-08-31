using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void Update()
    {
        // Vector3.down = 0.-1.1
        transform.Translate(Vector3.down * Time.deltaTime);

        if(transform.position.y <= -4.5f) // ������
        {
            Destroy(gameObject);
        }
    }

    // ���� ������Ʈ�� ȭ�� ������ ����� �� ȣ��Ǵ� �Լ�
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}


    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ� // �����ֱ�
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // ���� ������Ʈ�� �ı��Ǿ��� �� ȣ��Ǵ� �Լ�
    private void OnDestroy()
    {
        //Debug.Log("�浹");
        Instantiate
            (Resources.Load<GameObject>("Explosion"), //�����ϰ� ���� ���� ������Ʈ
            transform.position, // �����Ǵ� ���� ������Ʈ�� ��ġ 
            Quaternion.identity // Quaternion.identity : ȸ���� ���� �ʰڴٴ� �ǹ��Դϴ�.
            );
    }
}
