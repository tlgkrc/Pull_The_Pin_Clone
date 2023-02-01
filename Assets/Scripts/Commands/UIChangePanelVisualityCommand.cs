using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Commands
{
    public class UIChangePanelVisualityCommand 
    {
        #region Self Variables

        #region Private Variables

        private readonly List<GameObject> _panels;

        #endregion

        #endregion
        public UIChangePanelVisualityCommand(ref List<GameObject> panels)
        {
            _panels = panels;
        }
        
        public void Execute(UIPanels panelParam,bool isOpen)
        {
           _panels[(int) panelParam].SetActive(isOpen);
        }
    }
}