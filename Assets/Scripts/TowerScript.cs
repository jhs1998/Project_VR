using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    // Ÿ���� ü��
    public int towerHP = 100;

    public void GetDamage(int damage)
    {
        // Ÿ�� ������ ����
        towerHP -= damage;
        // Ÿ�� ������ ����
        Debug.Log($"{damage} ������ ����");
    }

    public void TowerDie()
    {
        if (towerHP <= 0)
        {
            towerHP = 0;

            // ���� ���� ��ũ��Ʈ

        }
    }
}
