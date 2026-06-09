using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SaveMager : MonoBehaviour
{
    public static SaveMager instance;
  public  GameData gameData;
    [SerializeField] string filename;
    private DataInFilehnadle dataInFilehnadle;
    private List<Isave> Isaves;
    public void Awake()
    {
    if(instance!=null&&instance!=this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance=this;
             DontDestroyOnLoad(gameObject);
        }
         dataInFilehnadle=new DataInFilehnadle(Application.persistentDataPath,filename);
         Debug.Log(Application.persistentDataPath);
      
    }
    public void Start()
    {
       
        Isaves=FindAllData();
       LoadGame();

    }
    public void EveryLevel()
    {
        Isaves=FindAllData();
       LoadGame();

    }
    public void NewGame()

    {gameData=new GameData();
    } 
       public void LoadGame()
    {
       gameData= dataInFilehnadle.Load();

        if(gameData==null)
        {
         NewGame();
       
        }
        foreach(var data in Isaves)
        {
            data.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        foreach(var data in Isaves)
        {
            data.SaveData( ref gameData);
        }
        dataInFilehnadle.SaveInFile(gameData);
        
    }
private void OnApplicationQuit()
    {
        SaveGame();
    }
private List<Isave> FindAllData()
    {
        IEnumerable<Isave> alldatas=FindObjectsOfType<MonoBehaviour>().OfType<Isave>();
        return new  List<Isave>(alldatas);

}
public void ResetGame()
{
    gameData = new GameData();

    dataInFilehnadle.SaveInFile(gameData);
     Isaves=FindAllData();
       LoadGame();
}

}
