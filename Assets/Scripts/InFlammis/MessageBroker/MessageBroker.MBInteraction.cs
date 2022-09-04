//------------------------------------------------------------------------------
// <auto-generated>
// Code auto-generated by MessageBrokerGenerator version 1.0.0-alpha.1.
// Re-run the generator every time a new Message is added or removed.
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using UnityEngine;
using UnityEditor;

namespace InFlammis.MessageBroker
{
	/// <summary>
	/// MessageBroker publisher for Interaction category.
	/// </summary>
	class MBInteraction
	{
		#region Event declaration

		/// <summary>
		/// Message to request an AgentBuffer, by Agent ID
		/// </summary>
		public event Func<object, object, int, Assets.Scripts.Agents.AgentBuffer> RequestForAgentBuffer;

		/// <summary>
		/// Message to request all AgentBuffers by agentId
		/// </summary>
		public event Func<object, object, int[], System.Collections.Generic.Dictionary<int, Assets.Scripts.Agents.AgentBuffer>> RequestForMultiAgentBuffers;


		#endregion

		#region Send methods

		/// <summary>
		/// Send a message of type RequestForAgentBuffer.
		/// <param name="sender">The sender of the message. Required.</param>
		/// <param name="target">The target of the message. Optional.</param>
		/// <param name="agentId">The id of the request AgentBuffer's agent.</param>
		/// <returns>Return the AgentBuffer requested</returns>
		/// </summary>
		public Assets.Scripts.Agents.AgentBuffer Send_RequestForAgentBuffer(object sender, object target, int agentId)
		{
			if (sender == null)
			{
				Debug.LogError("sender is required.");
				return default;
			}

			return RequestForAgentBuffer?.Invoke(sender, target, agentId);
		}

		/// <summary>
		/// Send a message of type RequestForMultiAgentBuffers.
		/// <param name="sender">The sender of the message. Required.</param>
		/// <param name="target">The target of the message. Optional.</param>
		/// <param name="agentIds">Array of the agents' Ids to retrieve</param>
		/// <returns>Dictionary of the requested AgentBuffers</returns>
		/// </summary>
		public System.Collections.Generic.Dictionary<int, Assets.Scripts.Agents.AgentBuffer> Send_RequestForMultiAgentBuffers(object sender, object target, int[] agentIds)
		{
			if (sender == null)
			{
				Debug.LogError("sender is required.");
				return default;
			}

			return RequestForMultiAgentBuffers?.Invoke(sender, target, agentIds);
		}


		#endregion

	}
}
