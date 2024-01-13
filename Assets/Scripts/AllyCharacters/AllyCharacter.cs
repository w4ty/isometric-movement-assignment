using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AllyCharacter : MonoBehaviour, IMoveable, IKillable, ISelectable, IRaycastable
{
    public CharacterDataScriptableObject CharacterData;

    public float Speed { get; set; }
    public float Agility { get; set; }
    public float Health { get; set; }

    private NavMeshAgent agent;


    void Awake()
    {
        Speed = Random.Range(CharacterData.SpeedMinMax.x, CharacterData.SpeedMinMax.y);
        Agility = Random.Range(CharacterData.AgilityMinMax.x, CharacterData.AgilityMinMax.y);
        Health = Mathf.RoundToInt(Random.Range(CharacterData.HealthMinMax.x, CharacterData.HealthMinMax.y));
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
    }

    public void Move(Vector3 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }

    public void Stop()
    {
        agent.isStopped = true;
    }

    public void Death()
    {
        Debug.Log("Dying");
    }
}
