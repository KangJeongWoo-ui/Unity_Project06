using UnityEngine;

public enum BlueTeamUnitType{ Warrior, Archer, Guard, Wizard} // 전사, 궁수, 가드, 마법사
public class BlueTeam : DefaultUnitSettings // DefaultUnitSettings을 상속 받음
{
    public BlueTeamUnitType unitType;
    public BlueTeamUnitStates blueTeamUnitStates;

    protected override void Awake()
    {
        base.Awake();
        blueTeamUnitStates = GetComponent<BlueTeamUnitStates>(); // 블루팀 스탯을 BlueTeamUnitStates 에 따로 정리
    }
    protected override void SetMoveVec()
    {
        moveVec = Vector2.right;
    }
    protected override void SetStates()
    {
        BlueTeamUnit unitStates = null;

        switch(unitType)
        {
            case BlueTeamUnitType.Warrior:
                unitStates = blueTeamUnitStates.warrior;
                break;
            case BlueTeamUnitType.Archer:
                unitStates = blueTeamUnitStates.archer;
                break;
            case BlueTeamUnitType.Guard:
                unitStates = blueTeamUnitStates.guard;
                break;
            case BlueTeamUnitType.Wizard:
                unitStates = blueTeamUnitStates.wizard;
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
    protected override bool IsArcher() // 유닛 종류가 궁수라면 DefaultUnitSettings 에 전달
    {
        return unitType == BlueTeamUnitType.Archer;
    }
    protected override bool IsWizard() // 유닛 종류가 궁수라면 DefaultUnitSettings 에 전달
    {
        return unitType == BlueTeamUnitType.Wizard;
    }
}
