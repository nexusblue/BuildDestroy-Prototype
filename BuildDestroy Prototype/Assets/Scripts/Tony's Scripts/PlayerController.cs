using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public GameObject puffPrefab;
	GameObject puffInstance;
	public Transform puffSpawnPoint;

	public Slider puffGauge;
	public Text puffText;

	public float maxPuffRadius;
	public float maxPuffSpeed;
	public float maxPuffMass;

	float chargeTimer;
	float chargeValue;
	public float chargeSpeed;

	void Start()
	{
		puffGauge.gameObject.SetActive(false);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.F))
		{
			ChargeTiming();
			puffGauge.gameObject.SetActive(true);
			puffText.gameObject.SetActive(false);
		}
		if(Input.GetKeyUp(KeyCode.F))
		{
			chargeTimer = 0f;

			puffInstance = Instantiate(puffPrefab, puffSpawnPoint.position, puffSpawnPoint.localRotation);

			puffInstance.GetComponent<SphereCollider>().radius = chargeValue * maxPuffRadius;
			puffInstance.GetComponent<Rigidbody>().mass = chargeValue * maxPuffMass;
			puffInstance.GetComponent<Rigidbody>().velocity = puffSpawnPoint.transform.forward * chargeValue * maxPuffSpeed;
		}
	}

	void ChargeTiming()
	{
		chargeTimer += Time.deltaTime;
		chargeValue = ChargeFunction(chargeTimer * chargeSpeed);
		puffGauge.value = chargeValue;
	}

	public float ChargeFunction(float x)
	{
		return Mathf.PingPong(x, 1);
	}
}
