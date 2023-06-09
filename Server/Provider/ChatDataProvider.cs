﻿using Chat;
using grpc.server.Abstract;
using Grpc.Core;

namespace grpc.server.Provider
{
    internal class ChatDataProvider : IChatDataProvider
    {
        private ISet<UserInfo> _userInfo;
        private readonly Dictionary<string, IServerStreamWriter<ChatMessageResponse>> _streamDic;

        public ChatDataProvider()
        {
            _userInfo = new HashSet<UserInfo>();
            _streamDic = new Dictionary<string, IServerStreamWriter<ChatMessageResponse>>();
        }

        public void SaveUserInfo(string userId, IServerStreamWriter<ChatMessageResponse> CustomerResponseStream)
        {
            if (!_userInfo.Any(x => x.UserId == userId))
            {
                _userInfo.Add(new UserInfo
                {
                    UserId = userId,
                    Stream = CustomerResponseStream
                });
            }
            else
            {
                var channel = _userInfo.FirstOrDefault(x => x.UserId == userId);
                if (channel == null)
                    throw new RpcException(new Status(StatusCode.Internal, "Something went wrong while trying to connect to the channel"));

                channel.Stream = CustomerResponseStream;
            }
        }

        public async void SendAsync(string senderId, string message, string senderName)
        {
            if (_streamDic.TryGetValue(senderId, out var stream))
            {
                await stream.WriteAsync(new ChatMessageResponse
                {
                    ChatMessage = new ChatMessage
                    {
                        Message = message,
                        SenderName = senderName,
                        SenderId = senderId
                    }
                });
            }
            else
            {
                throw new RpcException(new Status(StatusCode.Internal, "Could not find user."));
            }
        }

        public void ConnetUserToReceiverStream(string customerId, string supportId)
        {
            var customer = _userInfo.FirstOrDefault(x => x.UserId == customerId);
            var support = _userInfo.FirstOrDefault(x => x.UserId == supportId);

            if (customer == null)
                throw new RpcException(new Status(StatusCode.Internal, $"Something went wrong while trying to connect to the customer {customerId} stream"));

            if (support == null)
                throw new RpcException(new Status(StatusCode.Internal, $"Something went wrong while trying to connect to the suppport {supportId} stream"));

            _streamDic.Add(support.UserId, customer.Stream);
            _streamDic.Add(customer.UserId, support.Stream);
        }

        public void DisconnetUserToReceiverStream(string customerId, string supportId)
        {
            var customer = _userInfo.FirstOrDefault(x => x.UserId == customerId);
            var support = _userInfo.FirstOrDefault(x => x.UserId == supportId);

            if (customer != null)
                _streamDic.Remove(customer.UserId);

            if (support != null)
                _streamDic.Remove(support.UserId);
        }
    }

    public class UserInfo
    {
        public string UserId { get; set; }
        public IServerStreamWriter<ChatMessageResponse> Stream { get; set; }

    }
}
