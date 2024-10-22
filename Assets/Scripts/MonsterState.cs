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

    [SerializeField] Animator animator;


    public bool getDamage = false;
    Transform tower;
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
        animator = GetComponent<Animator>();
        agent.enabled = false;
        agent.speed = moveSpeed;
    }

    private void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Damage") && stateInfo.normalizedTime < 1.0f)
        {
            return; 
        }

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
        animator.Play("Idle");
        agent.enabled = true;
        state = OrcState.Move;            
        state = OrcState.Move;            
    }
    private void Move()
    {
        agent.SetDestination(tower.position);
        animator.Play("Walk");

        if (Vector3.Distance(transform.position, tower.position) < attackRange)
        {
            state = OrcState.Attack;
            agent.enabled = false;
        }
        
        if (getDamage == true)
        {
            state = OrcState.Damage;
        }
    }
    private void Attack()
    {
        currentTime += Time.deltaTime;
        if (currentTime > attackRange)
        {
            // 공격 모션 실행 
            animator.Play("Attack");
            // 타워에 데미지
            tower.GetComponent<TowerScript>().GetDamage((int)attackDamage);

            currentTime = 0;
        }
    }
    private void Damage()
    {                      
        // 피격 애니메이션
        animator.Play("Damage");        
        // hp 감소
        monsterHP -= 1;

        if (monsterHP <= 0)
        {            
            // hp 전부 소모시 사망
            state = OrcState.Die;
        }
        else
        {
            state = OrcState.Idle;
        }
    }        
    private void Die()
    {
        // 사망 애니메이션 
        animator.Play("Death-A"); 
        // 사망 사운드

        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 충돌한것이 불릿일때
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            getDamage = true;
        }
    }
}
