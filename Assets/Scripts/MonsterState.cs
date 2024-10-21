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

    [SerializeField] Transform tower;
    // 네비게이션
    NavMeshAgent agent;

    private void Start()
    {
        switch (monsterPrefab.name)
        {
            case "Orc1Lv(Clone)":
                moveSpeed = 0.8f;
                attackDamage = 1;
                monsterHP = 1;
                break;
            case "Orc2Lv(Clone)":
                moveSpeed = 1;
                attackDamage = 2;
                monsterHP = 2;
                break;
            case "Orc3Lv(Clone)":
                moveSpeed = 1.5f;
                attackDamage = 4;
                monsterHP = 3;
                break;
            case "Orc4Lv(Clone)":
                moveSpeed = 0.5f;
                attackDamage = 8;
                monsterHP = 4;
                break;
            case "Orc5Lv(Clone)":
                moveSpeed = 1.5f;
                attackDamage = 10;
                monsterHP = 3;
                break;
        }

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
        state = OrcState.Idle;
        agent.enabled = true;
    }
    private void Move()
    {
        agent.SetDestination(tower.position);
    }
    private void Attack()
    {
    }
    private void Damage()
    {
    }
    private void Die()
    {
    }
}
