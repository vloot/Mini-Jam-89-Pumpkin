using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject player;        //Public variable to store a reference to the player game object
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float threshold;


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera
    [SerializeField] bool _offset = true;

    // Use this for initialization
    void Start()
    {
        var playerPos = player.transform.position;
        playerPos.z = transform.position.z;
        playerPos.x = transform.position.x;
        transform.position = playerPos;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;

        playerController.OnJumpEvent.AddListener(() => _offset = false);
        playerController.OnLandEvent.AddListener(() => _offset = true);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (!_offset) return;
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        var currentPos = transform.position;
        var positionNoX = player.transform.position + offset;
        positionNoX.x = 0;
        var smoothed = Vector3.Lerp(currentPos, positionNoX, cameraSpeed);
        var diff = Mathf.Abs(currentPos.y - smoothed.y);
        if (diff > threshold)
        {
            transform.position = smoothed;
        }
    }
}