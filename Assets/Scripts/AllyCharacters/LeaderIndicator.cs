using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderIndicator : MonoBehaviour
{
    public void SetLeader(AllyCharacter leader)
    {
        transform.parent = leader.transform;
        transform.position = new Vector3(leader.transform.position.x, leader.transform.position.y + 1, leader.transform.position.z);
    }
}
