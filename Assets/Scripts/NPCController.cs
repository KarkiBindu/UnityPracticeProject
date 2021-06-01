using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public float PatrolTime = 10f;
    public float AggroRange = 10f;
    public Transform[] WayPoints;

    int _index;
    float _speed, _agentSpeed;
    Transform _player;

    Animator _anim;
    NavMeshAgent _agent;

    private void Awake()
    {
       // _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        if (_agent != null)
        {
            _agentSpeed = _agent.speed;           
        }
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _index = Random.Range(0, WayPoints.Length);
        InvokeRepeating("Tick", 0, 0.5f);
        if (WayPoints.Length > 0)
        {
            InvokeRepeating("Patrol", 0, PatrolTime);
        }
    }

    void Patrol()//timer
    {
        _index = _index == WayPoints.Length - 1 ? 0: _index + 1;
    }

    void Tick()//timer
    {
        _agent.destination = WayPoints[_index].position;
        _agent.speed = _agentSpeed / 2;
        if(_player!=null && Vector3.Distance(transform.position, _player.position) < AggroRange)
        {
            _agent.destination = _player.position;
            _agent.speed = _agentSpeed;
        }
    }
}
