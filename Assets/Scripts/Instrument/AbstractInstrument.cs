using UnityEngine;
using MusicAlgebra;

public abstract class AbstractInstrument : MonoBehaviour
{
    public abstract AbstractSoundController PlayNote(Pitch pitch, float volume, int durationTimeQuanta);
}
