using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState {
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private CharactarAni enemy_ani;
    private NavMeshAgent NavAgent;
    private Transform playerTarget;
    public float move_speed = 3.5f;
    public float attack_distance = 4f;
    private float chase_player_after_attack_distace = 1f;
    private float Wait_before_atttack_time = 3f;
    private float attack_timer;

    private EnemyState enemy_state;

    // Start is called before the first frame update
    void Awake()
    {
        enemy_ani = GetComponent<CharactarAni>();
        NavAgent = GetComponent<NavMeshAgent>();

        playerTarget = GameObject.FindGameObjectWithTag(tags.Player_tag).transform;
        
    }

    void Start()
    {
        enemy_state = EnemyState.CHASE;
        attack_timer = Wait_before_atttack_time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_state == EnemyState.CHASE)
        {
            CHASEPlayer();
        }
        if(enemy_state == EnemyState.ATTACK)
        {
            AttackPlayer();
        }
    }

    void CHASEPlayer() {
        NavAgent.SetDestination(playerTarget.position);
        NavAgent.speed = move_speed;
        if(NavAgent.velocity.sqrMagnitude == 0)
        {
            enemy_ani.Walk(false);
        }
        else
        {
            enemy_ani.Walk(true);
        }
        if (Vector3.Distance(transform.position, playerTarget.position) <= attack_distance)
        {
            enemy_state = EnemyState.ATTACK;
        }
    }
    void AttackPlayer() { }


}
