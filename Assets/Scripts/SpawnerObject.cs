using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
/// <summary>
/// Serializable Object that contains an object and the spawnpoints where it should be spawned.
///
///  @Author Stephan Guingor
/// </summary>
/// 
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnerObject", order = 1)]
public class SpawnerObject : ScriptableObject
{
    public GameObject prefab;
    public Vector3[] spawnPoints;
}