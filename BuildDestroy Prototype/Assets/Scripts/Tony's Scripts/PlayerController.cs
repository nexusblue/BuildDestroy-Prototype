using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public GameObject puff;
	public Transform puffSpawnPoint;

	public float maxPuffRadius;
	public float maxPuffSpeed;
	public float maxPuffMass;

	float chargeTimer;
	float chargeValue;

	public float gaugeSensitivity;

	void Update()
	{
		if(Input.GetKey(KeyCode.F))
		{
			ChargeTiming();
		}
		if(Input.GetKeyUp(KeyCode.F))
		{
			chargeTimer = 0f;

			puff.GetComponent<SphereCollider>().radius = chargeValue * maxPuffRadius;
			puff.GetComponent<Rigidbody>().mass = chargeValue * maxPuffMass;
			puff.GetComponent<Rigidbody>().velocity = Vector3.forward * chargeValue * maxPuffSpeed;

			Instantiate(puff, puffSpawnPoint.position, puffSpawnPoint.localRotation);
		}
	}

	void ChargeTiming()
	{
		chargeTimer += Time.deltaTime;
		chargeValue = ChargeFunction(chargeTimer);
	}

	public float ChargeFunction(float x)
	{
		return Mathf.Pow(Mathf.Sin(x * Mathf.PI), gaugeSensitivity);
	}
}
