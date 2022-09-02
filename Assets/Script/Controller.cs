using UnityEngine;
using UnityEngine.Pool; // ����Ƽ Ǯ�� 9-1

public class Controller : MonoBehaviour
{
    // ���ǵ� ����
    [SerializeField] float speed = 1.0f;
    [SerializeField] Transform centerMuzzle;

    // �޸� Ǯ�� ����� ���� ������Ʈ
    [SerializeField] Bullet lazerPrefab; //9-1

    // �޸� Ǯ�� ����� Ŭ����
    private IObjectPool<Bullet> lazerPool; //9-1

    private void Awake() // ����Ƽ �޸�Ǯ
    {
        //�Ű躯��
        //1.�����ϴ� �Լ�
        //2.Ȱ��ȭ�ϴ� �Լ�
        //3.��Ȱ��ȭ�ϴ� �Լ�
        //4.���� ������Ʈ�� �ı��ϴ� �Լ�
        //5.maxSize : �޸𸮿� �����ϰ� ���� ����
        lazerPool = new ObjectPool<Bullet>
            (
            LayerCreate, 
            LazerGet, 
            ReleaseLazer, 
            DestroyLazer
            );
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //InvokeRepeating(nameof(LayerCreate), 0, 0.1f);9-1
        InvokeRepeating(nameof(InfiniteLazer), 0, 0.1f);
    }

    public void InfiniteLazer()
    {
        //lazerPool.Get();
        var bullet = lazerPool.Get(); //9-1
        SoundManager.instance.SoundStart(0); // 9-2 ���� ȣ��
        bullet.transform.position = centerMuzzle.transform.position; //9-1
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

    // ���� ������Ʈ�� �����ϴ� �Լ� 9-1
    //public void LayerCreate() // ������ �ڵ� �߻�
    public Bullet LayerCreate() //9-1
    {
        //Instantiate 9-1 ����Ƽ Ǯ ����ϱ� ���� �����ֱ�
        //(
        //   Resources.Load<GameObject>("Lazer"),
        //   centerMuzzle.position,         
        //   Quaternion.identity
        //);


        Bullet bullet = Instantiate(lazerPrefab).GetComponent<Bullet>();
        bullet.SetPool(lazerPool);
        return bullet;
    }

    // Get�� ����� �� ����Ǵ� �Լ�
    // ���� ������Ʈ�� Ȱ��ȭ �ϴ� �Լ� 9-1
    public void LazerGet(Bullet lazer)
    {
        lazer.gameObject.SetActive(true);
    }

    // ���� ������Ʈ�� ��Ȱ��ȭ�ϴ� �Լ� 9-1
    public void ReleaseLazer(Bullet lazer)
    {
        lazer.gameObject.SetActive(false);
    }

    // ���� ������Ʈ�� �ı��ϴ� �Լ� 9-1
    public void DestroyLazer(Bullet lazer)
    {
        Destroy(lazer.gameObject);
    }

}
