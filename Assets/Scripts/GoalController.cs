using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField] private bool isLeftGoal;   
    [SerializeField] private BallController ball;
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (isLeftGoal)
            {
                gameManager.PlayerRightScored();
            }
            else
            {
                gameManager.PlayerLeftScored();
            }

            ball.LaunchBall();
        }
    }
}
