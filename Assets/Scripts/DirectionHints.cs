using UnityEngine;

public class DirectionHints : MonoBehaviour
{

    public GameObject[] directions;
    
    private void Start()
    {
        UpdateDirectionHints(0);
    }

    public void UpdateDirectionHints(int id)
    {
        HideAllDirectionHints();
        ShowDirectionHint(id);
    }

    public void HideAllDirectionHints()
	{
        for (int i = 0; i < directions.Length; i++)
		{
            directions[i].SetActive(false);
		}
	}

    public void ShowDirectionHint(int id)
	{
        directions[id].SetActive(true);
    }

}
