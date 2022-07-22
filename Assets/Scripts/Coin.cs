
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponent<Obstcale>()!= null)
        {
            Destroy(gameObject);
            return;
        }
        //check that the object we collided with is the player
        if (other.gameObject.name != "Player")
        {
           
            return;
        }

        //Add to the player's score
        FindObjectOfType<AudioManager>().Play("CollectingCoin");
        GameManager.inst.IncreamentScore();

        //Destroy this coin object
        Destroy(gameObject);
    }
    // Start is called before the first frame update
   private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
