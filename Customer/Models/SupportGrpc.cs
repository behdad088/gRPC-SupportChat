// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Support.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Support {
  public static partial class SupportService
  {
    static readonly string __ServiceName = "support.SupportService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Support.AddSupportEngineerRequest> __Marshaller_support_AddSupportEngineerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Support.AddSupportEngineerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Support.AddSupportEngineerResponse> __Marshaller_support_AddSupportEngineerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Support.AddSupportEngineerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Support.GetAvailableSupportEngineerRequest> __Marshaller_support_GetAvailableSupportEngineerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Support.GetAvailableSupportEngineerRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Support.GetAvailableSupportEngineerResponse> __Marshaller_support_GetAvailableSupportEngineerResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Support.GetAvailableSupportEngineerResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Support.SetSupportEngineerStatusToAvailableResponse> __Marshaller_support_SetSupportEngineerStatusToAvailableResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Support.SetSupportEngineerStatusToAvailableResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Support.AddSupportEngineerRequest, global::Support.AddSupportEngineerResponse> __Method_AddSupportEngineer = new grpc::Method<global::Support.AddSupportEngineerRequest, global::Support.AddSupportEngineerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddSupportEngineer",
        __Marshaller_support_AddSupportEngineerRequest,
        __Marshaller_support_AddSupportEngineerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Support.GetAvailableSupportEngineerRequest, global::Support.GetAvailableSupportEngineerResponse> __Method_GetAvailableSupportEngineer = new grpc::Method<global::Support.GetAvailableSupportEngineerRequest, global::Support.GetAvailableSupportEngineerResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAvailableSupportEngineer",
        __Marshaller_support_GetAvailableSupportEngineerRequest,
        __Marshaller_support_GetAvailableSupportEngineerResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Support.SetSupportEngineerStatusToAvailableResponse, global::Google.Protobuf.WellKnownTypes.Empty> __Method_SetSupportEngineerStatusToAvailable = new grpc::Method<global::Support.SetSupportEngineerStatusToAvailableResponse, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SetSupportEngineerStatusToAvailable",
        __Marshaller_support_SetSupportEngineerStatusToAvailableResponse,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Support.SupportReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SupportService</summary>
    [grpc::BindServiceMethod(typeof(SupportService), "BindService")]
    public abstract partial class SupportServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Support.AddSupportEngineerResponse> AddSupportEngineer(global::Support.AddSupportEngineerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Support.GetAvailableSupportEngineerResponse> GetAvailableSupportEngineer(global::Support.GetAvailableSupportEngineerRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> SetSupportEngineerStatusToAvailable(global::Support.SetSupportEngineerStatusToAvailableResponse request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for SupportService</summary>
    public partial class SupportServiceClient : grpc::ClientBase<SupportServiceClient>
    {
      /// <summary>Creates a new client for SupportService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SupportServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for SupportService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public SupportServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SupportServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected SupportServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Support.AddSupportEngineerResponse AddSupportEngineer(global::Support.AddSupportEngineerRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddSupportEngineer(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Support.AddSupportEngineerResponse AddSupportEngineer(global::Support.AddSupportEngineerRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddSupportEngineer, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Support.AddSupportEngineerResponse> AddSupportEngineerAsync(global::Support.AddSupportEngineerRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddSupportEngineerAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Support.AddSupportEngineerResponse> AddSupportEngineerAsync(global::Support.AddSupportEngineerRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddSupportEngineer, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Support.GetAvailableSupportEngineerResponse GetAvailableSupportEngineer(global::Support.GetAvailableSupportEngineerRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAvailableSupportEngineer(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Support.GetAvailableSupportEngineerResponse GetAvailableSupportEngineer(global::Support.GetAvailableSupportEngineerRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAvailableSupportEngineer, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Support.GetAvailableSupportEngineerResponse> GetAvailableSupportEngineerAsync(global::Support.GetAvailableSupportEngineerRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAvailableSupportEngineerAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Support.GetAvailableSupportEngineerResponse> GetAvailableSupportEngineerAsync(global::Support.GetAvailableSupportEngineerRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAvailableSupportEngineer, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty SetSupportEngineerStatusToAvailable(global::Support.SetSupportEngineerStatusToAvailableResponse request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetSupportEngineerStatusToAvailable(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty SetSupportEngineerStatusToAvailable(global::Support.SetSupportEngineerStatusToAvailableResponse request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SetSupportEngineerStatusToAvailable, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> SetSupportEngineerStatusToAvailableAsync(global::Support.SetSupportEngineerStatusToAvailableResponse request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetSupportEngineerStatusToAvailableAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> SetSupportEngineerStatusToAvailableAsync(global::Support.SetSupportEngineerStatusToAvailableResponse request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SetSupportEngineerStatusToAvailable, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override SupportServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new SupportServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(SupportServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddSupportEngineer, serviceImpl.AddSupportEngineer)
          .AddMethod(__Method_GetAvailableSupportEngineer, serviceImpl.GetAvailableSupportEngineer)
          .AddMethod(__Method_SetSupportEngineerStatusToAvailable, serviceImpl.SetSupportEngineerStatusToAvailable).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SupportServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddSupportEngineer, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Support.AddSupportEngineerRequest, global::Support.AddSupportEngineerResponse>(serviceImpl.AddSupportEngineer));
      serviceBinder.AddMethod(__Method_GetAvailableSupportEngineer, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Support.GetAvailableSupportEngineerRequest, global::Support.GetAvailableSupportEngineerResponse>(serviceImpl.GetAvailableSupportEngineer));
      serviceBinder.AddMethod(__Method_SetSupportEngineerStatusToAvailable, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Support.SetSupportEngineerStatusToAvailableResponse, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.SetSupportEngineerStatusToAvailable));
    }

  }
}
#endregion
