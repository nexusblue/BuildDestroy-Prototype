using UnityEngine;
using UnityEngine.UI;

public class NPCCanvas : MonoBehaviour
{
	public GameObject dialogueBox;
	public Text dialogueText;

	void Start()
	{
		ToggleDialogue(false);
	}

	public void ToggleDialogue(bool toggle)
	{
		dialogueBox.SetActive(toggle);
	}
}
