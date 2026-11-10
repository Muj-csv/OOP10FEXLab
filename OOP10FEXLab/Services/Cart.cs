using System;
using System.Collections.Generic;
using System.Linq;
using OOP10FEXLab.Models;

namespace OOP10FEXLab.Services
{
    /// <summary>The customer's current order before it is placed.</summary>
    public class Cart
    {
        private readonly List<OrderItem> items = new List<OrderItem>();

        public event EventHandler Changed;

        public IReadOnlyList<OrderItem> Items
        {
            get { return items.AsReadOnly(); }
        }

        public decimal Total
        {
            get { return items.Sum(i => i.Subtotal); }
        }

        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }

        public void Add(Meal meal)
        {
            OrderItem item = items.FirstOrDefault(i => i.Code == meal.Code);
            if (item == null)
                items.Add(new OrderItem { Code = meal.Code, Name = meal.Name, Price = meal.Price, Quantity = 1 });
            else
                item.Quantity++;
            OnChanged();
        }

        public void Decrease(string code)
        {
            OrderItem item = items.FirstOrDefault(i => i.Code == code);
            if (item == null) return;

            item.Quantity--;
            if (item.Quantity <= 0) items.Remove(item);
            OnChanged();
        }

        public void Clear()
        {
            items.Clear();
            OnChanged();
        }

        private void OnChanged()
        {
            if (Changed != null) Changed(this, EventArgs.Empty);
        }
    }
}
