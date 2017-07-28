using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace CK.ControlChannel.Abstractions.Tests
{
    public class ControlMessageTests
    {
        [Fact]
        public void control_messages_can_be_serialized()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["TestKey"] = "TestValue";

            byte[] serializedData = ControlMessage.SerializeControlMessage( data );

            serializedData.Should().NotBeNull();
            serializedData.Length.Should().BeGreaterThan( 0 );
        }

        [Fact]
        public void control_messages_can_be_deserialized_with_correct_data()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["TestKey"] = "TestValue";
            byte[] serializedData = ControlMessage.SerializeControlMessage( data );

            IReadOnlyDictionary<string, string> deserializedData = ControlMessage.DeserializeControlMessage( serializedData );

            deserializedData.Should().NotBeNullOrEmpty();
            deserializedData.Count.Should().Be( data.Count );
            deserializedData["TestKey"].Should().Be( "TestValue" );
        }

        [Fact]
        public void control_message_serialization_throws_with_illegal_count()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["TestKey"] = "TestValue";
            byte[] serializedData = ControlMessage.SerializeControlMessage( data );
            serializedData[0] = 0;
            serializedData[1] = 0;
            serializedData[2] = 0;
            serializedData[3] = 0;

            Action act = () => ControlMessage.DeserializeControlMessage( serializedData );

            act.ShouldThrow<InvalidOperationException>( "Invalid count" );
        }

        [Fact]
        public void control_message_serialization_throws_with_invalid_data()
        {
            byte[] serializedData = new byte[] { 1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 0, 1, 3, 4, 5, 7, 8, 9 };

            Action act = () => ControlMessage.DeserializeControlMessage( serializedData );

            act.ShouldThrow<EndOfStreamException>( "Invalid data" );
        }
    }
}
