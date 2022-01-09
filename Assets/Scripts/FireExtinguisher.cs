using DG.Tweening;
using System.Collections;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
	 
	[SerializeField]
    private ParticleSystem pressurisedSteam;
    [SerializeField]
    private ParticleSystem gas;
	[SerializeField]
	private OVRGrabbable ovrGrabbable;
	[SerializeField]
	private DirectionHints directionHints;
	[SerializeField]
	private InstructionManual instructionManual;
	[SerializeField]
	private Transform squeezer;

	public AudioSource extinguisherSpray;

	[HideInInspector]
	public bool canSpraySmoke;

	private bool isSimulatedFirstTime;
	private bool isHintSwitched;
	private bool canPickUpExtinguisher;
	private Rigidbody rb;

	private void Awake()
	{
		canPickUpExtinguisher = isSimulatedFirstTime = isHintSwitched = canSpraySmoke = false;
		rb = GetComponent<Rigidbody>();

		StopParticles();
	}

	private void Update()
    {
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
		{
			if (canPickUpExtinguisher)
			{
				if (ovrGrabbable.isGrabbed)
				{
					if (canSpraySmoke)
					{
						rb.useGravity = true;

						SimulateSmoke();
					}
				}
			}
		}

		if (ovrGrabbable.isGrabbed)
		{
			if (!isHintSwitched)
			{
				instructionManual.HideAllInstructions();
				instructionManual.ShowInstruction(3);

				directionHints.UpdateDirectionHints(2);

				isHintSwitched = true;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			canPickUpExtinguisher = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
			canPickUpExtinguisher = false;
	}

	private void SimulateSmoke()
	{
		if (!pressurisedSteam.isPlaying)
		{
			squeezer.DOLocalRotate(new Vector3(-100f, 90f, -90f), 0.5f).SetEase(Ease.Linear);

			PlayParticles();

			if (!isSimulatedFirstTime)
			{
				StartCoroutine(CheckIntervalBeforeExiting());

				isSimulatedFirstTime = true;
			}
		}
		else
		{
			squeezer.DOLocalRotate(new Vector3(-90f, 0f, 0f), 0.5f).SetEase(Ease.Linear);

			StopParticles();
		}
	}

	private void StopParticles()
	{
		pressurisedSteam.Stop();
		gas.Stop();

		extinguisherSpray.Stop();
	}

	private void PlayParticles()
	{
		pressurisedSteam.Play();
		gas.Play();

		extinguisherSpray.Play();
	}

	private IEnumerator CheckIntervalBeforeExiting()
	{
		yield return new WaitForSeconds(10f);

		instructionManual.HideAllInstructions();
		instructionManual.ShowInstruction(5);

		directionHints.UpdateDirectionHints(3);
	}

}
