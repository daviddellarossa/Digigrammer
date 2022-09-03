using Assets.Scripts.Digigram;
using Assets.Scripts.Masks;
using System;
using UnityEngine;

namespace Assets.Scripts.Agents
{
    interface IAgent
    {
        ComputeShader Shader { get; }

        void ExecuteShader(IDigigram digigram, IMask mask);
    }
}