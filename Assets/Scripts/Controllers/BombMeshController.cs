using DG.Tweening;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class BombMeshController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private Color color;
        [SerializeField] private new Renderer renderer;
        [SerializeField] private BombManager manager;

        #endregion

        public void ChangeMeshColor()
        {
            renderer.material.DOColor(color, 1f).OnComplete(()=> manager.gameObject.SetActive(false) );
        }
    }
}