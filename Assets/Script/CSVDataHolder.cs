using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActHolder", menuName = "ActHolder")]
public class CSVDataHolder : ScriptableObject
{
    [System.Serializable]
    public class Actes
    {
        public int ID;
        public string NAME;
        public int GRAVITY;
    }

    public Actes[] m_Actes;
}
