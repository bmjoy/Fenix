﻿
//AUTOGEN, do not modify it!

using Fenix;
using Fenix.Common;
using Fenix.Common.Attributes;
using Fenix.Common.Utils;
using Shared;
using Shared.DataModel;
using Shared.Protocol; 
using Shared.Message;

using MessagePack; 
using System;

namespace Server
{

    [RefType("Avatar")]
    public partial class AvatarRef : ActorRef
    {
        public void rpc_change_name(String name, Action<ErrCode> callback)
        {
            var toHostId = Global.IdManager.GetHostIdByActorId(this.toActorId);
            if (this.FromHostId == toHostId)
            {
                Host.Instance.GetActor(this.toActorId).CallLocalMethod(ProtocolCode.CHANGE_NAME_REQ, new object[] { name, callback });
                return;
            }
            var msg = new ChangeNameReq()
            {
                name=name
            };
            var cb = new Action<byte[]>((cbData) => {
                var cbMsg = RpcUtil.Deserialize<ChangeNameReq.Callback>(cbData);
                callback?.Invoke(cbMsg.code);
            });
            this.CallRemoteMethod(ProtocolCode.CHANGE_NAME_REQ, msg, cb);
        }
    }
}

