//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InternetShopAPI
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Роль
    {
        public Роль()
        {
            this.Пользователь = new HashSet<Пользователь>();
        }
    
        public long КодРоли { get; set; }
        public string Роль1 { get; set; }

        [JsonIgnore]
        public virtual ICollection<Пользователь> Пользователь { get; set; }
    }
}
