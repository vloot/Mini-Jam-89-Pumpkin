using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;
    [SerializeField] private float runSpeed = 40;

    private float _movement;
    private bool _jump;

    public float GetMovement => _movement;

    void Update()
    {
        if (GameManager.IsGameOver) return;

        _movement = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
        }

    }

    private void FixedUpdate()
    {
        if (!GameManager.IsGamePlaying && _movement != 0)
        {
            GameManager.IsGamePlaying = true;
        }
        playerController.Move(_movement * Time.fixedDeltaTime, false, _jump);
        _jump = false;
    }
}