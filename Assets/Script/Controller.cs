using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // ���ǵ� ����
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        InvokeRepeating(nameof(LayerCreate), 0, 0.1f);
    }

    
    void Update()
    {
        //float x = Input.GetAxis("Horizontal"); // ����ϵǰ�, PC�� �˴ϴ�.
        //float y = Input.GetAxis("Vertical");

        float x = Input.GetAxis("Mouse X"); 
        //float y = Input.GetAxis("Mouse Y"); // �巡�� �ö��� �����

        //Vector3 direction = new Vector3(x, y, 0); // �巡�� �ö��� ���� �����
        Vector3 direction = new Vector3(x, 0, 0);

        transform.Translate(direction.normalized * speed * Time.deltaTime);



        // ī�޶� ���� 
        // ���� ������Ʈ�� ��ġ�� ��ũ�� �������� ��ȯ�մϴ�.
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        // ��ǥ ������ �������� ���ǹ��� �ۼ��մϴ�.
        if (position.x < 0f) position.x = 0.0f;
        if (position.x > 1f) position.x = 1.0f;

        //if (position.y < 0f) position.y = 0.0f;
        //if (position.y > 1f) position.y = 1.0f;

        transform.position = Camera.main.ViewportToWorldPoint(position);
    }

    public void LayerCreate() // ������ �ڵ� �߻�
    {
        Instantiate
        (
           Resources.Load<GameObject>("Lazer"),
           centerMuzzle.position,         
           Quaternion.identity
        );
    }
}
