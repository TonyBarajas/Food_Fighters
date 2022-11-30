using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem //la hacemos static para uqe no se instancie
{
    //SAVE
    public static void SavePlayer ( ScoreManager puntuacion)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saves/";
        Directory.CreateDirectory(path);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        Player_Data dataPoints = new Player_Data(puntuacion);
        //Player_Data dataPosition = new Player_Data(positionplayer);
       // Player_Data dataPlayer = new Player_Data(chiphealth);
        //Player_Data dataHealth = new Player_Data(health);

        try
        {
            formatter.Serialize(fileStream, dataPoints);
           // formatter.Serialize(fileStream, dataPosition);
           // formatter.Serialize(fileStream, dataPlayer);
           // formatter.Serialize(fileStream, dataHealth);
        }
        catch (SerializationException exception)
        {
            Debug.Log("Save failed. Error: " + exception.Message);
        }
        finally
        {
            fileStream.Close();
        }
    }

    //LOAD
    public static Player_Data LoadPlayer( )
    {
        string path = Application.persistentDataPath + "/saves/";
        if (File.Exists(path))
        {

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            Player_Data dataPoints = formatter.Deserialize(fileStream) as Player_Data;
           // Player_Data dataPosition = formatter.Deserialize(fileStream) as Player_Data;
            //Player_Data dataPlayer = formatter.Deserialize(fileStream) as Player_Data;
            //Player_Data dataHealth = formatter.Deserialize(fileStream) as Player_Data;

            fileStream.Close();

            return dataPoints;
            //try
            //{
            //  Player_Data data =  formatter.Deserialize(fileStream);
            //}
            //catch (SerializationException exception)
            //{
            //    Debug.Log("Load failed. Error: " + exception.Message);
            //}
            //finally
            //{
            //   fileStream.Close();
            //}
            //return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path + " ayayay dios mio D:");
            return null;
        }
    }
    
}
