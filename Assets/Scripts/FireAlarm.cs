using DG.Tweening;
using UnityEngine;

public class FireAlarm : MonoBehaviour
{

    [SerializeField]
    private AudioSource fireAlarm;
    [SerializeField]
    private BoxCollider fireExtinguisherCollider;

    [SerializeField]
    private DirectionHints directionHints;
    [SerializeField]
    private CollisionSwapper collisionSwapper;
    [SerializeField]
    private InstructionManual instructionManual;

    private bool canTriggerAlarm;

    private void Start()
    {
        canTriggerAlarm = false;
    }

	private void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.CompareTag("Player"))
		{
            if (!canTriggerAlarm)
			{
                transform.DOScale(new Vector3(0.1402964f, 0.1402964f, 0.009740924f), 0.5f).SetEase(Ease.Linear);

                if (!fireAlarm.isPlaying)
                    fireAlarm.Play();

                fireExtinguisherCollider.enabled = true;

                directionHints.UpdateDirectionHints(1);

                collisionSwapper.SwapCollisions();

                GetComponent<BoxCollider>().enabled = false;

                instructionManual.HideAllInstructions();
                instructionManual.ShowInstruction(2);

                canTriggerAlarm = true;
            }
		}
    }

}
