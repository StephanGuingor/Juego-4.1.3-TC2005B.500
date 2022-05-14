using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Spawns waves of objects
///
///  @Author Stephan Guingor
/// </summary>
/// 
public class Spawner : MonoBehaviour
{

    [Header("Spawner Patterns")]
    public SpawnerObject[] patterns;

    public float timeBetweenPatterns = 2f;

    private bool _canSpawn = true;
    void Start()
    {
        StartCoroutine(SpawnPatterns());
    }

    /// <summary>
    /// Spawns all objects in the given spawnpoints
    /// </summary>
    /// <param name="pattern"></param>
    private void SpawnPattern(SpawnerObject pattern)
    {
        foreach (Vector3 spawn in pattern.spawnPoints)
        {
            GameObject obj = Instantiate(pattern.prefab);
            obj.transform.position = spawn;

        }
    }
    
    /// <summary>
    /// Iterate through the patterns and calls the spawn pattern method 
    /// </summary>
    /// <param name="pattern"></param>
    private IEnumerator SpawnPatterns()
    {
        int idx = 0;
        int length = patterns.Length;
        while (_canSpawn)
        {
            SpawnPattern(patterns[idx]);
            idx = (idx + 1) % length;
            yield return new WaitForSeconds(timeBetweenPatterns);
        }
    } 
}