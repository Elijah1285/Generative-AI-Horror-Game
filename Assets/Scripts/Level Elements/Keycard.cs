using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public enum KeycardType
    {
        Red,
        Green,
        Blue,
        Yellow
    }

    [SerializeField] KeycardType keycard_type;

    public KeycardType getKeycardType()
    {
        return keycard_type;
    }
}
