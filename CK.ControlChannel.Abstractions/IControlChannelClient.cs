using CK.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CK.ControlChannel.Abstractions
{
    /// <summary>
    /// Delegate called when handling data received on a channel from the connected server
    /// </summary>
    /// <param name="monitor">A monitor created by this <see cref="IControlChannelClient"/> upon receiving data</param>
    /// <param name="data">Data received</param>
    public delegate void ClientChannelDataHandler( IActivityMonitor monitor, byte[] data );

    /// <summary>
    /// Client for IControlChannelServer implementations.
    /// </summary>
    public interface IControlChannelClient
    {
        /// <summary>
        /// Gets the server host bound to this <see cref="IControlChannelClient"/>
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Gets the server port bound to this <see cref="IControlChannelClient"/>
        /// </summary>
        int Port { get; }

        /// <summary>
        /// Returns true if connections with this <see cref="IControlChannelClient"/> are securely encrypted.
        /// </summary>
        bool IsSecure { get; }

        /// <summary>
        /// Returns true if this <see cref="IControlChannelClient"/> has established a connection with the server.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Registers a data handler for the given <paramref name="channelName"/>.
        /// </summary>
        /// <param name="channelName">Name of the channel</param>
        /// <param name="handler">Data handler</param>
        void RegisterChannelHandler( string channelName, ClientChannelDataHandler handler );

        /// <summary>
        /// Sends data to the connected server.
        /// </summary>
        /// <param name="channelName">Name of the channel</param>
        /// <param name="data">Data to send</param>
        Task SendAsync( string channelName, byte[] data );
    }
}
