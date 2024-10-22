using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarScript : MonoBehaviour
{
    public GameObject healthBar;  // ü�¹� 3D ������Ʈ
    public TowerScript tower;  // Ÿ�� ��ũ��Ʈ

    private Vector3 originScale;  // ü�¹��� �ʱ� ũ��

    private void Start()
    {
        // ü�¹��� �ʱ� ũ�� ����
        originScale = healthBar.transform.localScale;
    }

    private void Update()
    {
        // ü�¿� ���� ü�¹� ũ�� ����
        float health = Mathf.Clamp01((float)tower.towerHP / 100f);
        healthBar.transform.localScale = new Vector3(originScale.x * health, originScale.y, originScale.z);
    }
}
