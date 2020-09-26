using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerDirections
{
    up,
    down,
    right,
    left
}
public class PlayerMovement : MonoBehaviour, IMovement
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private PlayerStats stats;
    private Vector2 vectorDirection;
    [SerializeField] private float moveDelay;
    private float delayTimer = 0;
    [SerializeField] private PlayerDirections direction;
    private Vector2 nextTile;
    private Vector2 spawnPosition;
    private PlayerDirections originalDirection;
    private bool move;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        stats = GetComponent<PlayerStats>();
        sr = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
        originalDirection = direction;
        Game_UI.onPlayButtonClicked += Game_UI_onPlayButtonClicked;
        Game_UI.onRestartButtonClicked += Respawn;
        sr.enabled = false;
        Flag.onFlagEntered += Flag_onFlagEntered;
    }

    private void Flag_onFlagEntered()
    {
        move = false;
    }

    private void Game_UI_onPlayButtonClicked()
    {
        sr.enabled = true;
        move = true;
        transform.position = GameObject.FindGameObjectWithTag("Spawn").transform.position;
    }

    void Update()
    {
        Movement();
        delayTimer += Time.deltaTime;
        if(delayTimer >= moveDelay)
        {
            delayTimer = 0;
            FindNextTile();
            int nextValue;
            GameAssets.i.tileGrid.GetComponent<TileGrid>().gridSystem.GetValue(nextTile, out nextValue);
            //Debug.Log(nextValue);
            //GameAssets.i.tileGrid.GetComponent<TileGrid>().gridSystem.SetValue(nextTile, 3);
            if (nextValue != BlockDatabase.GetBlockID(Blocks.Barrier) && move)
            {
                transform.position += new Vector3(vectorDirection.x, vectorDirection.y, 0); //Grid movement
            }
            if (nextValue == 0)
            {
                Respawn();
            }
        }
    }
    private void Movement()
    {
        switch (direction)
        {
            case PlayerDirections.up:
                vectorDirection = Vector2.up;
                break;
            case PlayerDirections.down:
                vectorDirection = -Vector2.up;
                break;
            case PlayerDirections.right:
                vectorDirection = Vector2.right;
                break;
            case PlayerDirections.left:
                vectorDirection = -Vector2.right;
                break;
        }
    }

    public void SwitchDirection(PlayerDirections direction)
    {
        this.direction = direction;
    }
    private void FindNextTile()
    {
        switch (direction)
        {
            case PlayerDirections.up:
                nextTile = new Vector2(transform.position.x, transform.position.y + 1);
                break;
            case PlayerDirections.down:
                nextTile = new Vector2(transform.position.x, transform.position.y - 1);
                break;
            case PlayerDirections.right:
                nextTile = new Vector2(transform.position.x + 1, transform.position.y);
                break;
            case PlayerDirections.left:
                nextTile = new Vector2(transform.position.x - 1, transform.position.y);
                break;
        }
    }
    private void Respawn()
    {
        move = false;
        sr.enabled = false;
        Debug.Log("Respawn");
        transform.position = spawnPosition;
        GameManager.i.simulationRun = false;
        direction = originalDirection;
        GameManager.i.RestartSimulation();
    }

    void OnDestroy()
    {
        Game_UI.onPlayButtonClicked -= Game_UI_onPlayButtonClicked;
        Game_UI.onRestartButtonClicked -= Respawn;
        Flag.onFlagEntered -= Flag_onFlagEntered;
    }
}
