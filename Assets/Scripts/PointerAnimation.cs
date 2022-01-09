using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PointerAnimation : MonoBehaviour
{

    private Image image;
    
    /*[SerializeField]
    private Vector3 initialPosition;
    [SerializeField]
    private Vector3 finalPosition;*/

    private void Start()
	{
        image = GetComponent<Image>();

        InvokeRepeating(nameof(AnimatePointer), 0.0f, 1.0f);
    }

    private void AnimatePointer()
    {
		if (image.color.a == 1.0f)
            image.DOFade(0.0f, 1.0f).SetEase(Ease.Linear);
		else if (image.color.a == 0.0f)
            image.DOFade(1.0f, 1.0f).SetEase(Ease.Linear);

		/*if (arrowIndicatorImg.transform.localPosition == initialPosition)
            arrowIndicatorImg.transform.DOLocalMove(finalPosition, 0.5f).SetEase(Ease.Linear);
        else if (arrowIndicatorImg.transform.localPosition == finalPosition)
            arrowIndicatorImg.transform.DOLocalMove(initialPosition, 0.5f).SetEase(Ease.Linear);*/
	}

    public void Terminate()
	{
        CancelInvoke(nameof(AnimatePointer));
	}

}
