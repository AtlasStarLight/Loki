using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CraftData : MonoBehaviour
{
    public static CraftData instance;
[SerializeField]public  List<Itemdata> craftingitmes;
[SerializeField] GameObject craftslotprefab;
[SerializeField] Transform parent;

public void Awake()
    {
       if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
    else
        {
        instance=this;
        }
          SetUpcrafttable();
    }
public void Start()
    {

    }
    public void SetUpcrafttable()
    {
        
        for(int i=0;i<craftingitmes.Count;i++)
        {
            GameObject obj=Instantiate(craftslotprefab,parent);
           obj.GetComponent<craftslot>().UpdateIcon(craftingitmes[i]);
           //这是爹，让预知体按照grid自动生成子类所以不需要儿子。
        }
    }
}
