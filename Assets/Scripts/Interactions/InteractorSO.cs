using Assets.Scripts.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interactions
{
    [CreateAssetMenu(menuName = "Digigrammer/Interactor", fileName = "New Interactor")]

    class InteractorSO : ScriptableObject , IInteractor
    {
        [SerializeField] private List<AgentSO> inAgents;
        [SerializeField] private List<AgentSO> outAgents;
        [SerializeField] private ComputeShader shader;

        public ComputeShader Shader => shader;

        public List<AgentSO> InAgents => inAgents;

        public List<AgentSO> OutAgents => outAgents;

        public void Interact()
        {
            throw new NotImplementedException();
        }

        public int GetId()
        {
            int id = 0;
            InAgents.ForEach(x => id ^= x.GetInstanceID());
            return id;
        }
    }
}
