using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [ExecuteInEditMode()]
    public class ProgressBar : MonoBehaviour
    {
        public int Maximum;
        [SerializeField]public int Current;
        public Image Mask;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        GetCurrentFilled();
        }

        void GetCurrentFilled()
        {
            float fillAmount = (float) Current / (float) Maximum;
            Mask.fillAmount = fillAmount;
        }
    }
}
