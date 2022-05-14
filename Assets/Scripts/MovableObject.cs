using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
/// <summary>
/// Moves an object
///
///  @Author Stephan Guingor
/// </summary>
public class MovableObject : MonoBehaviour
{
    [Header("Movement")] public float speed = 2f;

    
    /// <summary>
    /// Moves the object 
    /// </summary>
    void FixedUpdate()
    {
        transform.position -=  Vector3.right * speed * Time.deltaTime;
    }
    
}
