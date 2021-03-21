using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCoin : MonoBehaviour
{
    static int coinCounter = 0;
    float rotateSpeed = 70.0f;
    float _coordY;
    float _boundY;
    bool directionUp = true;
    int frameCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        _coordY = transform.position.y;
        _boundY = _coordY + 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        if (frameCount % 12 == 0)
        {
            Vector3 newPosition = transform.position + (getDirectionVector() * 0.05f);
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            coinCounter++;
            Debug.Log("Coins " + coinCounter);
            Destroy(gameObject);
        }
    }

    private Vector3 getDirectionVector()
    {
        if (directionUp)
        {
            if(transform.position.y < _boundY)
            {
                return Vector3.up;
            }
            directionUp = false;
            return Vector3.down;
        }
        if (transform.position.y > _coordY) // Direction - down
        {
            return Vector3.down;
        }
        directionUp = true;
        return Vector3.up;
    }
}
