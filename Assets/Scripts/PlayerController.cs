using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;
    void Awake()
    {
       // _anim = GetComponent<Animator>();
       _agent = GetComponent<NavMeshAgent>();
    }

    
}
