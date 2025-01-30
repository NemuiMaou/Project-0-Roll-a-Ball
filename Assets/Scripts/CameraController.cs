using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Gives us a reference to the player GameObject
    public GameObject player;
    
    // This will be the distance between the camera and the player
    private Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // How you calculate the initial offset between the camera's position and the player's position
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame after all update functions
    void LateUpdate()
    {
        // How to maintain the same offset between the camera and the player
        transform.position = player.transform.position + offset;
    }
}
