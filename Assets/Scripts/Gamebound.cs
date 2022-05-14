using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Represents a bound that will destroy all objects
///
///  @Author Stephan Guingor
/// </summary>
public class Gamebound : MonoBehaviour
{
    /// <summary>
    /// When an object collides it gets detroyed.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D (Collider2D other)
    {
       Destroy(other.gameObject); 
    }
}
