using UnityEngine;
using System.Collections;

namespace Common.Corountines
{
    public class CoroutineRunService : ICoroutineRunService
    {
        private readonly CoroutineHolder _coroutineHolder;

        public CoroutineRunService()
        {
            GameObject holderObject  = new GameObject("CoroutineHolder");
            _coroutineHolder = holderObject.AddComponent<CoroutineHolder>();
            Object.DontDestroyOnLoad(holderObject);
        }
        
        public Coroutine StartCoroutine(IEnumerator routine) =>  _coroutineHolder.StartCoroutine(routine);
        
        public void StopCoroutine(Coroutine routine) =>  _coroutineHolder.StopCoroutine(routine);
    }
}