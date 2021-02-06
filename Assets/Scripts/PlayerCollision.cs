using UnityEngine;
public class PlayerCollision : MonoBehaviour
{
    public PlayerMoviment movement;
    public AudioSource PlayerSound; //Som
    private AudioSource ObjectSound;
    private void Start()
    {
        PlayerSound = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            ObjectSound = collisionInfo.gameObject.GetComponent<AudioSource>();
            PlayerSound.clip = ObjectSound.clip;
            PlayerSound.Play(); //Som
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Points") {
            ObjectSound = collisionInfo.gameObject.GetComponent<AudioSource>();
            PlayerSound.clip = ObjectSound.clip;
            PlayerSound.Play(); //Som
        }
    }
}
