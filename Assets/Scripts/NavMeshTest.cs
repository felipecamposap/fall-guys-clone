using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class JumpBetweenPlatforms : MonoBehaviour
{
    public NavMeshAgent agent;
    public NavMeshLink currentLink;
    [SerializeField] private Transform destination;
    public bool isJumping = false;
    private Vector3 jumpStartPosition;
    public float jumpHeight = 2.0f; // Altura do salto ajustada para 10.0f
    public float jumpDuration = 2.0f; // Duração do salto ajustada para 2.0f

    private Vector3 jumpStartPoint;
    private Vector3 jumpEndPoint;
    private float jumpStartTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
        agent.autoTraverseOffMeshLink = false; // Desativa a travessia automática de links
    }

    void Update()
    {
        if (agent.isOnOffMeshLink && !isJumping)
        {
            StartJump();
        }

        if (isJumping)
        {
            UpdateJump();
        }
    }

    void StartJump()
    {
        isJumping = true;
        jumpStartPosition = transform.position;

        // Obtém os pontos de início e fim do NavMeshLink
        jumpStartPoint = currentLink.startPoint;
        jumpEndPoint = currentLink.endPoint;
        jumpStartTime = Time.time;

        // Desativa o NavMeshAgent durante o salto
        agent.isStopped = true;
    }

    void UpdateJump()
    {
        // Calcula o progresso do salto
        float jumpProgress = (Time.time - jumpStartTime) / jumpDuration;
        jumpProgress = Mathf.Clamp01(jumpProgress); // Certifica-se de que o progresso esteja entre 0 e 1

        // Calcula a altura do salto usando uma trajetória parabólica
        float jumpHeightProgress = Mathf.Sin(jumpProgress * Mathf.PI);
        Vector3 jumpPosition = Vector3.Lerp(jumpStartPoint, jumpEndPoint, jumpProgress);
        jumpPosition.y += jumpHeight * jumpHeightProgress; // Define a altura do salto

        // Move o agente para a posição calculada do salto
        agent.transform.position = jumpPosition;

        // Verifica se o salto foi concluído
        if (jumpProgress >= 1.0f)
        {
            isJumping = false;

            // Reativa o NavMeshAgent
            agent.isStopped = false;

            // Avança manualmente para o próximo ponto na navegação
            agent.CompleteOffMeshLink();
        }
    }
}