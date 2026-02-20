using UnityEngine;

[CreateAssetMenu(menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public AudioClip itemSound;
    public float itemValue;
}
