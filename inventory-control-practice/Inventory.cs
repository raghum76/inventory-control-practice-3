﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_control_practice
{
    class Inventory
    {
        private Product _initProduct;
        private int _inventoryCounter;

        public Inventory()
        {
            _inventoryCounter = 0;
        }

        public override string ToString()
        {
            return "Número de productos en inventario: " + _inventoryCounter;
        }

        public void add(Product product)
        {
            if (_initProduct == null)
            {
                _initProduct = product;
            }
            else
            {
                if (product.code <= _initProduct.code)
                {
                    product.next = _initProduct;
                    _initProduct = product;
                }
                else
                {
                    Product temp = _initProduct;

                    while (temp.next != null)
                    {
                        if (product.code <= temp.next.code)
                            break;

                        temp = temp.next;
                    }

                    product.next = temp.next;
                    temp.next = product;
                }
            }

            _inventoryCounter++;
        }

        private Product _specialSearch(string name)
        {
            if (_initProduct != null)
            {
                for (Product temp = _initProduct; temp.next != null; temp = temp.next)
                {
                    if (temp.next.name == name)
                        return temp;
                }
            }

            return null;
        }

        public Product search(string name)
        {
            if (_initProduct != null)
            {
                if (_initProduct.name == name)
                    return _initProduct;

                Product temp = _specialSearch(name);

                if (temp != null)
                    return temp.next;
            }

            return null;
        }

        public void delete(string name)
        {
            if (_initProduct != null)
            {
                if (_initProduct.name == name)
                {
                    _initProduct = _initProduct.next;
                    _inventoryCounter--;
                }
                else
                {
                    Product temp = _specialSearch(name);

                    if (temp != null)
                    {
                        temp.next = temp.next.next;
                        _inventoryCounter--;
                    }
                }
            }
        }

        public string report()
        {
            string str = ToString() + Environment.NewLine;

            Product temp = _initProduct;

            while (temp != null)
            {
                str += temp.ToString();
                str += "--------------------------------------------------------" + Environment.NewLine;
                temp = temp.next;
            }

            return str;
        }
    }
}
