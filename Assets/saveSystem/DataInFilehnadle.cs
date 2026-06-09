using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataInFilehnadle 
{
   public string FileName="";
   public string FilePath="";
 
   public DataInFilehnadle(string FilePath,string FileName)
    {
         this.FilePath=FilePath;
        this.FileName=FileName;
       
    }
    public void SaveInFile(GameData data)
    {
        string fullpath=Path.Combine(FilePath,FileName);
      
        try
        {
        Directory.CreateDirectory(Path.GetDirectoryName(fullpath));
          string dataToStore=JsonUtility.ToJson(data,true);
   using (FileStream stream=new FileStream(fullpath,FileMode.Create))
            {
                using(StreamWriter writer=new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
            
        }
        catch(Exception e)
        {
            Debug.LogError("error on "+ fullpath+" !");
            
        }


    }
    public GameData Load()
    {
        GameData data=null;
        string fullpath=Path.Combine(FilePath,FileName);
        if(File.Exists(fullpath))
        {
               try
        {
            string datatoLoad="";
             using(FileStream stream=new FileStream(fullpath,FileMode.Open))
        {
            using(StreamReader reader=new StreamReader(stream))
            {
               
                              datatoLoad=reader.ReadToEnd();
               
            }
        }
        data=JsonUtility.FromJson<GameData>(datatoLoad);
        }
        catch(Exception e)
            {
                Debug.LogError("error is on Load"+fullpath);
            }
       
        }
        return data;
     

    }
}
