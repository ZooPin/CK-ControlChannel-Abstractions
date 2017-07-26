using System;
using System.Linq;
using System.Collections.Generic;
using CK.Core;
using System.Text;

namespace CK.ControlChannel.Abstractions
{

    /// <summary>
    /// A session opened between the client and server
    /// </summary>
    public interface IServerClientSession
    {
        /// <summary>
        /// Session identifier, set by the server on successful authentication
        /// </summary>
        string SessionId { get; }

        /// <summary>
        /// Name given by the client when starting this session, for identification and display
        /// </summary>
        string ClientName { get; }

        /// <summary>
        /// Returns true if this session is still connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Returns true if this session was authenticated by the server, and can send and receive messages.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Send data to this client on the given channel.
        /// </summary>
        /// <param name="channel">Name of the channel</param>
        /// <param name="data">Data to send</param>
        void Send( string channel, byte[] data );

        /// <summary>
        /// Data provided by the client when authenticating
        /// </summary>
        IReadOnlyDictionary<string, string> ClientData { get; }
    }

}