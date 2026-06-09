using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
    public int money;
    public float fistBosscurrentHP;
    public SeralizeableList<string ,int>inventory;
   public List<Itemtype> equitment;
   public bool fistbossisdie;
   public bool secondBossHP;
   public bool thirdBosshasover;
   public int fourtBossHP;
   public bool forthHasover;
   public bool fifthisover;
   public int sixth;
   public int playerHP;
public bool potionpick;
  

   public GameData()
    {
      money=10000;
        inventory=new SeralizeableList<string, int>();
equitment=new List<Itemtype>();
fistBosscurrentHP=100;
fistbossisdie=false;
secondBossHP=true;
thirdBosshasover=false;
fourtBossHP=1000;
forthHasover=false;
fifthisover=false;
sixth=20000;

playerHP=1000;
potionpick=false;


    }
}
