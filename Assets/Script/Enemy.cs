using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    void Update()
    {
        // Vector3.forward = 0.0.1
        transform.Translate(Vector3.forward * Time.deltaTime);
    }

    // ���� ������Ʈ�� ȭ�� ������ ����� �� ȣ��Ǵ� �Լ�
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
