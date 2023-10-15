using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    [Header("Player: ")]
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform orientation;
    float horizontalInput, verticalInput;
    Vector3 moveDir;
    bool isJumping, gameEnded;

    [Header("Referencias: ")]
    [SerializeField] private TMP_Text txtVitoria;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject firework;

    // Update is called once per frame
    private void Update()
    {
        MyInput();
        if (!isJumping && Input.GetButtonDown("Jump"))
            Jump();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDir.normalized * speed * 10f, ForceMode.Force);
    }

    private void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Victory"))
        {
            Victory();
        }
        if (other.CompareTag("Explosion") || other.CompareTag("Helix"))
        {
            //GameController.controller.WinLose(0);
            Defeat();
            Instantiate(explosion, transform.position, transform.rotation);
            if (other.CompareTag("Explosion"))
                Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.drag = 0.2f;
            isJumping = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.drag = 0.1f;
    }

    public void Victory()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            Instantiate(firework, transform.position, Quaternion.identity);
            GetComponentInChildren<MeshRenderer>().enabled = false;
            rb.isKinematic = true;
            txtVitoria.text = "VITÓRIA!";
            Invoke("Reset", 3f);
        }

    }

    public void Defeat()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            rb.isKinematic = true;
            txtVitoria.color = Color.red;
            txtVitoria.text = "DERROTA!";
            Invoke("Reset", 3f);
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(1);
    }
}
