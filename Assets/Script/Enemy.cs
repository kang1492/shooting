using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer enemySprite; // 9-1 �� �ǰ� ȿ��

    private Material enemyMaterial; //9-1 �� �ǰ� ȿ��

    [SerializeField] int health = 100; //9-2 �� ü�� 100

    [SerializeField] Material flash; //9-1

    private void Start() //9-1 ���ǰ�ȿ��
    {
        enemySprite = GetComponent<SpriteRenderer>();

        enemyMaterial = enemySprite.material;

        flash = new Material(flash);
    }

    void Update()
    {
        // Vector3.down = 0.-1.1
        transform.Translate(Vector3.down * Time.deltaTime);
        
                                       // || health <= 0 //9-2
        if (transform.position.y <= -4.5f || health <= 0) // ������
        {
            Destroy(gameObject);
        }

        // �� �ǰ� �׽�Ʈ 9-1 
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(nameof(Damage));// ������ �Լ� ȣ��
        //}
    }

    // ���� ������Ʈ�� ȭ�� ������ ����� �� ȣ��Ǵ� �Լ�
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}


    // ���� ������Ʈ�� �浹�� ���� �� ȣ��Ǵ� �Լ� // �����ֱ�
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(gameObject); 9-2 �ּ�


        // �浹�� ���� ������Ʈ�� �±װ� Lazer��� //9-2
        if(other.CompareTag("Lazer")) 
        {
            

            health -= other.GetComponent<Bullet>().attack; // �������� 20�� ��
            StartCoroutine(nameof(Damage));// ������ �Լ� ȣ�� //9-2 �߰�
        }

        // �÷��̾� �ױ�
        // Character��� �±׸� ���� ���� ������Ʈ�� �浹���� ��
        if (other.CompareTag("Character")) 
        {
            // �浹���� ���� ������Ʈ�� �ı��˴ϴ�.
            Destroy(other.gameObject);
        }
        
    }

    // ���� ������Ʈ�� �ı��Ǿ��� �� ȣ��Ǵ� �Լ�
    private void OnDestroy()
    {
        GameManager.instance.score += 100;// �� ���϶� ���� ���� 100 /9-2

        // ���� �����͸� �����մϴ�.
        GameManager.instance.Save();


        SoundManager.instance.SoundStart(1); // �ı� �Ǿ����� �Ҹ� ���

        //Debug.Log("�浹");
        Instantiate
            (Resources.Load<GameObject>("Explosion"), //�����ϰ� ���� ���� ������Ʈ
            transform.position, // �����Ǵ� ���� ������Ʈ�� ��ġ 
            Quaternion.identity // Quaternion.identity : ȸ���� ���� �ʰڴٴ� �ǹ��Դϴ�.
            );
    }

    // �������� �޾����� �ڸ�ƾ���� ó���ϴ� �� ���� 9-1
    private IEnumerator Damage()
    {
        enemySprite.material = flash;
        flash.color = new Color(1, 1, 1, 0.5f); // ������ ���� 0.5
        // �������� 

        yield return new WaitForSeconds(0.05f); // 0.05�� ���

        enemySprite.material = enemyMaterial; // ���ʹ� �Ӹ�Ƽ��� �����ֱ�
    }
}
