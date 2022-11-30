using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]// significa que lo podremos guardar en una file
public class Player_Data 
{
    public int Puntos;
    public int Player_Health;
    public int Stolen_Fruit;
    public float[] Playposition;

    //los constructores son como un setup
    public Player_Data (Health health) //POrcentage de fruta robado
    {
        Stolen_Fruit = health._currentHealth;
    }

    public Player_Data(Chip_Health chiphealth)
    {
        Player_Health = chiphealth._currentHealth;
    }

    public Player_Data (Player_controller_2 positionplayer)
    {
        Playposition = new float[3]; // no podemos guardar directamente el transform, por eso debemos hacer un array con una linea para cada cordenada
        Playposition[0] = positionplayer.transform.position.x;
        Playposition[1] = positionplayer.transform.position.y;
        Playposition[2] = positionplayer.transform.position.z;
    }

    public Player_Data (ScoreManager puntuacion)
    {
        Puntos = puntuacion._score;
    }



}
