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
            Leader.Move(destination);
        }
    }
    private void UpdateLeader(AllyCharacter character)
    {
        Leader = character;
        Debug.Log($"{Leader} has been selected!");
        LeadIndicator.SetLeader(Leader);
    }

    private void FixedUpdate()
    {
        if (Leader != null)
        {
            foreach(AllyCharacter character in Allies)
            {
                if (character != Leader) 
                {
                    if(Vector3.Distance(character.transform.position, Leader.transform.position) > 3)
                    {
                        character.Move(Leader.transform.position);
                    }
                    else
                    {
                        character.Stop();
                    }
                }
            }
        }
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
