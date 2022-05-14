using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

/// <summary>
/// Handles players (spawning and movement)
///
///  @Author Stephan Guingor
/// </summary>
public class Player : MonoBehaviour
{
    [Header("Sprite Settings")] 
    public Sprite leftPlayer;
    public Sprite rightPlayer;
    public Sprite defaultPlayer;

    [Header("Movement")]
    public float playerSpeed;

    [Header("Player")] public GameObject playerPrefab;
    
    private Vector2 _movement;
    private Camera _camera;
    private float _camHeight;
    private float _maxOutBounds;

    private GameObject[] _players = new GameObject[3];
    
    private void Start()
    {
        _camera = Camera.main;

        CreatePlayers();
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Vertical");
        SetSprites();
    }

    private void FixedUpdate()
    {
        MovePlayers(); 
    }

    /// <summary>
    /// Creates all needed players
    /// </summary>
    private void CreatePlayers()
    {
        _camHeight = (_camera.orthographicSize * 2f);
        _maxOutBounds = transform.position.y + _camHeight * 2f;
        
        _players[0] = Instantiate(playerPrefab, transform);
        
        GameObject up = Instantiate(playerPrefab, transform);
        up.transform.position = transform.position + Vector3.up * _camHeight;
        _players[1] = up;
        
        GameObject down = Instantiate(playerPrefab, transform);
        down.transform.position = transform.position + Vector3.up * -_camHeight;
        _players[2] = down;

    }

    /// <summary>
    /// Sets all players sprites
    /// </summary>
    private void SetSprites()
    {
        Sprite sprite = defaultPlayer;
        
        if (_movement.x > 0)
        {
            sprite = leftPlayer;
        }
        
        else if (_movement.x < 0)
        {
            sprite = rightPlayer; 
        }
        
        foreach (GameObject player in _players)
        {
            player.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
    
    /// <summary>
    /// Updates all players positions
    /// </summary>
    private void MovePlayers()
    {
        foreach (GameObject player in _players)
        {
            player.transform.position += new Vector3(0f, _movement.x, 0f) * playerSpeed * Time.deltaTime;

            // Wrap the player around y axis if needed
            player.transform.position = WrapPlayer(player.transform.position);
        } 
    }
    
     /// <summary>
     /// Wrap a vector representing the player position around the middle player clone, when it goes out of the max bounds. 
     /// </summary>
     /// <param name="position"></param>
     /// <returns></returns>
    private Vector3 WrapPlayer(Vector3 position)
    {
        if (position.y >= _maxOutBounds)
        {
            position.y -= 3 * _camHeight;
        } 
        
        else if (position.y <= -_maxOutBounds)
        {
            position.y += 3 * _camHeight;
        }

        return position;
    }
}
