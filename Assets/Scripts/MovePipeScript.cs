using UnityEngine;


public class MovePipe : MonoBehaviour
{
    public float Speed = 3;
    public GameManagerScript manager;
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void Update()
    {
        if (gameObject.transform.position.x < -18)
        {
            Destroy(gameObject); //destroy the pipe if it goes off screen
        }
        else
        {
            gameObject.transform.position += Vector3.left * Speed * Time.deltaTime; //move the pipe to the left
        }
  

    }
}
