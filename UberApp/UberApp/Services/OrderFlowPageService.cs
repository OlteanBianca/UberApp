using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UberApp.ViewModels;

namespace UberApp.Services
{
    public class OrderFlowPageService
    {
        private readonly DataBaseService _dataBaseService;
        private readonly OrderFlowVM _orderFlowVM;

        public OrderFlowPageService(OrderFlowVM orderFlowVM)
        {
            _dataBaseService = new();
            _orderFlowVM = orderFlowVM;
        }


    }
}
