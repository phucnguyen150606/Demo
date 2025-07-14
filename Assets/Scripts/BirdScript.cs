using UnityEngine;
using UnityEngine.Rendering.UI;

public class BirdScript : MonoBehaviour
{
    public GameManagerScript manager; // Reference to the GameManagerScript
    public SaveData saveData;
    public float FlapStreight = 5;
    public Rigidbody2D birdrigidboy;

    Animator animator;
    

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        animator = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (manager.GameOverUI.activeSelf || manager.Setting_Screen.activeSelf) return;
        animator.SetFloat("yVelocity", birdrigidboy.linearVelocity.y); //set the y velocity parameter in the animator
        if (Input.GetKeyDown(KeyCode.Space)) //when the space key is pressed
        {
            birdrigidboy.linearVelocity = Vector2.up * FlapStreight; //apply an upward force to the bird
            AudioManager_Script.Instance.PlayFlapSound(); //play the flap sound
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground")) //if the bird collides with the pipe or ground
        {
            manager.GameOver();
            AudioManager_Script.Instance.PlayDieSound(); //play the die sound
        }
    }
}
