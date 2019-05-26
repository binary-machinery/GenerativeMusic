using UnityEngine;
using MusicAlgebra;

public class PitchComp : MonoBehaviour
{
    public Pitch pitch { get { return _pitch; } }

    [SerializeField]
    private Pitch _pitch;
}
