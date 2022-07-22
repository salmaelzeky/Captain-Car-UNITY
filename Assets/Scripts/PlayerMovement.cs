
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
   public  bool alive = true;
    public float speed = 5;
    [SerializeField] Rigidbody rb;

    float horizontalInput;
    [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.5f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate()
    {
        
            if (!alive) return;
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
            rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
        if (PauseMenu.GameIsPaused == true)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
       
           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (transform.position.y < -5)
            {
                Die();

            }
        
    
    }

    public void Die()
    {
        alive = false;
        GameOverScreen.GameOver = true;

    }

    
    void Restart()
    {
        //Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  
    void Jump()
    {
        //check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height/4)+0.1f, groundMask);


        // if we are, jump
        if (gameObject.transform.position.y < 1.5)
        {
            FindObjectOfType<AudioManager>().Play("CarJump");
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}
