﻿using NUnit.Framework;
using Tests.MessageStubs;

namespace NotificationStack.IntegrationTests.FluentNotificationStackTests
{
    public class WhenAMessageIsPublishedViaSnsToSqsSubscriber : GivenANotificationStack
    {
        private Future<GenericMessage> _handler;

        protected override void Given()
        {
            base.Given();
            _handler= new Future<GenericMessage>();
            RegisterHandler(_handler);
        }

        protected override void When()
        {
            ServiceBus.Publish(new GenericMessage());
        }

        [Test]
        public void ThenItGetsHandled()
        {
            _handler.WaitUntilCompletion(2.Seconds()).ShouldBeTrue();
        }
    }
}