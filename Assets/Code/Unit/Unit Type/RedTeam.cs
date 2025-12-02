using UnityEngine;
public enum RedTeamUnitType { Warrior, Archer, Guard, Wizard }
public class RedTeam : DefaultUnitSettings
{
    public RedTeamUnitType unitType;
    public RedTeamUnitStates redTeamUnitStates;
    protected override void Awake()
    {
        base.Awake();
        redTeamUnitStates = GetComponent<RedTeamUnitStates>();
    }
    protected override void SetMoveVec()
    {
        moveVec = Vector2.left;
    }
    protected override void SetStates()
    {
        RedTeamUnit unitStates = null;

        switch (unitType)
        {
            case RedTeamUnitType.Warrior:
                unitStates = redTeamUnitStates.warrior;
                break;
            case RedTeamUnitType.Archer:
                unitStates = redTeamUnitStates.archer;
                break;
            case RedTeamUnitType.Guard:
                unitStates = redTeamUnitStates.guard;
                break;
            case RedTeamUnitType.Wizard:
                unitStates = redTeamUnitStates.wizard;
                break;
        }

        if (unitStates != null)
        {
            spd = unitStates.spd;
            hp = unitStates.hp;
            atk = unitStates.atk;
            rayDistance = unitStates.rayDistance;
        }
    }
    protected override bool IsArcher()
    {
        return unitType == RedTeamUnitType.Archer;
    }
    protected override bool IsWizard() // 유닛 종류가 궁수라면 DefaultUnitSettings 에 전달
    {
        return unitType == RedTeamUnitType.Wizard;
    }
}