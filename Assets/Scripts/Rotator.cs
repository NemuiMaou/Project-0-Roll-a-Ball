using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Multiplied by deltaTime to make the rotation independent
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
