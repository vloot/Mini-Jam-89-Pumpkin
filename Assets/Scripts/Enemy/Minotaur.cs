using UnityEngine;
using System.Collections.Generic;

public class Minotaur : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    [SerializeField] private float distanceThreshold;
    [SerializeField] private float speed = 36;

    private List<Vector3> waypoints;

    [SerializeField] private int _waypointIndex;

    private void Start()
    {
        waypoints = new List<Vector3>();
        foreach (var platform in levelGenerator.GetPlatforms)
        {
            foreach (var waypoint in platform.waypoints)
            {
                waypoints.Add(waypoint.position);
            }
        }
        _waypointIndex++;
    }

    private void FixedUpdate()
    {
        if (!GameManager.IsGamePlaying || GameManager.IsGameOver) return;
        var currentPos = transform.position;
        var currentWaypoint = waypoints[_waypointIndex];
        var dist = Vector3.Distance(currentPos, currentWaypoint);

        if (dist > distanceThreshold)
        {
            var moveVetor = Vector3.MoveTowards(currentPos, currentWaypoint, Time.fixedDeltaTime * speed);
            transform.position = moveVetor;
        }
        else
        {
            _waypointIndex++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == GameLayers.PlayerLayer)
        {
            // Game over
            Debug.Log("Game Over");
            GameManager.IsGameOver = true;
        }
    }

}
