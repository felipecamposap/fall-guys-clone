using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.forward * speed);
        Destroy(this.gameObject, 5f);
    }

    
  
}
