using UnityEngine;

public class Char : MonoBehaviour
{
    public Rigidbody rigidbody;
    
    public float speed;
    public float jump;

    public Transform camera;
    
    public float rotSpeed;

    float rotationX;

    Vector2 prevMousePos;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.forward * (-speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * (speed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * (-speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jump, ForceMode.Impulse);
        }
        
        float mouseX = Input.GetAxis("Mouse X") * rotSpeed;
        rotationX += Input.GetAxis("Mouse Y") * -rotSpeed;
        rotationX = Mathf.Clamp(rotationX, -90.0f, 90.0f);

        camera.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}
