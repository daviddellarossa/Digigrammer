//------------------------------------------------------------------------------
// <auto-generated>
// Code auto-generated by MessageBrokerGenerator
// Re-run the generator every time a new Message is added or removed.
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using UnityEngine;

namespace InFlammis.MessageBroker
{
	/// <summary>
	/// Message Broker component exposing methods to send messages defined as ScriptableObjects of type <see cref="Message"/>.
	/// </summary>
	[AddComponentMenu("InFlammis/Message Broker/Message Broker")]
	sealed partial class MessageBroker : MonoBehaviour, IMessageBroker
	{
		/// <inheritdoc/>
		public MBApp App { get; } = new MBApp();

		/// <inheritdoc/>
		public MBRender Render { get; } = new MBRender();

	}
}