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

    // 게임 오브젝트가 화면 밖으로 벗어났을 때 호출되는 함수
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
