using UnityEngine;

using UnityEditor;

namespace Assets.Scripts.MessageBroker
{
	public partial class MessageBroker
	{
		private RequestMessage m_RequestMessage1;
		private RequestMessage m_RequestMessage2;
		void Start()
		{
			this.m_RequestMessage1 = AssetDatabase.LoadAssetAtPath<RequestMessage>("Assets/Prefabs/MessageBroker/RequestMessage1.asset");
			this.m_RequestMessage2 = AssetDatabase.LoadAssetAtPath<RequestMessage>("Assets/Prefabs/MessageBroker/RequestMessage2.asset");
		}
		public object Send_RequestMessage1(RequestMessagePayload payload)
		{
			return null;
		}
		public object Send_RequestMessage2(RequestMessagePayload payload)
		{
			return null;
		}
	}
}
