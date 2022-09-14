//using System; //9-14 �ȵǴ� �����
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //               �迭 ����   
    [SerializeField] Transform[ ] randomPosition;

    //static public Action action; //9-14 �ȵǴ� �����

    float timer;

    //public void Awake() // 9-14 �ȵǴ� �����
    //{
    //    action = () => { InvokeRepeating(nameof(CreateInfinite), 0, 5); };
    //}

    void Start()  //9-14 �ȵǴ� �����
    {   // �Լ� ȣ��
        //CreateInfinite(); // ���۽� �ѹ� ȣ��

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
        // ���Ӹ޴��� �մ� state ������ false��� �Լ��� return(����)�� ��ŵ�ϴ�.
        if (GameManager.instance.state == false) // 9-14
        {
            return;
        }

        Instantiate
            (// ���ҽ� ����  ,�ε� , ���ӿ�����Ʈ , �̸� Enemy
            Resources.Load<GameObject>("Enemy"),
            randomPosition[Random.Range(0,5)].position,
                         // ��ġ ���� �Լ� 
            Quaternion.identity
            );
    }


}
