//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grades
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public int courseId { get; set; }
        public int score { get; set; }
    
        public virtual Courses Courses { get; set; }
        public virtual Students Students { get; set; }
    }
}