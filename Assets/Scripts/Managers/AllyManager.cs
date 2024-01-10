using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyManager : MonoBehaviour
{
    [SerializeField]
    private InteractionManager interactionManager;
    public AllyCharacter Leader;
    public List<AllyCharacter> Allies;

    private void OnCharacterSelected(AllyCharacter character)
    {
        Debug.Log($"{character} has been selected!");
    }
    
    private void OnWalkable(Vector3 destination)
    {
        Debug.Log($"{destination} is walkable!");
    }

    private void Awake()
    {
        if (interactionManager != null)
        {
            interactionManager.OnCharacterSelected += OnCharacterSelected;
            interactionManager.OnWalkable += OnWalkable;
        }

        Allies = new List<AllyCharacter>(FindObjectsOfType<AllyCharacter>(false));
    }

    private void OnDestroy()
    {
        if (interactionManager != null)
        {
            interactionManager.OnCharacterSelected -= OnCharacterSelected;
            interactionManager.OnWalkable -= OnWalkable;
        }
    }
}
