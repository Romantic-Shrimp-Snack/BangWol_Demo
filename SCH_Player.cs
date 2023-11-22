using UnityEngine;

public class SCH_Player : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Vector2 inputVec;

    public float speed;
    public float health;
    public float maxHealth;

    public float coolTime =1.0f;
    private float curTime;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    // ������ �̵� ������ ������ ����
    Vector2 lastMoveDirection = Vector2.right;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        // ������ �̵��� ������ ����
        if (inputVec.x != 0 || inputVec.y != 0)
        {
            lastMoveDirection = inputVec.normalized;
        }

        if (curTime <= 0) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Launch();
                curTime = coolTime;
            }
        }
        else
        {
            curTime -=Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }

    void Launch()
    {
        // ������Ʈ ���� ��ġ ��꿡 ������ �̵��� ������ ���
        //Instantiate(������Ʈ,��ġ�� ������Ʈ���纻 ����, ȸ����) �Լ�
        //Instantiate(������Ʈ,rigidbody��ġ ���̾ƴ� �տ���ġ �ϱ����� �ణ ���, Quaternionȸ���� ǥ���ϴ� ������.ȸ������) �Լ�
        GameObject projectileObject = Instantiate(projectilePrefab, rigid.position + lastMoveDirection * 0.05f, Quaternion.identity);
        StoneProjectile projectile = projectileObject.GetComponent<StoneProjectile>();

        //Launch(ȣ��� ĳ���Ͱ� �ٶ󺸴� ����, ���� ��ư����)
        projectile.Launch(lastMoveDirection, 300);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }

    }

}
