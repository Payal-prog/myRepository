﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

using Renci.SshNet.Tests.Common;

namespace Renci.SshNet.Tests.Classes.Connection
{
    [TestClass]
    public class HttpConnectorTest_Connect_ProxyUserNameIsEmpty : HttpConnectorTestBase
    {
        private ConnectionInfo _connectionInfo;
        private AsyncSocketListener _proxyServer;
        private bool _disconnected;
        private Socket _clientSocket;
        private List<byte> _bytesReceivedByProxy;
        private string _expectedHttpRequest;
        private Socket _actual;

        protected override void SetupData()
        {
            base.SetupData();

            _connectionInfo = new ConnectionInfo(IPAddress.Loopback.ToString(),
                                                 777,
                                                 "user",
                                                 ProxyTypes.Http,
                                                 IPAddress.Loopback.ToString(),
                                                 8122,
                                                 string.Empty,
                                                 "proxyPwd",
                                                 new KeyboardInteractiveAuthenticationMethod("user"))
            {
                Timeout = TimeSpan.FromMilliseconds(20)
            };
            _expectedHttpRequest = string.Format("CONNECT {0}:{1} HTTP/1.0{2}{2}",
                                                 _connectionInfo.Host,
                                                 _connectionInfo.Port.ToString(CultureInfo.InvariantCulture),
                                                 "\r\n");
            _bytesReceivedByProxy = new List<byte>();
            _disconnected = false;
            _clientSocket = SocketFactory.Create(SocketType.Stream, ProtocolType.Tcp);

            _proxyServer = new AsyncSocketListener(new IPEndPoint(IPAddress.Loopback, _connectionInfo.ProxyPort));
            _proxyServer.Disconnected += (socket) => _disconnected = true;
            _proxyServer.BytesReceived += (bytesReceived, socket) =>
                {
                    _bytesReceivedByProxy.AddRange(bytesReceived);

                    // Only send response back after we've received the complete CONNECT request
                    // as we want to make sure HttpConnector is not waiting for any data before
                    // it sends the CONNECT request
                    if (_bytesReceivedByProxy.Count == _expectedHttpRequest.Length)
                    {
                        _ = socket.Send(Encoding.ASCII.GetBytes("\r\n"));
                        _ = socket.Send(Encoding.ASCII.GetBytes("SSH.NET\r\n"));
                        _ = socket.Send(Encoding.ASCII.GetBytes("HTTP/1.0 200 OK\r\n"));
                        _ = socket.Send(Encoding.ASCII.GetBytes("Content-Type: application/octet-stream\r\n"));
                        _ = socket.Send(Encoding.ASCII.GetBytes("\r\n"));
                        _ = socket.Send(Encoding.ASCII.GetBytes("SSH4EVER"));
                    }
                };
            _proxyServer.Start();
        }

        protected override void SetupMocks()
        {
            _ = SocketFactoryMock.Setup(p => p.Create(SocketType.Stream, ProtocolType.Tcp))
                                 .Returns(_clientSocket);
        }

        protected override void TearDown()
        {
            base.TearDown();

            _proxyServer?.Dispose();
            _clientSocket?.Close();
        }

        protected override void Act()
        {
            _actual = Connector.Connect(_connectionInfo);

            // Give some time to process all messages
            Thread.Sleep(200);
        }

        [TestMethod]
        public void ProxyShouldHaveReceivedExpectedHttpRequest()
        {
            Assert.AreEqual(_expectedHttpRequest, Encoding.ASCII.GetString(_bytesReceivedByProxy.ToArray()));
        }

        [TestMethod]
        public void ConnectShouldReturnSocketCreatedUsingSocketFactory()
        {
            Assert.IsNotNull(_actual);
            Assert.AreSame(_clientSocket, _actual);
        }

        [TestMethod]
        public void OnlyHttpResponseShouldHaveBeenConsumed()
        {
            var buffer = new byte[8];

            Assert.AreEqual(8, _actual.Available);
            Assert.AreEqual(8, _actual.Receive(buffer));
            Assert.AreEqual("SSH4EVER", Encoding.ASCII.GetString(buffer));
        }

        [TestMethod]
        public void ClientSocketShouldBeConnected()
        {
            Assert.IsFalse(_disconnected);
            Assert.IsTrue(_actual.Connected);
        }

        [TestMethod]
        public void CreateOnSocketFactoryShouldHaveBeenInvokedOnce()
        {
            SocketFactoryMock.Verify(p => p.Create(SocketType.Stream, ProtocolType.Tcp),
                                     Times.Once());
        }
    }
}