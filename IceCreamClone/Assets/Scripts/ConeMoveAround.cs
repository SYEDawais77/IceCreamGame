using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class ConeMoveAround : MonoBehaviour
    {
        private ProgressBar _progressBar = new ProgressBar();
        public GameObject VanillaValve;
        public GameObject ChocolateValve;
        public GameObject IceCreamCone;
        
        public float Speed;
        public float Rotation;
        
        private void Start()
        {

        }
        private void Update()
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Debug.LogError("in began");
                var raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(raycast, out var raycastHit))
                {
                    if (raycastHit.collider.name == "VanillaIceCream")
                    {
                        Debug.LogError("vanilla IceCream  clicked");
                        if (VanillaValve.transform.rotation.x == 0f)
                        {
                            VanillaValve.transform.Rotate(-25f, 0f, 0f);
                        }
                    }

                    if (raycastHit.collider.name == "ChocolateIceCream")
                    {
                        Debug.LogError("Chocolate IceCream  clicked");
                        if (ChocolateValve.transform.rotation.x == 0f)
                        {
                            ChocolateValve.transform.Rotate(-25f, 0f, 0f);
                        }
                    }
                }
            }
            
            if ((Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Debug.LogError("in stat");

                var raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if (Physics.Raycast(raycast, out var raycastHit))
                {
                    if (raycastHit.collider.name == "VanillaIceCream" ||
                         raycastHit.collider.name == "ChocolateIceCream")
                    {
                        Rotation = Rotation + 250 * Time.deltaTime;
                        IceCreamCone.transform.rotation = Quaternion.Euler(0, Rotation, 0);
                        IceCreamCone.transform.Translate(Speed * Time.deltaTime, 0, 0);
                    }
                }
            }
            if ((Input.touchCount > 0) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                {
                    Debug.LogError("Touch ended");
                    VanillaValve.transform.rotation = Quaternion.identity;
                    ChocolateValve.transform.rotation = Quaternion.identity;
                }
            }
        }
    }
}
