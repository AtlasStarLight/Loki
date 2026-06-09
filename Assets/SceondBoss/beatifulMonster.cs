using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class beatifulMonster : MonoBehaviour
{
   public static beatifulMonster instance;
   [SerializeField] float Attackwindowradius;
   [SerializeField] Transform playerfind;
   [SerializeField] LayerMask isthisplayer;
   Animator am=>GetComponentInChildren<Animator>();

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
    }
    public void Start()
    {
        this.gameObject.SetActive(false);
    }
   
    public void ShowTime()
    {
      
    Collider2D player=Physics2D.OverlapCircle(this.transform.position,Attackwindowradius,isthisplayer);
        if(player!=null)
        {
          StartCoroutine(Superise());
          
        }
        if(Player.instance.dieState.isDie)
        {
               Die();
        }
     
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(playerfind.position,Attackwindowradius);
    }
    public void Die()
    {
        this.gameObject.SetActive(false);
    }
    IEnumerator Superise()
    {
    am.enabled=false;
    yield return new WaitForSeconds(3f);
    am.enabled=true;
    
    }
    public void Update()
    {
        ShowTime();
    }
}
