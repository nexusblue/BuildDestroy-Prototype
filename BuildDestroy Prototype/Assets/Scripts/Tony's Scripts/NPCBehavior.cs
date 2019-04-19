using UnityEngine;
using UnityEngine.AI;

public class NPCBehavior : MonoBehaviour
{
	public DialogueData dialogueData;

	GameObject npcCanvas;
	NavMeshAgent agent;

	bool dialogueChosen;

	Vector3 targetPosition;
	public float wanderRange;
	public float minWanderWaitTime;
	public float maxWanderWaitTime;
	float wanderWaitTimer;
	bool generatedTargetPosition;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}

	void Update()
	{
		if(npcCanvas == null)
		{
			npcCanvas = GameObject.FindGameObjectWithTag("NPCCanvas");
		}

		Wander();
	}

	void Wander()
	{
		if(!generatedTargetPosition)
		{
			targetPosition = GenerateRandomPosition(wanderRange);
		}

		wanderWaitTimer += Time.deltaTime;

		if(wanderWaitTimer >= Random.Range(minWanderWaitTime, maxWanderWaitTime))
		{
			agent.SetDestination(targetPosition);
			if(Vector3.Distance(agent.transform.position, targetPosition) <= 1f)
			{
				wanderWaitTimer = 0f;
				generatedTargetPosition = false;
			}
		}
	}

	void ResumeMoving()
	{
		if(agent != null)
		{
			agent.isStopped = false;
		}
	}

	void StopMoving()
	{
		if(agent != null)
		{
			agent.velocity = Vector3.zero;
			agent.isStopped = true;
		}
	}

	Vector3 GenerateRandomPosition(float range)
	{
		generatedTargetPosition = true;
		Vector3 randomDirection = Random.insideUnitCircle * range;
		randomDirection += agent.transform.position;
		NavMeshHit navHit;
		NavMesh.SamplePosition(randomDirection, out navHit, range, -1);
		return navHit.position;
	}

	void PlayAudio(AudioSource audioSource, AudioClip audioClip)
	{
		if(!audioSource.isPlaying)
		{
			audioSource.PlayOneShot(audioClip);
		}
	}

	void GetRandomDialogue()
	{
		npcCanvas.GetComponent<NPCCanvas>().dialogueText.text = dialogueData.dialogues[Random.Range(0, dialogueData.dialogues.Length)];
	}

	void OnTriggerStay(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(Input.GetKeyDown(KeyCode.F))
			{
				StopMoving();

				npcCanvas.GetComponent<NPCCanvas>().ToggleDialogue(true);

				if(!dialogueChosen)
				{
					GetRandomDialogue();
					dialogueChosen = true;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			ResumeMoving();
			npcCanvas.GetComponent<NPCCanvas>().ToggleDialogue(false);
			dialogueChosen = false;
		}
	}
}
