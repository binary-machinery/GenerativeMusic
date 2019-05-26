using UnityEngine;
using MusicAlgebra;

public abstract class AbstractInstrument : MonoBehaviour
{
    public abstract void PlayNote(Pitch pitch, float volume);
}
