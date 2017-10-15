namespace LazyLoad.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Elemento")]
    public partial class Elemento
    {
        public int Id { get; set; }

        public int IdCaso { get; set; }

        public int Valor { get; set; }

        public virtual Caso Caso { get; set; }
    }
}
