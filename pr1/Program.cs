// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Expense
{
    public string Name { get; set; }
    public decimal Amount { get; set; }

    public Expense(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Name}; {Amount} руб.";
    }
}
