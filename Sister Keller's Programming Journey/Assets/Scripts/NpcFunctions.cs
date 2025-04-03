using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public enum NpcState
{
    Break, Walking,
}
public class NpcFunctions : MonoBehaviour
{
    NavMeshAgent agent;
    public NpcState npc;
    bool canWalk;

    public UnityEvent OnBreak, OnWalking;
    DialogueManager diaManager;
    public Transform playerTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        diaManager = FindObjectOfType<DialogueManager>();
        SetDestiny();
    }

    void Update()
    {
        switch (npc)
        {
            case NpcState.Break: //modo de aguardo
                break;
            case NpcState.Walking:
                if (agent.stoppingDistance >= agent.remainingDistance)
                { //se estiver chegando ao destino, espere
                    SetNpcState(NpcState.Break);
                }
                agent.isStopped = false;
                break;
        }
    }
    void SetDestiny() //anda para um ponto aleatório
    {
        agent.SetDestination(SetRandomNavTarget());
        SetNpcState(NpcState.Walking);
    }
    Vector3 SetRandomNavTarget()
    {
        Vector3 randomPosition = Random.insideUnitSphere * 30;
        randomPosition.y = 0;
        randomPosition += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPosition, out hit, 5, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }
    IEnumerator GiveaBreak()
    {
        yield return new WaitForSeconds(4); //tempo de espera

        SetDestiny();   //setar um novo destino e começar a ir
    }
    IEnumerator IsDialoguing()
    {
        if (playerTransform != null)
        {
            // Para o NPC enquanto dialoga
            agent.isStopped = true;

            // Gira o NPC na direção do jogador
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));

            // Suaviza a rotação
            float rotationSpeed = 5f;
            while (Quaternion.Angle(transform.rotation, lookRotation) > 0.1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
                yield return null;
            }

            // Aqui você pode adicionar lógica para o diálogo (por exemplo, exibir texto na tela)
            yield return new WaitForSeconds(10);  // Simulando a duração do diálogo

            // Após o diálogo, permita que o NPC volte a andar
            agent.isStopped = false;
            SetNpcState(NpcState.Break);  // Muda o estado de volta para "Break" ou qualquer outro
        }
    }

    public void SetNpcState(NpcState state)
    {
        npc = state;

        switch (state)
        {
            case NpcState.Break:
                StartCoroutine(GiveaBreak()); //coroutine para esperar
                OnBreak.Invoke();
                break;
            case NpcState.Walking:
                OnWalking.Invoke();
                break;
        }
    }
}
