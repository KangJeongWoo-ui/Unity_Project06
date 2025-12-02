using UnityEngine;

[System.Serializable]
public class BlueTeamUnit
{
    public float hp;
    public float atk;
    public float spd;
    public float rayDistance;
}

public class BlueTeamUnitStates : MonoBehaviour
{
    [Header("Warrior States")]
    public BlueTeamUnit warrior = new BlueTeamUnit
    {
        hp = 150.0f,
        atk = 25.0f,
        spd = 2.0f,
        rayDistance = 1.0f
    };

    [Header("Archer States")]
    public BlueTeamUnit archer = new BlueTeamUnit
    {
        hp = 70.0f,
        atk = 20.0f,
        spd = 1.8f,
        rayDistance = 3.2f
    };

    [Header("Guard States")]
    public BlueTeamUnit guard = new BlueTeamUnit
    {
        hp = 220.0f,
        atk = 15.0f,
        spd = 1.4f,
        rayDistance = 1.0f
    };

    [Header("Wizard States")]
    public BlueTeamUnit wizard = new BlueTeamUnit
    {
        hp = 60.0f,
        atk = 40.0f,
        spd = 0.0f,
        rayDistance = 3.5f
    };
}
