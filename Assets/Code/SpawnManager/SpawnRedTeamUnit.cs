using UnityEngine;

public class SpawnRedTeamUnit : MonoBehaviour
{
    public GameObject redTeamBaseObject; // 레드팀 기지
    public GameObject redTeamWarriorObject; // 레드팀 전사
    public GameObject redTeamArcherObject; // 레드팀 궁수
    public GameObject redTeamGuardObject; // 레드팀 가드

    public void SpawnWarrior() // 전사 생성
    {
        GameObject warrior = Instantiate(redTeamWarriorObject, redTeamBaseObject.transform);
    }
    public void SpawnArcher() // 궁수 생성
    {
        GameObject archer = Instantiate(redTeamArcherObject, redTeamBaseObject.transform);
    }
    public void SpawnGuard() // 가드 생성
    {
        GameObject guard = Instantiate(redTeamGuardObject, redTeamBaseObject.transform);
    }
}
