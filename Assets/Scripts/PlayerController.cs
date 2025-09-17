using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isPlayerLeft = true;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 2f;
    [SerializeField] Transform ball;
    [SerializeField] int level = 1;

    [Header("Batas Gerak")]
    [SerializeField] float minY = -3.5f; 
    [SerializeField] float maxY = 3.5f;  

    float direction;

    void Update()
    {
        if (isPlayerLeft)
        {
#if UNITY_ANDROID || UNITY_IOS
            TouchInput(true);   
#else
            PlayerLeftInput(); 
#endif
        }
        else
        {
#if UNITY_ANDROID || UNITY_IOS
            if (level == 2)
                TouchInput(false); 
            else
                BotInput();
#else
            if (level == 2)
                PlayerRightInput();
            else
                BotInput();
#endif
        }

        rb.linearVelocity = new Vector2(0, direction) * speed;

        
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    void TouchInput(bool playerLeft)
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

               
                if (playerLeft && touch.position.x < Screen.width / 2)
                {
                    
                    if (touchPos.y > transform.position.y + 0.2f)
                        direction = 1f;
                    else if (touchPos.y < transform.position.y - 0.2f)
                        direction = -1f;
                    else
                        direction = 0f;
                }
                else if (!playerLeft && touch.position.x > Screen.width / 2)
                {
                   
                    if (touchPos.y > transform.position.y + 0.2f)
                        direction = 1f;
                    else if (touchPos.y < transform.position.y - 0.2f)
                        direction = -1f;
                    else
                        direction = 0f;
                }
            }
        }
        else
        {
            direction = 0f;
        }
    }

    void PlayerLeftInput()
    {
        if (Input.GetKey(KeyCode.W))
            direction = 1f;
        else if (Input.GetKey(KeyCode.S))
            direction = -1f;
        else
            direction = 0;
    }

    void PlayerRightInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            direction = 1f;
        else if (Input.GetKey(KeyCode.DownArrow))
            direction = -1f;
        else
            direction = 0;
    }

    void BotInput()
    {
        if (ball == null) return;

        if (ball.position.y > transform.position.y + 0.2f)
            direction = 1f;
        else if (ball.position.y < transform.position.y - 0.2f)
            direction = -1f;
        else
            direction = 0;
    }
}
