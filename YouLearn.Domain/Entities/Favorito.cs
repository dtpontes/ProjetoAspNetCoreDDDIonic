using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.Entities.Base;

namespace YouLearn.Domain.Entities
{
    public class Favorito : EntityBase
    {
        protected Favorito()
        {
            
        }

        public Video Video { get;private set; }

        public Usuario Usuario { get; private set; }
    }
}
