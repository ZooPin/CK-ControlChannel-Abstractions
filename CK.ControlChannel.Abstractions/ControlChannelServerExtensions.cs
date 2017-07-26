using CK.ControlChannel.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CK.ControlChannel
{
    public static class ControlChannelServerExtensions
    {
        /// <summary>
        /// Broadcasts data on a given channel to all connected and authenticated clients
        /// </summary>
        /// <param name="this">The <see cref="IControlChannelServer"/> to use</param>
        /// <param name="channelName">The name of the channel</param>
        /// <param name="data">The data to send</param>
        public static void Broadcast( this IControlChannelServer @this, string channelName, byte[] data )
        {
            if( @this == null ) { throw new ArgumentNullException( nameof( @this ) ); }
            if( channelName == null ) { throw new ArgumentNullException( nameof( channelName ) ); }

            foreach( IServerClientSession session in @this.ActiveSessions )
            {
                session.Send( channelName, data );
            }
        }
    }
}
