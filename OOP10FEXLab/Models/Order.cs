using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP10FEXLab.Models
{
    public enum OrderStatus { Preparing, NowServing, Claimed }

    public enum DiningOption { DineIn, TakeOut }

    /// <summary>One meal line inside an order.</summary>
    public class OrderItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Subtotal
        {
            get { return Price * Quantity; }
        }
    }

    /// <summary>A placed order = one line in the transaction record.</summary>
    public class Order
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DiningOption DiningOption { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; private set; }

        public Order()
        {
            Items = new List<OrderItem>();
        }

        public decimal Total
        {
            get { return Items.Sum(i => i.Subtotal); }
        }
    }
}
