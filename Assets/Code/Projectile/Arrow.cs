using UnityEngine;
public enum ArrowType { BlueTeam, RedTeam }
public class Arrow : MonoBehaviour
{
    public ArrowType arrowType;

    public int spd; // 화살 속도
    public float atk; // 화살 데미지

    Vector2 moveVec;
    Rigidbody2D rb;
    void Start()
    {
        ArrowSetting();
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 curPos = rb.position;
        Vector2 nextPos = rb.position + moveVec * spd * Time.deltaTime;
        rb.MovePosition(nextPos);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 같은 팀은 화살에 맞지 않음
        if (arrowType == ArrowType.BlueTeam && !collision.CompareTag("RedTeamUnit")) return;
        if (arrowType == ArrowType.RedTeam && !collision.CompareTag("BlueTeamUnit")) return;

        DefaultUnitSettings targetUnit = collision.GetComponent<DefaultUnitSettings>();

        // 화살이 맞으면 화살을 삭제하고 데미지를 받음
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(atk);
            Destroy(gameObject);
        }

    }
    void ArrowSetting()
    {
        switch(arrowType)
        {
            case ArrowType.BlueTeam: // 블루팀 화살은 오른쪽으로 발사
                spd = 3;
                moveVec = Vector2.right;
                break;
            case ArrowType.RedTeam: // 레드팀 화살은 왼쪽으로 발사
                spd = 3;
                moveVec = Vector2.left; 
                break;
        }
    }
}
