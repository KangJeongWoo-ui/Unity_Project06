using UnityEngine;

[System.Serializable]
public class RedTeamUnit
{
    public float hp;
    public float atk;
    public float spd;
    public float rayDistance;
}
public class RedTeamUnitStates : MonoBehaviour
{
    [Header("Warrior States")]
    public RedTeamUnit warrior = new RedTeamUnit
    {
        hp = 150.0f,
        atk = 25.0f,
        spd = 2.0f,
        rayDistance = 1.0f
    };

    [Header("Archer States")]
    public RedTeamUnit archer = new RedTeamUnit
    {
        hp = 70.0f,
        atk = 20.0f,
        spd = 1.8f,
        rayDistance = 2.0f
    };

    [Header("Guard States")]
    public RedTeamUnit guard = new RedTeamUnit
    {
        hp = 220.0f,
        atk = 15.0f,
        spd = 1.4f,
        rayDistance = 1.0f
    };

    [Header("Wizard States")]
    public RedTeamUnit wizard = new RedTeamUnit
    {
        hp = 60.0f,
        atk = 40.0f,
        spd = 0.0f,
        rayDistance = 3.5f
    };
}
