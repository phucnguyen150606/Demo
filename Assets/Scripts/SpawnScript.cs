using UnityEngine;
using Unity.VisualScripting;


public class PipeScript : MonoBehaviour
{
    public GameObject Pipe;
    public float Spawnrate = 2; // how often to spawn pipes
    private float timer = 0; // timer to track spawn time
    public float Height = 10; // height of the pipe
    void Start()
    {
        Spawn(); // spawn the first pipe immediately
    }

    void Update()
    {
        if (timer < Spawnrate)
        {
            timer += Time.deltaTime; // increment the timer
        }
        else
        {
            Spawn(); // spawn a pipe
            timer = 0;
        }
    }

    void Spawn()
    {
        float Lowestposition = transform.position.y - Height;
        float Highestposition = transform.position.y + Height;
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(Lowestposition, Highestposition),0), transform.rotation); // spawn a pipe at the current position with a random y value between Lowestposition and Highestposition
    }
}
