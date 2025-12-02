using UnityEngine;

public class RedTeamAttackRange : MonoBehaviour
{
    private RedTeam redTeamUnit;
    void Awake()
    {
        redTeamUnit = GetComponentInParent<RedTeam>();
    }
    void OnTriggerEnter2D(Collider2D collision) // 공격범위 박스 콜라이더애 적이 닿으면 데미지를 줌 (전사, 가드에 적용됨)
    {
        if (collision.CompareTag("BlueTeamUnit"))
        {
            BlueTeam blueTeam = collision.GetComponent<BlueTeam>();
            if (redTeamUnit != null)
            {
                blueTeam.TakeDamage(redTeamUnit.atk);
            }
        }
    }
}
