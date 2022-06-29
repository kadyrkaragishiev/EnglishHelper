using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    [CreateAssetMenu(fileName = "Quiz", menuName = "kadyrkaragishiev/Quiz", order = 1)]
    public class Quiz:ScriptableObject
    {
        public List<Question> questions;
    }
}
