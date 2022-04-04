using UnityEngine;


[CreateAssetMenu(menuName ="Data/Item")]
public class Pilot : ScriptableObject
{
    public Sprite icon;
    public int pilot_Number;

    public bool isHold;

    [Header("Status")]
    public string name;
    public float bulletPower;
    public int bulletnum;
    public float shotTime;
    [Header("BulletType")]
    public string bulletType;

}
