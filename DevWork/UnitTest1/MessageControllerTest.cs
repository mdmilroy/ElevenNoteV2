﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using System.Web.Http.Results;
using Contracts;
using DevWork.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Employer;
using Models.Message;
using Moq;

namespace DevWorkTests
{
    [TestClass]
    public class MessageControllerTests
    {
        [TestMethod]
        public void PostMessage_Success()
        {
            var service = new Mock<IMessageService>();
            service.Setup(S => S.CreateMessage(It.IsAny<MessageCreate>())).Returns(true);
            var controller = new MessageController(service.Object);

            var model = new MessageCreate();

            var result = controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PostMessage_Failure_CreateMessageFailed()
        {
            var service = new Mock<IMessageService>();
            service.Setup(S => S.CreateMessage(It.IsAny<MessageCreate>())).Returns(false);
            var controller = new MessageController(service.Object);

            var model = new MessageCreate();

            var result = controller.Post(model);
            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}