using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
  public Transform Player;
  public NavMeshAgent agent;
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.updateRotation = false;
    agent.updateUpAxis = false;
  }

  public void SetSpeed(float newSpeed)
  {
    agent = GetComponent<NavMeshAgent>();
    agent.speed = newSpeed;
  }

  void Update()
  {
    agent.SetDestination(Player.position);
  }
}
