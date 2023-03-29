using UnityEngine;
using Data.ValueObjects;

namespace Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Input", menuName = "ProjectTexas/CD_Input", order = 0)]
    public class CD_Input : ScriptableObject
    {
        public InputData Data;
    }
}