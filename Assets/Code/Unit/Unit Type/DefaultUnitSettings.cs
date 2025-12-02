using UnityEngine;
using System.Collections;

public abstract class DefaultUnitSettings : MonoBehaviour // 기본 유닛 설정
{
    [Header("공통 스탯")]
    public LayerMask attakTarget; // 레이마스크로 공격 대상 감지
    public GameObject arrowObject; // 궁수 화살 오브젝트
    public GameObject magicObject; // 마법사 마법 오브젝트

    // 체력, 공격력, 이동속도, 공격 사거리 => (블루,레드)유닛스탯 스크립트에서 세팅
    public float hp;
    public float atk;
    public float spd;
    public float rayDistance;

    protected bool isAttack = false; // 공격 판단
    protected bool isAttacking = false; // 공격 코루틴이 돌아가는지 판단

    protected Vector2 moveVec;
    protected Rigidbody2D rb;
    protected Animator anim;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    protected virtual void Start()
    {
        SetMoveVec();
        SetStates();
    }
    protected virtual void Update()
    {
        // 유닛의 가운데에서 유닛의 공격 사거리 길이의 레이케스트를 쏨
        RaycastHit2D hit = Physics2D.Raycast(rb.position + new Vector2(0, 0.5f), moveVec, rayDistance, attakTarget);
        Debug.DrawRay(rb.position + new Vector2(0, 0.5f), moveVec * rayDistance, Color.red);

        if (hit.collider != null)
        {
            if (!isAttacking) // 공격 코루틴이 실행되지 않았다면 공격코루틴 실행 => 계속해서 공격 코루틴을 실행하는것 방지
            {
                isAttack = true;
                StartCoroutine(AttackCoroutine());
            }
        }
        else
        {
            isAttack = false;
        }

    }
    protected virtual void FixedUpdate()
    {
        if (isAttack) return; // 공격할때는 움직이지 않음

        if (IsWizard()) return; // 마법사는 움직이지 않음

        // 블루팀은 오른쪽 레드팀은 왼쪽으로 이동 moveVec는 각 BlueTeam, RedTeam에서 정함
        Vector2 curPos = rb.position;
        Vector2 nextPos = rb.position + moveVec * spd * Time.deltaTime;
        rb.MovePosition(nextPos);
    }
    public void TakeDamage(float damage) // 데미지를 받음 구현
    {
        Debug.Log("체력: " + hp);
        Debug.Log("받은 데미지: " + damage);
        hp -= damage; // 체력에서 받은 데미지를 감소시킴
        if (hp <= 0)
        {
            moveVec = Vector2.zero; // 체력이 0보다 작으면 움직임, 공격, 코루틴을 멈추고 Die 실행
            isAttack = false;
            StopAllCoroutines();
            Die();
        }
        else
        {
            StartCoroutine(HitCoroutine()); // 데미지를 받으면 Hit 코루틴 실행
            Debug.Log("남은 체력:" + hp);
        }
    }
    protected virtual void Die() // 죽으면 오브젝트 레이어를 DeadUnit으로 전환, Die 코루틴 실행
    {
        gameObject.layer = LayerMask.NameToLayer("DeadUnit");
        StartCoroutine(DieCoroutine());
    }
    protected virtual void FireArrow() // 화살 발사, 화살로 데미지를 받음 구현 (궁수에게 적용)
    {
        GameObject arrow = Instantiate(arrowObject, rb.position + new Vector2(0, 0.3f), Quaternion.identity);
        Arrow arrowAtk = arrow.GetComponent<Arrow>();
        arrowAtk.atk = this.atk;
    }
    protected virtual void FireMagic()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position + new Vector2(0, 0.5f), moveVec, rayDistance, attakTarget);

        if (hit.collider != null)
        {
            GameObject magic = Instantiate(magicObject, hit.point + new Vector2(0,-1.5f), Quaternion.identity);
            Magic magicAtk = magic.GetComponent<Magic>();
            magicAtk.atk = this.atk;
            Destroy(magic, 1f);
        }
    }
    protected virtual IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        while (isAttack)
        {
            anim.SetTrigger("doAttack");

            if (IsArcher()) // 궁수라면 화살 발사
            {
                FireArrow();
            }
            else if(IsWizard()) // 마법사라면 마법 발사
            {
                FireMagic();
            }
            yield return new WaitForSeconds(0.5f);
            anim.SetTrigger("doIdle");
            yield return new WaitForSeconds(0.5f);
        }

        isAttacking = false;
    }
    protected virtual IEnumerator HitCoroutine()
    {
        anim.SetTrigger("doHit");
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("doIdle");
    }
    protected virtual IEnumerator DieCoroutine()
    {
        anim.SetTrigger("doDie");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    protected abstract void SetStates(); // 기본 유닛 스탯 설정
    protected abstract void SetMoveVec(); // 기본 이동 방향 설정
    protected abstract bool IsArcher(); // 궁수인지 구분
    protected abstract bool IsWizard(); // 마법사인지 구분
}