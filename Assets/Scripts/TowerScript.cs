using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    // 타워의 체력
    public int towerHP = 100;

    public void GetDamage(int damage)
    {
        // 타워 데미지 받음
        towerHP -= damage;
        // 타워 데미지 사운드
        Debug.Log($"{damage} 데미지 받음");
    }

    public void TowerDie()
    {
        if (towerHP <= 0)
        {
            towerHP = 0;

            // 게임 종료 스크립트

        }
    }
}
