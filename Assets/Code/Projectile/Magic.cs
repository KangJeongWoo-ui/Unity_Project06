using UnityEngine;
public enum MagicType { BlueTeam, RedTeam }
public class Magic : MonoBehaviour
{
    public MagicType magicType;

    public float atk;

    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        DefaultUnitSettings targetUnit = collision.GetComponent<DefaultUnitSettings>();
        if (targetUnit != null)
        {
            targetUnit.TakeDamage(atk);
        }
    }
}
