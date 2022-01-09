using UnityEngine;
using UnityEngine.UI;

public class DistanceChecker : MonoBehaviour
{

    [SerializeField]
    private Transform firstObject;
    [SerializeField]
    private Transform secondObject;
    [SerializeField]
    private Image vignetteEffect;

    private float distance;
    private float alpha;

    private void Update()
    {
        distance = Vector3.Distance(firstObject.position, secondObject.position);
        if (distance < 1f)
            distance = 1f;

        alpha = 1f / distance;
        vignetteEffect.color = new Color(vignetteEffect.color.r, vignetteEffect.color.g, vignetteEffect.color.b, alpha);
    }

}
