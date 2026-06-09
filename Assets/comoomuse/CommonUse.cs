using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonUse : MonoBehaviour
{
    [Header("check wall and ground")]
    public  bool isWall;
    public   bool isGround;
    [SerializeField] protected LayerMask WallANDGround;
     
     [Header(" Drawing Wall and ground  and attack sphere")]
     [SerializeField] protected  float wallANDgroundDistance;
     [SerializeField] protected  Transform Wall;
     [SerializeField] protected Transform Ground;
     [SerializeField] public Transform attackCircle;
     [SerializeField]  public float CircleRadius;
    [Header("flip")]
    public bool faceRight;
    public int facedir=1;
   public float Xinput;
    public float speed;
        public virtual void CharacterFlip()
    {
        if(Xinput>0&&!faceRight||Xinput<0&&faceRight)
        {
            Flip();
            facedir=facedir*(-1);
        }
    

    }
    public virtual void Update()
    {
        
        isWall=Physics2D.Raycast(Wall.position,Vector2.right*facedir,wallANDgroundDistance,WallANDGround);
        isGround=Physics2D.Raycast(Ground.position,Vector2.down,wallANDgroundDistance,WallANDGround);
       
    }
    public virtual void Flip()
    {
        this.transform.Rotate(0,180,0);
        faceRight=!faceRight;
    }

  public  virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(Wall.position,new Vector3(Wall.position.x+wallANDgroundDistance*facedir,Wall.position.y));
        Gizmos.DrawLine(Ground.position,new Vector3(Ground.position.x,Ground.position.y+wallANDgroundDistance*-1));
        Gizmos.DrawWireSphere(attackCircle.position,CircleRadius);
        
    }
    public virtual void HavingDamge()
    {
        
    }
}
