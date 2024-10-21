using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponMonster01 : MonoBehaviour
{
    // 몬스터 스폰 01 3lv 부터 소환

    // 몬스터 프리펩
    [SerializeField] GameObject monsterPrefab01;
    [SerializeField] GameObject monsterPrefab02;
    [SerializeField] GameObject monsterPrefab03;

    // 몬스터 스폰 지점
    [SerializeField] Transform sponPoint;
    // 몬스터 넘버
    int monsterNum;


    private void Start()
    {
        StartCoroutine(SponMonster());
    }

    IEnumerator SponMonster()
    {
        while (true)
        {
            monsterNum = Random.Range(1, 4);
            switch (monsterNum)
            {
                case 1:
                    Instantiate(monsterPrefab01, sponPoint.position, sponPoint.rotation);
                    break;
                case 2:
                    Instantiate(monsterPrefab02, sponPoint.position, sponPoint.rotation);
                    break;
                case 3:
                    Instantiate(monsterPrefab03, sponPoint.position, sponPoint.rotation);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(5f); // 5초 대기후 다시 스폰
        }
    }
}
