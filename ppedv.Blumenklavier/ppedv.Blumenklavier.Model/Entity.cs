﻿using System;

namespace ppedv.Blumenklavier.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
    }

}
