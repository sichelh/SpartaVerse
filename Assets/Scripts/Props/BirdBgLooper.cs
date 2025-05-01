using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdLooper : MonoBehaviour
{
    [SerializeField] private int bgCount = 5;
    
    [SerializeField] private int obstacleCount = 0;
    [SerializeField] private Vector3 obstacleLastPosition = Vector3.zero;

    void Start()
    {
        BirdObstacle[] obstacles = GameObject.FindObjectsOfType<BirdObstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i=0; i<obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPosition(obstacleLastPosition, obstacleCount);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BackGround"))
        {
            float widthOfBg = ((BoxCollider2D)collision).size.x;
            Vector3 position = collision.transform.position;

            position.x += widthOfBg * bgCount;
            collision.transform.position = position;
            return;
        }
        
        BirdObstacle obstacle = collision.GetComponent<BirdObstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPosition(obstacleLastPosition, obstacleCount);
        }
    }
}
