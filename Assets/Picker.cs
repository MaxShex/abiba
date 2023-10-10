using UnityEngine;

public class Picker : MonoBehaviour
{
    public Transform pivot;
    public float upscale;
    
    Rigidbody myobject;
    
    void Update()
    {
        if (myobject == null && Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10f))
            {
                Rigidbody hitObject = hit.rigidbody;
                
                if (hitObject != null && hitObject.gameObject.CompareTag("Pick"))
                {
                    myobject = hitObject;
                    myobject.velocity = Vector3.zero;
                    transform.localScale *= upscale;
                }
            }
        }
        else if (myobject != null && Input.GetKeyDown(KeyCode.E))
        {
            myobject = null;
            transform.localScale /= upscale;
        }

        if (myobject != null)
        {
            myobject.transform.position = pivot.position;
            myobject.transform.rotation = pivot.rotation;
            myobject.velocity = Vector3.zero;
        }
    }
}
