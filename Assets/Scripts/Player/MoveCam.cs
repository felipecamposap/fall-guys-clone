using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform camPos;


    // Update is called once per frame
    void Update()
    {
        if(camPos != null)
            transform.position = camPos.position;
    }
}
