using UnityEngine;

public class CamPlayer : MonoBehaviour
{
    public float sensX;

    public Transform orientation;

    float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (orientation != null)
        {
            transform.position = orientation.position;
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            yRotation += mouseX;
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

}
