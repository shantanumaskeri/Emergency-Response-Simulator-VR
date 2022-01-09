using UnityEngine;

public class InteractionTriggers : MonoBehaviour
{

	[SerializeField]
	private AudioSource fireAlarm;
	[SerializeField]
	private DirectionHints directionHints;
	[SerializeField]
	private FireExtinguisher fireExtinguisher;
	[SerializeField]
	private InstructionManual instructionManual;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Prop") && gameObject.CompareTag("Prop Trigger"))
		{
			directionHints.HideAllDirectionHints();

			gameObject.GetComponent<BoxCollider>().enabled = false;

			instructionManual.HideAllInstructions();
			instructionManual.ShowInstruction(4);

			fireExtinguisher.canSpraySmoke = true;
		}

		if (other.CompareTag("Player") && gameObject.CompareTag("AP Trigger"))
		{
			directionHints.HideAllDirectionHints();

			instructionManual.HideAllInstructions();
			instructionManual.ShowInstruction(6);

			gameObject.GetComponent<BoxCollider>().enabled = false;
		}

		if (other.CompareTag("Player") && gameObject.CompareTag("Switch Trigger"))
		{
			instructionManual.HideAllInstructions();
			instructionManual.ShowInstruction(1);

			gameObject.GetComponent<BoxCollider>().enabled = false;
		}

		if (other.CompareTag("Player") && gameObject.CompareTag("Scanner Trigger"))
		{
			instructionManual.HideAllInstructions();

			fireAlarm.Stop();

			gameObject.GetComponent<BoxCollider>().enabled = false;
		}
	}

}
