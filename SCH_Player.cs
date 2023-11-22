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

    // 마지막 이동 방향을 저장할 변수
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

        // 이전에 이동한 방향을 저장
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
        // 오브젝트 생성 위치 계산에 이전에 이동한 방향을 사용
        //Instantiate(오브젝트,위치에 오브젝트복사본 생성, 회전값) 함수
        //Instantiate(오브젝트,rigidbody위치 발이아닌 손에위치 하기위해 약간 띄움, Quaternion회전을 표현하는 연산자.회전없음) 함수
        GameObject projectileObject = Instantiate(projectilePrefab, rigid.position + lastMoveDirection * 0.05f, Quaternion.identity);
        StoneProjectile projectile = projectileObject.GetComponent<StoneProjectile>();

        //Launch(호출시 캐릭터가 바라보는 방향, 힘값 뉴튼단위)
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
