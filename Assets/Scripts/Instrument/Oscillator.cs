using System;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    private enum WaveForm
    {
        Sine,
        Square,
        Triangle,
    }

    private const float SAMPLING_FREQUENCY = 48000.0f;
    private const float MASTER_GAIN = 0.5f;

    private static readonly Dictionary<WaveForm, Func<float, float>> WAVE_FORM_GENERATORS = new Dictionary<WaveForm, Func<float, float>>
    {
        { WaveForm.Sine, GetSineSample },
        { WaveForm.Square, GetSquareSample },
        { WaveForm.Triangle, GetTriangleSample },
    };

    [SerializeField]
    private WaveForm _waveForm;

    [SerializeField]
    private float _frequency = 440f;

    [SerializeField]
    [Range(0f, 1f)]
    private float _gain = 0.5f;

    public float frequency
    {
        get => _frequency;
        set => _frequency = value;
    }

    public float gain
    {
        get => _gain;
        set => _gain = value;
    }

    private float _increment;
    private float _phase;

    private void OnAudioFilterRead(float[] data, int channels)
    {
        float increment = _frequency * 2f * Mathf.PI / SAMPLING_FREQUENCY;
        for (int i = 0; i < data.Length; i += channels)
        {
            _phase += increment;
            data[i] = _gain * MASTER_GAIN * WAVE_FORM_GENERATORS[_waveForm](_phase);

            for (int channel = 1; channel < channels; ++channel)
            {
                data[i + channel] = data[i];
            }

            if (_phase > Mathf.PI * 2f)
            {
                _phase = 0f;
            }
        }
    }

    private static float GetSineSample(float phase)
    {
        return Mathf.Sin(phase);
    }

    private static float GetSquareSample(float phase)
    {
        return Mathf.Sign(Mathf.Sin(phase)) * 0.5f;
    }

    private static float GetTriangleSample(float phase)
    {
        return Mathf.PingPong(phase, 2f);
    }
}