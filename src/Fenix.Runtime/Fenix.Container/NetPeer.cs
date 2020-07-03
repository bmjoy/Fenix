﻿using DotNetty.Buffers;
using DotNetty.KCP;
using DotNetty.Transport.Channels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fenix
{
    public class NetPeer
    { 
        public uint ConnId { get; set; }

        protected Ukcp kcpChannel { get; set; }

        protected IChannel tcpChannel { get; set; }

        public static NetPeer Create(uint connId, Ukcp kcpCh)
        {
            var obj = new NetPeer();
            obj.ConnId = connId;
            obj.kcpChannel = kcpCh;
            return obj;
        }

        public static NetPeer Create(uint connId, IChannel tcpCh)
        {
            var obj = new NetPeer();
            obj.ConnId = connId;
            obj.tcpChannel = tcpCh;
            return obj;
        }

        public void Send(byte[] bytes)
        {     
            kcpChannel?.send(bytes);
            tcpChannel?.WriteAndFlushAsync(Unpooled.WrappedBuffer(bytes));
        }

        public async Task SendAsync(byte[] bytes)
        {
            await Task.Run(() => {
                this.Send(bytes);
            });
        }
    }
}