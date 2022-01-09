using UnityEngine;

public class InstructionManual : MonoBehaviour
{

    [SerializeField]
    private GameObject[] instructionSet;
    
    private void Start()
    {
        HideAllInstructions();
        ShowInstruction(0);
    }

    public void HideAllInstructions()
	{
        for (int i = 0; i < instructionSet.Length; i++)
		{
            instructionSet[i].SetActive(false);
		}
	}

    public void ShowInstruction(int id)
	{
        instructionSet[id].SetActive(true);
	}

}
