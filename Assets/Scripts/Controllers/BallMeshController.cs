using Data.ValueObject;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class BallMeshController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private BallManager manager;
        [SerializeField] private new Renderer renderer;

        private const string CupEntryTag = "CupEntry";
        private ColorData _colorData;

        #endregion

        public void SetRandomMatColor()
        {
            var randomIndex = Random.Range(0, _colorData.Colors.Count-1);
            renderer.material.color = _colorData.Colors[randomIndex];
            manager.SendCurrentColorDataToControllers(_colorData.Colors[randomIndex]);
        }

        public void SetColorData(ColorData colorData)
        {
            _colorData = colorData;
        }

        public void ChangeBallColor(Color newColor)
        {
            renderer.material.color = newColor;
        }
    }
}