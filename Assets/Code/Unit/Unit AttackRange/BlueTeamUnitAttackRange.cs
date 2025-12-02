using UnityEngine;

public class BlueTeamAttackRange : MonoBehaviour
{
    private BlueTeam blueTeamUnit;
    void Awake()
    {
        blueTeamUnit = GetComponentInParent<BlueTeam>();
    }
    void OnTriggerEnter2D(Collider2D collision) // 공격범위 박스 콜라이더애 적이 닿으면 데미지를 줌 (전사, 가드에 적용됨)
    {
        if(collision.CompareTag("RedTeamUnit"))
        {
            RedTeam redTeam = collision.GetComponent<RedTeam>();
            if(redTeam != null)
            {
                redTeam.TakeDamage(blueTeamUnit.atk);
            }
        }
    }
}
