using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyManager : MonoBehaviour
{
    [SerializeField]
    private InteractionManager interactionManager;
    public AllyCharacter Leader;
    public LeaderIndicator LeadIndicator;
    public List<AllyCharacter> Allies;

    private void OnSelectable(ISelectable character)
    {
        Leader = character as AllyCharacter;
        Debug.Log($"{Leader} has been selected!");
        LeadIndicator.SetLeader(Leader);
    }
    
    private void OnWalkable(Vector3 destination)
    {
        Debug.Log($"{destination} is walkable!");
    }

    private void Awake()
    {
        if (interactionManager != null)
        {
            interactionManager.OnSelectable += OnSelectable;
            interactionManager.OnWalkable += OnWalkable;
        }
    }

    private void OnDestroy()
    {
        if (interactionManager != null)
        {
            interactionManager.OnSelectable -= OnSelectable;
            interactionManager.OnWalkable -= OnWalkable;
        }
    }
}
