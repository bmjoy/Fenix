﻿
//AUTOGEN, do not modify it!

using Fenix;
using Fenix.Common;
using Fenix.Common.Attributes;
using Fenix.Common.Utils;
using Fenix.Common.Message;


using Shared;
using Shared.DataModel;
using Shared.Protocol; 
using Shared.Message;
                    
//using MessagePack;
using System;
using System.Threading.Tasks;

namespace Server
{

    [RefType("LoginService")]
    public partial class LoginServiceRef : ActorRef
    {
        public async Task<CreateAccountReq.Callback> rpc_create_accountAsync(String username, String password, Action<ErrCode> callback=null)
        {
            var t = new TaskCompletionSource<CreateAccountReq.Callback>();
            Action<CreateAccountReq.Callback> _cb = (cbMsg) =>
            {
                t.TrySetResult(cbMsg);
                callback?.Invoke(cbMsg.code);
            };
            var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId, this.isClient);
            if (this.FromHostId == toHostId)
            {
                var protoCode = ProtocolCode.CREATE_ACCOUNT_REQ;
                if (protoCode < OpCode.CALL_ACTOR_METHOD)
                {
                    var peer = Global.NetManager.GetPeerById(this.FromHostId, this.NetType);
                    var context = new RpcContext(null, peer);
                    Global.Host.CallMethodWithParams(protoCode, new object[] { username, password, _cb, context });
                }
                else
                    Global.Host.GetActor(this.toActorId).CallMethodWithParams(protoCode, new object[] { username, password, _cb });
            }
            else
            {
                var msg = new CreateAccountReq()
                {
                username=username,
                password=password
                };
                var cb = new Action<byte[]>((cbData) => {
                    var cbMsg = cbData==null ? new CreateAccountReq.Callback() : RpcUtil.Deserialize<CreateAccountReq.Callback>(cbData);
                    _cb?.Invoke(cbMsg);
                });
                this.CallRemoteMethod(ProtocolCode.CREATE_ACCOUNT_REQ, msg, cb);
             }
             return await t.Task;
        }

