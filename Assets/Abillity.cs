using UnityEngine;


[CreateAssetMenu(menuName ="Data/Abillity/Abillity")]
public class Abillity : ScriptableObject
{
    public Sprite sprite;
    public AbillityFunction function;
    public int level;

}
