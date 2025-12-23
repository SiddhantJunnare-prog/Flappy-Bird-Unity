using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 10;
    private float DeadZone = -12;
    
    void Update()
    {
        transform.position = transform.position + (Vector3.left * speed) * Time.deltaTime;

        if(transform.position.x <= DeadZone)
        {
            Destroy(gameObject);
        }
    }
}