        public void rpc_create_account(String username, String password, Action<ErrCode> callback)
        {
            var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId, this.isClient);
            if (this.FromHostId == toHostId)
            {
                var protoCode = ProtocolCode.CREATE_ACCOUNT_REQ;
                if (protoCode < OpCode.CALL_ACTOR_METHOD)
                {
                    var peer = Global.NetManager.GetPeerById(this.FromHostId, this.NetType);
                    var context = new RpcContext(null, peer);
                    Global.Host.CallMethodWithParams(protoCode, new object[] { username, password, callback, context });
                }
                else
                    Global.Host.GetActor(this.toActorId).CallMethodWithParams(protoCode, new object[] { username, password, callback });
                return;
            }
            var msg = new CreateAccountReq()
            {
                username=username,
                password=password
            };
            var cb = new Action<byte[]>((cbData) => {
                var cbMsg = cbData==null?new CreateAccountReq.Callback():RpcUtil.Deserialize<CreateAccountReq.Callback>(cbData);
                callback?.Invoke(cbMsg.code);
            });
            this.CallRemoteMethod(ProtocolCode.CREATE_ACCOUNT_REQ, msg, cb);
        }

        public async Task<DeleteAccountReq.Callback> rpc_delete_accountAsync(String username, String password, Action<ErrCode> callback=null)
        {
            var t = new TaskCompletionSource<DeleteAccountReq.Callback>();
            Action<DeleteAccountReq.Callback> _cb = (cbMsg) =>
            {
                t.TrySetResult(cbMsg);
                callback?.Invoke(cbMsg.code);
            };
            var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId, this.isClient);
            if (this.FromHostId == toHostId)
            {
                var protoCode = ProtocolCode.DELETE_ACCOUNT_REQ;
                if (protoCode < OpCode.CALL_ACTOR_METHOD)
                {
                    var peer = Global.NetManager.GetPeerById(this.FromHostId, this.NetType);
                    var context = new RpcContext(null, peer);
                    Global.Host.CallMethodWithParams(protoCode, new object[] { username, password, _cb, context });
                }
                else
                    Global.Host.GetActor(this.toActorId).CallMethodWithParams(protoCode, new object[] { username, password, _cb });
            }
            else
            {
                var msg = new DeleteAccountReq()
                {
                username=username,
                password=password
                };
                var cb = new Action<byte[]>((cbData) => {
                    var cbMsg = cbData==null ? new DeleteAccountReq.Callback() : RpcUtil.Deserialize<DeleteAccountReq.Callback>(cbData);
                    _cb?.Invoke(cbMsg);
                });
                this.CallRemoteMethod(ProtocolCode.DELETE_ACCOUNT_REQ, msg, cb);
             }
             return await t.Task;
        }

        public void rpc_delete_account(String username, String password, Action<ErrCode> callback)
        {
            var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId, this.isClient);
            if (this.FromHostId == toHostId)
            {
                var protoCode = ProtocolCode.DELETE_ACCOUNT_REQ;
                if (protoCode < OpCode.CALL_ACTOR_METHOD)
                {
                    var peer = Global.NetManager.GetPeerById(this.FromHostId, this.NetType);
                    var context = new RpcContext(null, peer);
                    Global.Host.CallMethodWithParams(protoCode, new object[] { username, password, callback, context });
                }
                else
                    Global.Host.GetActor(this.toActorId).CallMethodWithParams(protoCode, new object[] { username, password, callback });
                return;
            }
            var msg = new DeleteAccountReq()
            {
                username=username,
                password=password
            };
            var cb = new Action<byte[]>((cbData) => {
                var cbMsg = cbData==null?new DeleteAccountReq.Callback():RpcUtil.Deserialize<DeleteAccountReq.Callback>(cbData);
                callback?.Invoke(cbMsg.code);
            });
            this.CallRemoteMethod(ProtocolCode.DELETE_ACCOUNT_REQ, msg, cb);
        }

        public async Task<LoginReq.Callback> rpc_loginAsync(String username, String password, Action<ErrCode, String, UInt64, String, String> callback=null)
        {
            var t = new TaskCompletionSource<LoginReq.Callback>();
            Action<LoginReq.Callback> _cb = (cbMsg) =>
            {
                t.TrySetResult(cbMsg);
                callback?.Invoke(cbMsg.code, cbMsg.arg1, cbMsg.arg2, cbMsg.arg3, cbMsg.arg4);
            };
            var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId, this.isClient);
            if (this.FromHostId == toHostId)
            {
                var protoCode = ProtocolCode.LOGIN_REQ;
                if (protoCode < OpCode.CALL_ACTOR_METHOD)
                {
                    var peer = Global.NetManager.GetPeerById(this.FromHostId, this.NetType);
                    var context = new RpcContext(null, peer);
                    Global.Host.CallMethodWithParams(protoCode, new object[] { username, password, _cb, context });
                }
                else
                    Global.Host.GetActor(this.toActorId).CallMethodWithParams(protoCode, new object[] { username, password, _cb });
            }
            else
            {
                var msg = new LoginReq()
                {
                username=username,
                password=password
                };
                var cb = new Action<byte[]>((cbData) => {
                    var cbMsg = cbData==null ? new LoginReq.Callback() : RpcUtil.Deserialize<LoginReq.Callback>(cbData);
                    _cb?.Invoke(cbMsg);
                });
                this.CallRemoteMethod(ProtocolCode.LOGIN_REQ, msg, cb);
             }
             return await t.Task;
        }

        public void rpc_login(String username, String password, Action<ErrCode, String, UInt64, String, String> callback)
        {
            var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId, this.isClient);
            if (this.FromHostId == toHostId)
            {
                var protoCode = ProtocolCode.LOGIN_REQ;
                if (protoCode < OpCode.CALL_ACTOR_METHOD)
                {
                    var peer = Global.NetManager.GetPeerById(this.FromHostId, this.NetType);
                    var context = new RpcContext(null, peer);
                    Global.Host.CallMethodWithParams(protoCode, new object[] { username, password, callback, context });
                }
                else
                    Global.Host.GetActor(this.toActorId).CallMethodWithParams(protoCode, new object[] { username, password, callback });
                return;
            }
            var msg = new LoginReq()
            {
                username=username,
                password=password
            };
            var cb = new Action<byte[]>((cbData) => {
                var cbMsg = cbData==null?new LoginReq.Callback():RpcUtil.Deserialize<LoginReq.Callback>(cbData);
                callback?.Invoke(cbMsg.code, cbMsg.arg1, cbMsg.arg2, cbMsg.arg3, cbMsg.arg4);
            });
            this.CallRemoteMethod(ProtocolCode.LOGIN_REQ, msg, cb);
        }


        public void rpc_reset_password(String username, String email)
        {
           var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId, this.isClient);
           if (this.FromHostId == toHostId)
           {
                var protoCode = ProtocolCode.RESET_PASSWORD_REQ;
                if (protoCode < OpCode.CALL_ACTOR_METHOD)
                {
                    var peer = Global.NetManager.GetPeerById(this.FromHostId, this.NetType);
                    var context = new RpcContext(null, peer);
                    Global.Host.CallMethodWithParams(protoCode, new object[] { username, email, context });
                }
                else
                    Global.Host.GetActor(this.toActorId).CallMethodWithParams(protoCode, new object[] { username, email }); 
               return;
           }
           var msg = new ResetPasswordReq()
           {
                username=username,
                email=email
           };
           this.CallRemoteMethod(ProtocolCode.RESET_PASSWORD_REQ, msg, null);
        }
    }
}

