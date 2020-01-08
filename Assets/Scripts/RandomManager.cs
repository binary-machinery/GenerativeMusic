using UnityEngine;

public class RandomManager : MonoBehaviour
{
    [SerializeField]
    private bool _useFixedSeed = false;
    
    [SerializeField]
    private int _fixedSeed = 423;

    private void Awake()
    {
        int seed = _useFixedSeed ? _fixedSeed : Random.Range(0, int.MaxValue);
        Random.InitState(seed);
    }
}