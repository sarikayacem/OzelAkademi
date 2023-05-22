﻿using OzelAkademi.Business.Abstract;
using OzelAkademi.Data.Abstract;
using OzelAkademi.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelAkademi.Business.Concrete
{
    public class OrderManager :IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        //public async Task<List<Order>> GetAllOrdersAsync(string userId = null, bool dateSort = false)
        //{
        //    return await _orderRepository.GetAllOrdersAsync(userId,dateSort);
        //}

        //public async Task<List<Order>> SearchOrderByUser(string keyword, bool dateSort = false)
        //{
        //    return await _orderRepository.SearchOrderByUser(keyword, dateSort);
        //}
    }
}
