using UnityEngine;

public class SpawnBlueTeamUnit : MonoBehaviour
{
    public GameObject blueTeamBaseObject; // 블루팀 기지
    public GameObject blueTeamWarriorObject; // 블루팀 전사
    public GameObject blueTeamArcherObject; // 블루팀 궁수
    public GameObject blueTeamGuardObject; // 블루팀 가드

    public void SpawnWarrior() // 전사 생성
    {
        GameObject warrior = Instantiate(blueTeamWarriorObject, blueTeamBaseObject.transform);
    }
    public void SpawnArcher() // 궁수 생성
    {
        GameObject archer = Instantiate(blueTeamArcherObject, blueTeamBaseObject.transform);
    }
    public void SpawnGuard() // 가드 생성
    {
        GameObject guard = Instantiate(blueTeamGuardObject, blueTeamBaseObject.transform);
    }
}
