using UnityEngine;
using System.Collections.Generic;
public class StateUpGrade : MonoBehaviour
{
    BlueTeamUnitStates blueTeamUnitStates;

    [Header("Warrior Add States")]
    public List<float> warriorAddHp;
    public List<float> warriorAddAtk;

    [Header("Warrior Add States")]
    public List<float> archerAddHp;
    public List<float> archerAddAtk;

    [Header("Warrior Add States")]
    public List<float> guardAddHp;
    public List<float> guardAddAtk;

    [Header("Wizard Add States")]
    public List<float> wizardAddHp;
    public List<float> wizardAddAtk;

    [Header("States Level")]
    public int warriorLevel = 0;
    public int archerLevel = 0;
    public int guardLevel = 0;
    public int wizardLevel = 0;

    void Awake()
    {
        blueTeamUnitStates = FindFirstObjectByType<BlueTeamUnitStates>();
    }
    public void UpGradeWarriorStates()
    {
        warriorLevel++;

        if(warriorLevel > 4)
        {
            warriorLevel = 5;
            Debug.Log("전사가 이미 최대 레벨 입니다");
            return;
        }

        Debug.Log("전사 업그레이드 됨");
        blueTeamUnitStates.warrior.hp = warriorAddHp[warriorLevel];
        blueTeamUnitStates.warrior.atk = warriorAddAtk[warriorLevel];

        Debug.Log(blueTeamUnitStates.warrior.hp);
        Debug.Log(blueTeamUnitStates.warrior.atk);
    }
    public void UpGradeArcherStates()
    {
        archerLevel++;

        if (archerLevel > 4)
        {
            archerLevel = 5;
            Debug.Log("아처가 이미 최대 레벨 입니다");
            return;
        }

        Debug.Log("궁수 업그레이드 됨");
        blueTeamUnitStates.archer.hp = archerAddHp[archerLevel];
        blueTeamUnitStates.archer.atk = archerAddAtk[archerLevel];
    }
    public void UpGradeGuardStates()
    {
        guardLevel++;

        if (guardLevel > 4)
        {
            guardLevel = 5;
            Debug.Log("가드가 이미 최대 레벨 입니다");
            return;
        }

        Debug.Log("가드 업그레이드 됨");
        blueTeamUnitStates.guard.hp = guardAddHp[guardLevel];
        blueTeamUnitStates.guard.atk = guardAddAtk[guardLevel];
    }
    public void UpGradeWizardStates()
    {
        wizardLevel++;

        if (wizardLevel > 4)
        {
            wizardLevel = 5;
            Debug.Log("마법사가 이미 최대 레벨 입니다");
            return;
        }

        Debug.Log("마법사 업그레이드 됨");
        blueTeamUnitStates.wizard.hp = wizardAddHp[wizardLevel];
        blueTeamUnitStates.wizard.atk = wizardAddAtk[wizardLevel];
    }
}
