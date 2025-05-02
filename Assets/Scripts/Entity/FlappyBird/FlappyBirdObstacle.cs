using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyBirdObstacle : MonoBehaviour
{
    [SerializeField] private Transform topObject;
    [SerializeField] private Transform bottomObject;

    [SerializeField] private float holeSizeMax = 3f;
    [SerializeField] private float holeSizeMin = 1f;

    [SerializeField] private float highPosY = 1f;
    [SerializeField] private float lowPosY = -1f;

    [SerializeField] private float widthPadding = 4f;

    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = ScoreManager.Instance;
    }

    public Vector3 SetRandomPosition(Vector3 lastPosition, int obstacleCount)
    {
        float holesize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holesize / 2f;
        topObject.localPosition = new Vector3(0,halfHoleSize);
        bottomObject.localPosition = new Vector3(0,-halfHoleSize);
        
        Vector3 setPosition = lastPosition + new Vector3(widthPadding, 0);
        setPosition.y = Random.Range(lowPosY, highPosY);


        transform.position = setPosition;

        return setPosition;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (!GameManager.Instance.IsPlaying) return;

        if(collision.CompareTag("Player"))
        {
            scoreManager.AddScore(1);
        }
    }
}
