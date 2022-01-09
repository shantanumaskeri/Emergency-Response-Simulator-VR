using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UISpriteAtlas : MonoBehaviour
{

	[Header("Sprite Atlas References")]
	[SerializeField]
	private SpriteAtlas spriteAtlas;

	[Header("String References")]
	[SerializeField]
	private string spriteName;

	private Image image;

	private void Start()
    {
		image = GetComponent<Image>();

		image.sprite = spriteAtlas.GetSprite(spriteName);
		image.preserveAspect = true;
	}

}
