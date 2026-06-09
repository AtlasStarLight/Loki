
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]

public class CraftThisMaterals
{
  public Itemdata materals;
public int materalsamout;
  
}
public enum Itemtype
{
    Hp,
    Force,
    Defensive,
    materal

}


[CreateAssetMenu(fileName ="ItemObject",menuName ="Item/Data")]
public class Itemdata : ScriptableObject
{
  public string ItemName;
  public Sprite Icon;
  public string Descreble;
  public float ItemChance;
  public Itemtype itemtype;
  public string ItemID;
public  List<CraftThisMaterals> ForCraftThis=new List<CraftThisMaterals>();
 

}
