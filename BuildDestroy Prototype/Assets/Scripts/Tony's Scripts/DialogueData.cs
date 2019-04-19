using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Data/DialogueData", order = 1)]
public class DialogueData : ScriptableObject
{
	[TextArea] public string[] dialogues;
}
