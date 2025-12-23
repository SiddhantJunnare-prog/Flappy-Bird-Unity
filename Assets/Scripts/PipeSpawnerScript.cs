using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate;
    public float timer = 0;
    private float heightOffset = 4;
    public birdBehavior Bird;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Bird = GameObject.FindGameObjectWithTag("Player").GetComponent<birdBehavior>();
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        spawnRate = Random.Range(2f, 5f);

        if(timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            if (Bird.birdIsAlive)
            {
                spawnPipe();
                timer = 0;
            }
        }
            
    }
    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float Ypos = Random.Range(lowestPoint, highestPoint);

        Instantiate(pipe, new Vector3(transform.position.x, Ypos ,0), transform.rotation);
    }
}
