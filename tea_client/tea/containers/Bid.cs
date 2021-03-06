﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tea
{
    class Bid
    {
        public int ID { get; }
        public string Caption { get; }
        public List<Toy> Toys { get; }
        public bool IsActive { get; set; }
        public string Description { get; }
        public User User { get; }

        public Bid(int id, string caption, string description, User user)
        {
            this.ID = id;
            this.Caption = caption ?? throw new ArgumentNullException(nameof(caption));
            this.Description = description ?? throw new ArgumentNullException(nameof(description));
            this.User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public Bid(int iD, string caption, List<Toy> toys, bool isActive, string description, User user)
        {
            this.ID = iD;
            this.Caption = caption;
            this.Toys = toys;
            this.IsActive = isActive;
            this.Description = description;
            this.User = user;
        }

        public override bool Equals(object obj)
        {
            return obj is Bid && ((Bid)obj).ID == this.ID;
        }

        public override int GetHashCode()
        {
            return (int)(base.GetHashCode() * (this.ID % Int32.MaxValue)) % Int32.MaxValue;
        }

        public override string ToString()
        {
            return "Caption:\t" + this.Caption + Environment.NewLine
                + "Description:\t" + this.Description + Environment.NewLine
                + "Owner:\t" + this.User;
        }
    }
}
