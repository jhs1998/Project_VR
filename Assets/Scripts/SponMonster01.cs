using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponMonster01 : MonoBehaviour
{
    // ���� ���� 01 3lv ���� ��ȯ

    // ���� ������
    [SerializeField] GameObject monsterPrefab01;
    [SerializeField] GameObject monsterPrefab02;
    [SerializeField] GameObject monsterPrefab03;

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
            yield return new WaitForSeconds(5f); // 5�� ����� �ٽ� ����
        }
    }
}
