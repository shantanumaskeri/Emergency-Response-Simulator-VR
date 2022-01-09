using UnityEngine;

public class CollisionSwapper : MonoBehaviour
{

    [SerializeField]
    private SphereCollider firstCollider_LH;
    [SerializeField]
    private SphereCollider firstCollider_RH;
    [SerializeField]
    private BoxCollider secondCollider_LH;
    [SerializeField]
    private BoxCollider secondCollider_RH;

    private void Start()
    {
        firstCollider_LH.enabled = firstCollider_RH.enabled = false;
        secondCollider_LH.enabled = secondCollider_RH.enabled = true;
    }

    public void SwapCollisions()
    {
        firstCollider_LH.enabled = firstCollider_RH.enabled = true;
        secondCollider_LH.enabled = secondCollider_RH.enabled = false;
    }

}
