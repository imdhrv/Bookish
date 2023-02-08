using Braintree;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookish.Utility
{
    public interface IBrainTreeGate
    {
        IBraintreeGateway CreateGateway();
        IBraintreeGateway GetGateway();
    }
}
