using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyManager : MonoBehaviour
{
    [SerializeField]
    private InteractionManager interactionManager;
    [SerializeField]
    private UIManager uiManager;
    [SerializeField]
    private AStar pathfinder;
    public AllyCharacter Leader;
    public LeaderIndicator LeadIndicator;
    public List<AllyCharacter> Allies;

    private void OnSelectable(ISelectable character)
    {
        UpdateLeader(character as AllyCharacter);
    }
    
    private void OnWalkable(Vector3 destination)
    {
        if (Leader != null)
        {
            pathfinder.FindPath(Leader.transform.position, destination);
        }
    }
    private void UpdateLeader(AllyCharacter character)
    {
        Leader = character;
        Debug.Log($"{Leader} has been selected!");
        LeadIndicator.SetLeader(Leader);
    }

    private void Awake()
    {
        if (interactionManager != null)
        {
            interactionManager.OnSelectable += OnSelectable;
            interactionManager.OnWalkable += OnWalkable;
        }
        if (uiManager != null)
        {
            uiManager.OnSelectable += OnSelectable;
        }
    }

    private void OnDestroy()
    {
        if (interactionManager != null)
        {
            interactionManager.OnSelectable -= OnSelectable;
            interactionManager.OnWalkable -= OnWalkable;
        }
        if (uiManager != null )
        {
            uiManager.OnSelectable -= OnSelectable;
        }
    }
}
