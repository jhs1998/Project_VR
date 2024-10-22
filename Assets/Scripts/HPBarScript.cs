using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarScript : MonoBehaviour
{
    public GameObject healthBar;  // 체력바 3D 오브젝트
    public TowerScript tower;  // 타워 스크립트

    private Vector3 originScale;  // 체력바의 초기 크기

    private void Start()
    {
        // 체력바의 초기 크기 저장
        originScale = healthBar.transform.localScale;
    }

    private void Update()
    {
        // 체력에 따라 체력바 크기 조정
        float health = Mathf.Clamp01((float)tower.towerHP / 100f);
        healthBar.transform.localScale = new Vector3(originScale.x * health, originScale.y, originScale.z);
    }
}
