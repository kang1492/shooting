using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    
    void Update()
    {
        if(transform.position.y >= 6.5f) // �Ѿ��� �־����� �ڵ� �ı�
        {
            Destroy(gameObject);
        }
        
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
