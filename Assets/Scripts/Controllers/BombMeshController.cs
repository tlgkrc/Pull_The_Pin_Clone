using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class BombMeshController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private new Renderer renderer;
        [SerializeField] private BombManager manager;
        
        private const int ColorGValue = 80;

        #endregion

        public void ChangeMeshColor()
        {
            var material = renderer.material;
            material.DOColor(new Color(material.color.a, ColorGValue, material.color.b), 3f);
        }
    }
}