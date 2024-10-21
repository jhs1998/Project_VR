using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponMonster02 : MonoBehaviour
{
    // ���� ������
    [SerializeField] GameObject monsterPrefab03;
    [SerializeField] GameObject monsterPrefab04;
    [SerializeField] GameObject monsterPrefab05;

    // ���� ���� ����
    [SerializeField] Transform sponPoint;
    // ���� �ѹ�
    int monsterNum;


    private void Start()
    {
        StartCoroutine(SponMonster());
    }

    IEnumerator SponMonster()
    {
        while (true)
        {
            monsterNum = Random.Range(3, 6);
            switch (monsterNum)
            {
                case 1:
                    Instantiate(monsterPrefab03, sponPoint.position, sponPoint.rotation);
                    break;
                case 2:
                    Instantiate(monsterPrefab04, sponPoint.position, sponPoint.rotation);
                    break;
                case 3:
                    Instantiate(monsterPrefab05, sponPoint.position, sponPoint.rotation);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(5f); // 5�� ����� �ٽ� ����
        }
    }
}
