using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CK.ControlChannel.Abstractions
{
    /// <summary>
    /// Control message utility methods for special interactions with a <see cref="IControlChannelServer"/>.
    /// </summary>
    public sealed class ControlMessage
    {
        /// <summary>
        /// The encoding used when serializing and deserializing control messages.
        /// </summary>
        public static readonly Encoding ControlMessageEncoding = Encoding.UTF8;

        public static byte[] SerializeControlMessage( IReadOnlyDictionary<string, string> data )
        {
            using( MemoryStream ms = new MemoryStream() )
            {
                //using( GZipStream gz = new GZipStream( ms, CompressionLevel.Optimal, true ) )
                using( BinaryWriter bw = new BinaryWriter( ms, ControlMessageEncoding, true ) )
                {
                    bw.Write( Convert.ToUInt32( data.Count ) );
                    foreach( var kvp in data )
                    {
                        bw.Write( kvp.Key );
                        bw.Write( kvp.Value );
                    }
                }
                return ms.ToArray();
            }
        }

        /// <summary>
        /// Deserializes a control message.
        /// </summary>
        /// <param name="data">The data to decode</param>
        /// <returns>The control message's data dictionary</returns>
        public static IReadOnlyDictionary<string, string> DeserializeControlMessage( byte[] data )
        {
            using( MemoryStream ms = new MemoryStream( data ) )
            {
                //using( GZipStream gz = new GZipStream( ms, CompressionMode.Decompress, true ) )
                using( BinaryReader br = new BinaryReader( ms, ControlMessageEncoding, true ) )
                {
                    uint dataCount = br.ReadUInt32();
                    if( dataCount > 0 )
                    {
                        Dictionary<string, string> dict = new Dictionary<string, string>();
                        for( int i = 0; i < dataCount; i++ )
                        {
                            string key = br.ReadString();
                            string value = br.ReadString();
                            dict.Add( key, value );
                        }
                        return dict;
                    }
                    else
                    {
                        throw new InvalidOperationException( $"Expected a Count above zero, got {dataCount} instead" );
                    }
                }
            }
        }
    }
}
