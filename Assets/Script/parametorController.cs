using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parametorController : MonoBehaviour
{
    [field: SerializeField] public float TotalScore { get; set; }
    [field: SerializeField] public int TotalAnimalNum { get; set; }

    [field: SerializeField] public bool NotFirst { get; set; } = false;

    [field: SerializeField] public bool IsSumaho { get; set; } = false;

}
