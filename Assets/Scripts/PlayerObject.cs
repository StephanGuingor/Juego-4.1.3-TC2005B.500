using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Wrapper for the scrolling background material
///
///  @Author Stephan Guingor
/// </summary>
/// 
public class PlayerObject : MonoBehaviour
{
    /// <summary>
    /// Handles collision with enemies and the goal.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            GameManager.INSTANCE.AddScore(); 
        }
        
        else if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.INSTANCE.AddScorePenalty(); 
            Destroy(other.gameObject);
        }
        
    }
}
