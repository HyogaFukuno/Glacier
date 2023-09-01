using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Glacier.Samples
{
    public class Error : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            StartCoroutine(DoError());
        }

        private IEnumerator DoError()
        {
            yield return new WaitForSeconds(1.0f);

            throw new System.Exception();
        }
    }
}