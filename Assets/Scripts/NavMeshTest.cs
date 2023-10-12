using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class JumpBetweenPlatforms : MonoBehaviour
{   public NavMeshAgent agent;
    [SerializeField] private Transform[] destination;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float distancejump;
    [SerializeField] private float heightjump;
    [SerializeField] private bool isjumping=false;
    [SerializeField] private int targetcontrol;
    void Start()
    {
        
        StartNavigation();
        
    }
<<<<<<< Updated upstream

    void Update()
    {
       
    }
    private void StartNavigation()
    {
        
        agent.SetDestination(new Vector3(destination[targetcontrol].position.x,destination[targetcontrol].position.y,Random.Range(-4.7f,4.7f)));
=======
    private void StartNavigation()
    {
        agent.SetDestination(new Vector3(destination[targetcontrol].position.x,destination[targetcontrol].position.y,destination[targetcontrol].position.z + Random.Range(-4.7f,4.7f)));
>>>>>>> Stashed changes
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            isjumping = true;
            if (isjumping)
            {
                agent.enabled = false;

                rb.AddForce(transform.forward * distancejump, ForceMode.Impulse);
                rb.AddForce(Vector3.up * heightjump, ForceMode.Impulse);
            }

        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isjumping = false;
            agent.enabled = true;
            targetcontrol++;
            StartNavigation();
            
        }
    }
    



}
