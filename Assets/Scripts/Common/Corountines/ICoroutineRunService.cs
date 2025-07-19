using System.Collections;
using UnityEngine;

namespace Common.Corountines
{
    public interface ICoroutineRunService
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
    }
}