using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Contexts
{
    public static class MapBase
    {
     
        internal static EntityTypeBuilder<TEntity> AddRequired<TEntity, TProperty>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TProperty>> property, string columnName, string columnType)
            where TEntity : class
        {
            var mapping = builder
                          .Property(property)
                          .HasColumnName(columnName)
                          .HasColumnType(columnType);

            mapping.IsRequired();

            return builder;
        }

        internal static EntityTypeBuilder<TEntity> AddOptional<TEntity, TProperty>(
            this EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TProperty>> property, string columnName, string columnType)
            where TEntity : class
        {
            var mapping = builder
                          .Property(property)
                          .HasColumnName(columnName)
                          .HasColumnType(columnType);

            return builder;
        }
    }
}
