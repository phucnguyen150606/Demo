using Unity.VisualScripting;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    [SerializeField]private GameManagerScript manager;
    void Start()
    {
       manager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bird"))
        {
            manager.addScore(1);
           AudioManager_Script.Instance.PlayPointSound(); // Play the point sound when the bird passes through the pipe
        }

    }

}
