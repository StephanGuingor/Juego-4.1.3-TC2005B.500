using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Wrapper for the scrolling background material
///
///  @Author Stephan Guingor
/// </summary>
/// 
[RequireComponent(typeof(Renderer))]
public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private Vector2 scrollSpeed = new Vector2(0.1f, 0f);
    
    private SpriteRenderer _renderer;
    private static readonly int OffsetSpeed = Shader.PropertyToID("_OffsetSpeed");

    private void OnValidate()
    {
        if (_renderer == null)
        {
            _renderer = gameObject.GetComponent<SpriteRenderer>();
        }
        
        
    }

    private void OnEnable()
    {
        // Sets the offset on the material, and scroll speed
        _renderer.material.SetVector(OffsetSpeed, scrollSpeed); 
    }
}
