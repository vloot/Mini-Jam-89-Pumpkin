using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PlayerMovement playerMovement;

    private float timeSinceRestart;
    private int _score;

    private void Start()
    {
        // TODO add timer reset
    }


    private void FixedUpdate()
    {
        if (playerMovement.GetMovement != 0)
        {
            _score++;
            scoreText.text = _score.ToString();
        }
    }
}
