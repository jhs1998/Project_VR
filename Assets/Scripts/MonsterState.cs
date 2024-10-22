using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterState : MonoBehaviour
{
    enum OrcState
    {
        Idle, Move, Attack, Damage, Die
    }

    OrcState state = OrcState.Idle;

    [SerializeField] GameObject monsterPrefab;
    public float moveSpeed;
    public float attackDamage;
    public float monsterHP;
    public float attackRange;
    public float attackDelay = 3;
    public float currentTime;

    public bool getDamage = false;
    Transform tower;
    // �׺���̼�
    NavMeshAgent agent;

    private void Start()
    {
        switch (monsterPrefab.name)
        {
            case "Orc1Lv(Clone)":
                moveSpeed = 0.8f;
                attackDamage = 1;
                monsterHP = 1;
                attackRange = 1;
                break;
            case "Orc2Lv(Clone)":
                moveSpeed = 1;
                attackDamage = 2;
                monsterHP = 2;
                attackRange = 2;
                break;
            case "Orc3Lv(Clone)":
                moveSpeed = 1.5f;
                attackDamage = 4;
                monsterHP = 3;
                attackRange = 3;
                break;
            case "Orc4Lv(Clone)":
                moveSpeed = 0.5f;
                attackDamage = 8;
                monsterHP = 4;
                attackRange = 4;
                break;
            case "Orc5Lv(Clone)":
                moveSpeed = 1.5f;
                attackDamage = 10;
                monsterHP = 3;
                attackRange = 10;
                break;
        }
        tower = GameObject.Find("Tower").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.speed = moveSpeed;
    }

    private void Update()
    {
        switch (state)
        {
            case OrcState.Idle:
                Idle();
                break;
            case OrcState.Move:
                Move();
                break;
            case OrcState.Attack:
                Attack();
                break;
            case OrcState.Damage:
                Damage();
                break;
            case OrcState.Die:
                Die();
                break;
        }
    }

    private void Idle()
    {
        state = OrcState.Move;
        agent.enabled = true;
    }
    private void Move()
    {
        agent.SetDestination(tower.position);

        if(Vector3.Distance(transform.position, tower.position) < attackRange)
        {
            state = OrcState.Attack;
            agent.enabled = false;
        }
    }
    private void Attack()
    {
        currentTime += Time.deltaTime;
        if (currentTime > attackRange)
        {
            // ���� ��� ���� 

            // Ÿ���� ������
            tower.GetComponent<TowerScript>().GetDamage((int)attackDamage);

            currentTime = 0;
        }
    }
    private void Damage()
    {
        getDamage = true;
        
        if (getDamage)
        {
            // �ǰ� �ִϸ��̼�
           
        }
        // hp ����
        monsterHP -= 1;
        Debug.Log($"���� {monsterHP}");
        if (monsterHP <= 0)
        {
            Debug.Log("���� ���");
            // hp ���� �Ҹ�� ���
            state = OrcState.Die;
        }
        else
        {
            state = OrcState.Idle;
        }
    }        
    private void Die()
    {
        // ��� �ִϸ��̼� 
        Debug.Log("���� ���");
        // ��� ����

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �浹�Ѱ��� �Ҹ��϶�
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log("���� ����");
            state = OrcState.Damage;
        }
    }
}
