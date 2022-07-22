
using UnityEngine;

public class Radar : MonoBehaviour
{

    PlayerMovement playerMovement;
    // Start is called before the first frame update
    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //kill the player
        if (collision.gameObject.name == "Player")
        {

            GameManager.inst.DecreamentScore();


        }

    }
    // Update is called once per frame
    private void Update()
    {
        
    }
}
