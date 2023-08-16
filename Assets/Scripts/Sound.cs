using UnityEngine;

[System.Serializable] //Contenedor que va a manejar nuestros sonidos

public class Sound
{
    [SerializeField]
    public string name;

    [SerializeField]
    public AudioClip sound;


}
