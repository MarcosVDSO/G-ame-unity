using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public float minX, maxX;
    public float timeLerp;
    // Start is called before the first frame update
    private void FixedUpdate() {
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);
        newPosition.y = 0.1f;
        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);
        transform.position = newPosition;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }
}