using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //               �迭 ����   
    [SerializeField] Transform[ ] randomPosition;

    float timer;

    void Start()
    {   // �Լ� ȣ��
        CreateInfinite();

        // Invoke : ������ �ð� �Ŀ� �Լ��� ȣ���ϴ� �Լ��Դϴ�.
        // InvokeReapeating : ������ �ð� �Ŀ� �Լ��� ȣ���� �� Ư���� �ð����� �ݺ� �����ϴ� �Լ��Դϴ�.
        //Invoke(nameof(CreateInfinite), 5);
               //nameof�Լ�����         5�ʵ�

        InvokeRepeating(nameof(CreateInfinite), 0, 5);
        // 0�� �ڿ� 5�ʸ��� �ݺ� ���� �˴ϴ�.
        // 10�� ����� 

        // ���� -> 1.�ڸ�ƾ, 2 Update(), InvokeRepeating ()
    }

    // ������Ʈ�� ������ �����
    //private void Update()
    //{
        //timer += time.deltatime;

        //if (timer >= 2f)
        //{
        //    createinfinite();
        //    timer = 0;
        //}
    //}

    // ���� ������Ʈ(Enemy)�� �����ϴ� �Լ�
    public void CreateInfinite() // ���ѻ���
    {
        Instantiate
            (// ���ҽ� ����  ,�ε� , ���ӿ�����Ʈ , �̸� Enemy
            Resources.Load<GameObject>("Enemy"),
            randomPosition[Random.Range(0,5)].position,
                         // ��ġ ���� �Լ� 
            Quaternion.identity
            );
    }


}
